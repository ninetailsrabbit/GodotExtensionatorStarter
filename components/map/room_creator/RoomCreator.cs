using Extensionator;
using Godot;
using GodotExtensionator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace GodotExtensionatorStarter {
    [Tool]
    public partial class RoomCreator : Node3D {
        [Export] public bool CreateNewRoom { get => _createNewRoom; set { CreateRooms(); } } // Tool button
        [Export] public bool ClearRoom { get => _clearRoom; set { ClearExistingRooms(); } } // Tool button
        [Export] public bool GenerateFinalMesh { get => _generateFinalMesh; set { GenerateRoomMesh(); } } // Tool button

        [ExportGroup("Sizes")]
        [Export(PropertyHint.Range, "1, 1000, 1")] public int NumberOfRooms = 3;
        [Export(PropertyHint.Range, "1, 4, 1")] public int DoorsPerRoom = 2;
        [Export] public Vector3 DoorSize = new(1.5f, 2f, 0.25f);
        [Export] public Vector3 BridgeConnectorSize = new(2, 2.5f, 5f);

        [Export] public bool RandomizeDoorPositionInWall = false;
        [Export]
        public Vector3 MinRoomSize {
            get => _minRoomSize;
            set {
                if (_minRoomSize != value) {
                    _minRoomSize = value;
                    CreateRooms();
                }
            }
        }

        [Export]
        public Vector3 MaxRoomSize {
            get => _maxRoomSize;
            set {
                if (_maxRoomSize != value) {
                    _maxRoomSize = value;
                    CreateRooms();
                }
            }
        }
        [Export]
        public float WallThickness {
            get => _wallThickness;
            set {
                if (_wallThickness != value) {
                    _wallThickness = value;
                    CreateRooms();
                }
            }
        }
        [Export]
        public float CeilThickness {
            get => _ceilThickness;
            set {
                if (_ceilThickness != value) {
                    _ceilThickness = value;
                    CreateRooms();
                }
            }
        }
        [Export]
        public float FloorThickness {
            get => _floorThickness;
            set {
                if (_floorThickness != value) {
                    _floorThickness = value;
                    CreateRooms();
                }
            }
        }
        [ExportGroup("Include in generation")]
        [Export] public bool GenerateMaterials = true;
        [Export] public bool IncludeCeil = true;
        [Export] public bool IncludeFloor = true;
        [Export] public bool IncludeRightWall = true;
        [Export] public bool IncludeLeftWall = true;
        [Export] public bool IncludeFrontWall = true;
        [Export] public bool IncludeBackWall = true;
        [ExportGroup("Collisions")]
        [Export] public bool GenerateCollisions = true;
        [Export] public AvailableCollisions TypeOfCollision = AvailableCollisions.Convex;
        [Export] public bool CreateStaticBody = true;
        [Export] public bool CleanCollision = true;
        [Export] public bool SimplifiedCollision = false;


        public enum AvailableCollisions {
            Convex, // Basic shapes
            Trimesh, // More complex shapes that contains csg operations as substraction
        }

        private CsgCombiner3D? CsgCombinerRoot { get; set; } = default!;
        private CsgCombiner3D? LastRoom { get; set; } = default!;
        private CsgCombiner3D? LastBridgeConnector { get; set; } = default!;
        private Node3D? MeshOutputNode { get; set; } = default!;

        private bool _createNewRoom = false;
        private bool _clearRoom = false;
        private bool _generateFinalMesh = false;

        private Vector3 _minRoomSize = new(6f, 3.5f, 5f);
        private Vector3 _maxRoomSize = new(10f, 5f, 6f);

        private float _wallThickness = 0.15f;
        private float _ceilThickness = 0.1f;
        private float _floorThickness = 0.1f;

        // (Pi / 2) * wallRotation selected
        private readonly Godot.Collections.Dictionary<string, Godot.Collections.Dictionary<string, int>> _wallRotations = new() {
            { "FrontWall", new() { {"FrontWall", 2}, { "BackWall", 0}, { "RightWall", 1 }, { "LeftWall", -1 } } },
            { "BackWall", new() { {"FrontWall", 0}, { "BackWall", 2}, { "RightWall", -1 }, { "LeftWall", 1 } } },
            { "RightWall", new() { {"FrontWall", 1}, { "BackWall", -1}, { "RightWall", 2 }, { "LeftWall", 0} } },
            { "LeftWall", new() { {"FrontWall", -1}, { "BackWall", 1}, { "RightWall", 0}, { "LeftWall", 2} } },
        };

        private readonly Random _rng = new();

        public void CreateRooms() {
            if (ToolCanBeUsed()) {
                ClearExistingRooms();

                CsgCombinerRoot = new CsgCombiner3D() { Name = nameof(CsgCombinerRoot), UseCollision = false };
                AddChild(CsgCombinerRoot);
                CsgCombinerRoot.SetOwnerToEditedSceneRoot();

                for (int i = 0; i < NumberOfRooms; i++) {

                    if (CreateRoom(LastRoom is null ? 1 : DoorsPerRoom) is CsgCombiner3D room) {

                        if (LastRoom is not null) {
                            ConnectRooms(LastRoom, room);
                        }

                        LastRoom = room;
                    }

                }
            }
        }

        public void ConnectRooms(CsgCombiner3D roomA, CsgCombiner3D roomB) {
            Marker3D? roomASocket = AvailableSocketsFrom(roomA).FirstOrDefault();
            Marker3D? roomBSocket = AvailableSocketsFrom(roomB).FirstOrDefault();

            if (roomASocket is not null && roomBSocket is not null) {
                var wallRoomA = roomASocket.GetParent<CsgBox3D>();
                var wallRoomB = roomBSocket.GetParent<CsgBox3D>();

                roomB.RotateY( (Mathf.Pi / 2) * _wallRotations[wallRoomB.Name.ToString()][wallRoomA.Name.ToString()]);
                


                roomASocket.SetMeta("connected", true);
                roomBSocket.SetMeta("connected", true);
            }
        }


        public CsgCombiner3D? CreateRoom(int doorSlots = 1) {
            if (ToolCanBeUsed() && CsgCombinerRoot is not null) {

                CsgCombiner3D rootNodeForThisRoom = new() {
                    Name = $"Room{CsgCombinerRoot.GetChildCount() + 1}",
                    Position = Vector3.Zero, // LastRoom?.Position ?? Vector3.Zero,
                    UseCollision = false
                };

                CsgCombinerRoot.AddChild(rootNodeForThisRoom);
                rootNodeForThisRoom.SetOwnerToEditedSceneRoot();

                Vector3 roomSize = GenerateRoomSize(MinRoomSize, MaxRoomSize);

                CreateFloor(rootNodeForThisRoom, roomSize);
                CreateCeil(rootNodeForThisRoom, roomSize);
                CreateFrontWall(rootNodeForThisRoom, roomSize);
                CreateBackWall(rootNodeForThisRoom, roomSize);
                CreateRightWall(rootNodeForThisRoom, roomSize);
                CreateLeftWall(rootNodeForThisRoom, roomSize);


                for (int i = 0; i < doorSlots; i++) {
                    CreateDoorSlotInRandomWall(rootNodeForThisRoom, roomSize, i);
                }

                CreateMaterialOnExistingCSGShapes(rootNodeForThisRoom);

                return rootNodeForThisRoom;
            }

            return null;
        }

        public void CreateBridgeConnector(Vector3? bridgeSize = null) {
            if (CsgCombinerRoot is not null) {
                bridgeSize ??= BridgeConnectorSize;

                CsgCombiner3D bridgeConnector = new() { Name = $"BridgeConnector{OSExtension.GenerateRandomIdFromUnixTime()}" };
                AddChild(bridgeConnector);
                bridgeConnector.SetOwnerToEditedSceneRoot();

                CreateFloor(bridgeConnector, bridgeSize.Value);
                CreateCeil(bridgeConnector, bridgeSize.Value);
                CreateFrontWall(bridgeConnector, bridgeSize.Value);
                CreateBackWall(bridgeConnector, bridgeSize.Value);
                CreateRightWall(bridgeConnector, bridgeSize.Value);
                CreateLeftWall(bridgeConnector, bridgeSize.Value);

                CreateDoorSlotInWall(bridgeConnector.GetNode<CsgBox3D>("FrontWall"), DoorSize);
                CreateDoorSlotInWall(bridgeConnector.GetNode<CsgBox3D>("BackWall"), DoorSize, 2);

                LastBridgeConnector = bridgeConnector;
            }


        }


        public void CreateMaterialOnExistingCSGShapes(CsgCombiner3D roomParent) {
            if (GenerateMaterials) {
                foreach (var csgShape in roomParent.GetAllChildren<CsgBox3D>()) {
                    csgShape.Material = new StandardMaterial3D();
                }
            }

        }

        public void CreateFloor(CsgCombiner3D roomParent, Vector3 roomSize) {
            if (IncludeFloor) {
                CsgBox3D floor = new() {
                    Name = "Floor",
                    Size = new Vector3(roomSize.X, FloorThickness, roomSize.Z),
                    Position = Position with { Y = 0 }
                };

                roomParent.AddChild(floor);

                floor.SetOwnerToEditedSceneRoot();
            }
        }

        public void CreateCeil(CsgCombiner3D roomParent, Vector3 roomSize) {
            if (IncludeCeil) {
                CsgBox3D ceil = new() {
                    Name = "Ceil",
                    Size = new Vector3(roomSize.X, CeilThickness, roomSize.Z),
                    Position = Position with { Y = Mathf.Max(roomSize.Y, (roomSize.Y + CeilThickness) - roomSize.Y / 2.5f) }
                };

                roomParent.AddChild(ceil);

                ceil.SetOwnerToEditedSceneRoot();
            }
        }

        public void CreateFrontWall(CsgCombiner3D roomParent, Vector3 roomSize) {
            if (IncludeFrontWall) {
                CsgBox3D frontWall = new() {
                    Name = "FrontWall",
                    Size = new Vector3(roomSize.X, roomSize.Y, WallThickness),
                    Position = Position with { X = 0, Y = roomSize.Y / 2, Z = Mathf.Min(-roomSize.Z / 2, -(roomSize.Z + WallThickness) / 2.5f) }
                };

                roomParent.AddChild(frontWall);

                frontWall.SetOwnerToEditedSceneRoot();
            }
        }

        public void CreateBackWall(CsgCombiner3D roomParent, Vector3 roomSize) {
            if (IncludeBackWall) {
                CsgBox3D backWall = new() {
                    Name = "BackWall",
                    Size = new Vector3(roomSize.X, roomSize.Y, WallThickness),
                    Position = Position with { X = 0, Y = roomSize.Y / 2, Z = Mathf.Max(roomSize.Z / 2, (roomSize.Z + WallThickness) / 2.5f) }
                };

                roomParent.AddChild(backWall);

                backWall.SetOwnerToEditedSceneRoot();
            }
        }

        public void CreateRightWall(CsgCombiner3D roomParent, Vector3 roomSize) {
            if (IncludeRightWall) {

                CsgBox3D rightWall = new() {
                    Name = "RightWall",
                    Size = new Vector3(WallThickness, roomSize.Y, roomSize.Z),
                    Position = Position with { X = Mathf.Max(roomSize.X / 2, (roomSize.X + WallThickness) / 2.5f), Y = roomSize.Y / 2, Z = 0 }
                };

                roomParent.AddChild(rightWall);

                rightWall.SetOwnerToEditedSceneRoot();
            }
        }

        public void CreateLeftWall(CsgCombiner3D roomParent, Vector3 roomSize) {
            if (IncludeLeftWall) {
                CsgBox3D leftWall = new() {
                    Name = "LeftWall",
                    Size = new Vector3(WallThickness, roomSize.Y, roomSize.Z),
                    Position = Position with { X = Mathf.Min(-roomSize.X / 2, -(roomSize.X + WallThickness) / 2.5f), Y = roomSize.Y / 2, Z = 0 }
                };

                roomParent.AddChild(leftWall);

                leftWall.SetOwnerToEditedSceneRoot();
            }
        }


        public void CreateDoorSlotInRandomWall(CsgCombiner3D roomParent, Vector3 roomSize, int socketNumber = 1) {
            CsgBox3D randomWall = roomParent.GetChildren()
                    .Where(child => child.Name.ToString().Contains("wall", System.StringComparison.OrdinalIgnoreCase) && child.GetChildCount() == 0)
                    .Cast<CsgBox3D>()
                    .RandomElement();

            CreateDoorSlotInWall(randomWall, roomSize, socketNumber);
        }

        public void CreateDoorSlotInWall(CsgBox3D wall, Vector3 roomSize, int socketNumber = 1) {
            if (wall.GetChildCount().IsZero()) {

                Vector3 doorRotation = new Vector3(0, Regex.IsMatch(wall.Name.ToString(), "(front|back)", RegexOptions.IgnoreCase) ? 0 : Mathf.Pi / 2, 0);

                CsgBox3D doorSlot = new() {
                    Name = "DoorSlot",
                    Operation = CsgShape3D.OperationEnum.Subtraction,
                    Size = DoorSize,
                    Position = new Vector3(0, Vector3.Down.Y * ((roomSize.Y / 2) - (DoorSize.Y / 2)), 0),
                    Rotation = doorRotation
                };

                wall.AddChild(doorSlot);
                doorSlot.SetOwnerToEditedSceneRoot();

                Marker3D roomSocket = new() {
                    Name = $"RoomSocket{socketNumber}",
                    Position = new Vector3(0, Math.Min((doorSlot.Position.Y + DoorSize.Y / 2) + 0.1f, roomSize.Y), 0),
                   // Rotation = doorRotation.Flip()
                };

                roomSocket.SetMeta("connected", false);

                wall.AddChild(roomSocket);
                roomSocket.SetOwnerToEditedSceneRoot();
            }
        }

        private List<Marker3D> AvailableSocketsFrom(CsgCombiner3D room)
           => room.FindChildren("*", typeof(Marker3D).Name)
               .Where(socket => IsInstanceValid(socket) && !(bool)socket.GetMeta("connected"))
               .Cast<Marker3D>()
               .ToList();

        public Vector3 GenerateRoomSize(Vector3? minRoomSize = null, Vector3? maxRoomSize = null) {
            minRoomSize ??= MinRoomSize;
            maxRoomSize ??= MaxRoomSize;

            if (minRoomSize.Value.IsEqualApprox(maxRoomSize.Value))
                return minRoomSize.Value;
            else
                return new Vector3(
                    _rng.NextFloat(minRoomSize.Value.X, maxRoomSize.Value.X),
                    _rng.NextFloat(minRoomSize.Value.Y, maxRoomSize.Value.Y),
                    _rng.NextFloat(minRoomSize.Value.Z, maxRoomSize.Value.Z));
        }


        public void AlignBridgeSocketWithRoom(CsgCombiner3D bridgeConnector, CsgCombiner3D room) {
            var bridgeSockets = AvailableSocketsFrom(bridgeConnector);
            Marker3D bridgeSocket = bridgeSockets.First();
            Marker3D roomSocket = AvailableSocketsFrom(room).First();

            var bridgeWall = bridgeSocket.GetParent<CsgBox3D>();
            var roomWall = roomSocket.GetParent<CsgBox3D>();

            if (bridgeSockets.Count > 1) {
                bridgeConnector.RotateY(Mathf.Pi / 2 * _wallRotations[bridgeWall.Name.ToString()][roomWall.Name.ToString()]);
                bridgeConnector.GlobalTranslate(bridgeSocket.GlobalPosition - roomSocket.GlobalPosition);
            }
            else {
                room.RotateY(Mathf.Pi / 2 * _wallRotations[roomWall.Name.ToString()][bridgeWall.Name.ToString()]);
                room.GlobalTranslate(roomSocket.GlobalPosition - bridgeSocket.GlobalPosition);

            }


            bridgeSocket.SetMeta("connected", true);
            roomSocket.SetMeta("connected", true);
        }

        public void GenerateRoomMesh() {
            if (ToolCanBeUsed() && CsgCombinerRoot is not null && CsgCombinerRoot.IsRootShape() && CsgCombinerRoot.GetChildCount() > 0) {

                MeshOutputNode = new Node3D() { Name = nameof(MeshOutputNode) };
                AddChild(MeshOutputNode);
                MeshOutputNode.SetOwnerToEditedSceneRoot();

                var meshes = CsgCombinerRoot.GetMeshes();
                var meshInstance = new MeshInstance3D {
                    Name = "GeneratedRoomMesh",
                    Mesh = (Mesh)meshes[1]
                };

                MeshOutputNode.AddChild(meshInstance);
                meshInstance.SetOwnerToEditedSceneRoot();

                for (int i = 0; i < meshInstance.Mesh.GetSurfaceCount(); i++) {
                    if (CsgCombinerRoot.GetChildOrNull<CsgBox3D>(i) is CsgBox3D roomPart) {
                        ((ArrayMesh)meshInstance.Mesh).SurfaceSetName(i, roomPart.Name);
                    }
                }

                if (GenerateCollisions) {
                    switch (TypeOfCollision) {
                        case AvailableCollisions.Convex:
                            var convexCollision = new CollisionShape3D() {
                                Name = "ConvexCollision",
                                Shape = meshInstance.Mesh.CreateConvexShape(CleanCollision, SimplifiedCollision)
                            };

                            if (CreateStaticBody) {
                                var body = new StaticBody3D() { Name = "StaticBody3D" };
                                meshInstance.AddChild(body);
                                body.SetOwnerToEditedSceneRoot();
                                body.AddChild(convexCollision);

                            }
                            else {
                                meshInstance.AddChild(convexCollision);
                            }

                            convexCollision.SetOwnerToEditedSceneRoot();

                            break;
                        case AvailableCollisions.Trimesh:
                            var trimeshCollision = new CollisionShape3D() {
                                Name = "TrimeshCollision",
                                Shape = meshInstance.Mesh.CreateTrimeshShape()
                            };

                            if (CreateStaticBody) {
                                var body = new StaticBody3D() { Name = "StaticBody3D" };
                                meshInstance.AddChild(body);
                                body.SetOwnerToEditedSceneRoot();
                                body.AddChild(trimeshCollision);
                                trimeshCollision.SetOwnerToEditedSceneRoot();
                            }
                            else {
                                meshInstance.AddChild(trimeshCollision);
                            }

                            trimeshCollision.SetOwnerToEditedSceneRoot();

                            break;
                    }
                }
            }

        }
        public void ClearExistingRooms() {
            if (ToolCanBeUsed() && GetChildCount() > 0) {

                foreach (var child in GetChildren())
                    child.Free();

                CsgCombinerRoot = null;
                LastRoom = null;
                LastBridgeConnector = null;
                MeshOutputNode = null;
            }
        }

        private bool ToolCanBeUsed() => Engine.IsEditorHint() && IsInsideTree();
    }
}