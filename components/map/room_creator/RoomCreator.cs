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

        [Signal]
        public delegate void RequestedGenerateRoomChunkEventHandler(int amount);

        [ExportGroup("Tool buttons")]
        [Export] public bool CreateNewRoom { get => _createNewRoom; set { CreateRooms(); } } // Tool button
        [Export] public bool GenerateFinalMesh { get => _generateFinalMesh; set { GenerateRoomMeshes(); } } // Tool button
        [Export] public bool ClearGeneratedRooms { get => _clearRoom; set { ClearRoomsInSceneTree(); } } // Tool button

        [ExportGroup("Sizes")]
        [Export(PropertyHint.Range, "1, 1000, 1")] public int NumberOfRooms = 3;
        [Export(PropertyHint.Range, "1, 4, 1")] public int DoorsPerRoom = 2;
        [Export] public bool UseBridgeConnectorsBetweenRooms = false;
        [Export] public bool RandomizeDoorPositionInWall = false;
        [Export] public Vector3 DoorSize = new(1.5f, 2f, 0.25f);
        [Export] public Vector3 MinBridgeConnectorSize = new(2f, 3f, 4f);
        [Export] public Vector3 MaxBridgeConnectorSize = new(2f, 3f, 10f);

        [Export]
        public Vector3 MinRoomSize = new(6f, 3.5f, 5f);

        [Export]
        public Vector3 MaxRoomSize = new(10f, 5f, 6f);
        [Export]
        public float WallThickness = 0.15f;
        [Export]
        public float CeilThickness = 0.1f;
        [Export]
        public float FloorThickness = 0.1f;
        [ExportGroup("Include in generation")]
        [Export] public bool GenerateMeshPerRoom = false;
        [Export] public bool GenerateMaterials = true;
        [Export] public bool IncludeCeil = true;
        [Export] public bool IncludeFloor = true;
        [Export] public bool IncludeRightWall = true;
        [Export] public bool IncludeLeftWall = true;
        [Export] public bool IncludeFrontWall = true;
        [Export] public bool IncludeBackWall = true;
        [ExportGroup("Collisions")]
        [Export] public bool GenerateCollisions = true;
        [Export] public AvailableCollisions TypeOfCollision = AvailableCollisions.Trimesh;
        [Export] public bool CreateStaticBody = true;
        [Export] public bool CleanCollision = true;
        [Export] public bool SimplifiedCollision = false;

        public enum AvailableCollisions {
            Convex, // Basic shapes
            Trimesh, // More complex shapes that contains csg operations as substraction
        }

        private CsgCombiner3D? CsgCombinerRoot { get; set; } = default!;
        private Node3D? CSGNode3DRoot { get; set; } = default!;
        private CsgCombiner3D? CurrentLastRoom { get; set; } = default!;
        private CsgCombiner3D? LastRoomGeneratedFromChunk { get; set; } = default!;
        private Node3D? MeshOutputNode { get; set; } = default!;

        private bool _createNewRoom = false;
        private bool _clearRoom = false;
        private bool _generateFinalMesh = false;

        // (Pi / 2) * wallRotation selected
        private readonly Godot.Collections.Dictionary<string, Godot.Collections.Dictionary<string, float>> _wallRotations = new() {
            { "FrontWall", new() { {"FrontWall", Mathf.Pi}, { "BackWall", 0f}, { "RightWall", Mathf.Pi / 2 }, { "LeftWall", -Mathf.Pi / 2 } } },
            { "BackWall", new() { {"FrontWall", 0f}, { "BackWall", Mathf.Pi }, { "RightWall", -Mathf.Pi / 2 }, { "LeftWall",  Mathf.Pi / 2 } } },
            { "RightWall", new() { {"FrontWall", -Mathf.Pi / 2}, { "BackWall",  Mathf.Pi / 2}, { "RightWall", Mathf.Pi }, { "LeftWall", 0f} } },
            { "LeftWall", new() { {"FrontWall",  Mathf.Pi / 2}, { "BackWall", -Mathf.Pi / 2}, { "RightWall", 0f}, { "LeftWall", Mathf.Pi } } },
        };

        private readonly Random _rng = new();

        public override void _ExitTree() {
            if (!Engine.IsEditorHint()) {
                RequestedGenerateRoomChunk -= OnRequestedGenerateRoomChunk;
            }
        }
        public override void _EnterTree() {
            if (!Engine.IsEditorHint()) {
                RequestedGenerateRoomChunk += OnRequestedGenerateRoomChunk;
            }
        }

        private void OnRequestedGenerateRoomChunk(int amount) {
            CurrentLastRoom = LastRoomGeneratedFromChunk;

            CreateRooms();
            GenerateRoomMeshes();
        }



        public void CreateRooms() {
            if (ToolCanBeUsed()) {

                if (GenerateMeshPerRoom) {
                    CSGNode3DRoot ??= new Node3D() { Name = nameof(CSGNode3DRoot) };
                    AddChild(CSGNode3DRoot);
                    CSGNode3DRoot.SetOwnerToEditedSceneRoot();
                }
                else {
                    CsgCombinerRoot ??= new CsgCombiner3D() { Name = nameof(CsgCombinerRoot), UseCollision = false };
                    AddChild(CsgCombinerRoot);
                    CsgCombinerRoot.SetOwnerToEditedSceneRoot();

                }

                int numberOfRooms = CalculateNumberOfRooms(UseBridgeConnectorsBetweenRooms);

                for (int i = 0; i < numberOfRooms; i++) {

                    var room = UseBridgeConnectorsBetweenRooms && i % 2 != 0 ?
                        CreateBridgeConnector() :
                        CreateRoom(CurrentLastRoom is null ? 1 : DoorsPerRoom);

                    if (CurrentLastRoom is not null && room is not null) {
                        ConnectRooms(CurrentLastRoom, room);
                    }

                    CurrentLastRoom = room;
                }

                LastRoomGeneratedFromChunk = CurrentLastRoom;
            }
        }

        public int CalculateNumberOfRooms(bool useBridgeConnectors = false) {
            int numberOfRooms = NumberOfRooms;

            if (useBridgeConnectors) {
                numberOfRooms += (int)Mathf.Ceil(numberOfRooms / 2f);

                // When use bridge connectors the number of rooms always needs to be odd to fit the correct bridges amount
                if (numberOfRooms % 2 == 0)
                    numberOfRooms += 1;
            }

            return numberOfRooms;
        }

        public CsgCombiner3D? CreateRoom(int doorSlots = 1) {
            if (ToolCanBeUsed() && (GenerateMeshPerRoom && CSGNode3DRoot is not null) || (!GenerateMeshPerRoom && CsgCombinerRoot is not null)) {

                CsgCombiner3D rootNodeForThisRoom = new() {
                    Name = $"Room{CsgCombinerRoot?.GetChildCount()}{CSGNode3DRoot?.GetChildCount()}",
                    Position = CurrentLastRoom?.Position ?? Vector3.Zero,
                    UseCollision = false
                };

                if (GenerateMeshPerRoom) {
                    CSGNode3DRoot?.AddChild(rootNodeForThisRoom);
                }
                else {
                    CsgCombinerRoot?.AddChild(rootNodeForThisRoom);
                }

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

        public CsgCombiner3D? CreateBridgeConnector(Vector3? bridgeSize = null) {
            if (ToolCanBeUsed() && (GenerateMeshPerRoom && CSGNode3DRoot is not null) || (!GenerateMeshPerRoom && CsgCombinerRoot is not null)) {
                bridgeSize ??= GenerateRoomSize(MinBridgeConnectorSize, MaxBridgeConnectorSize);

                CsgCombiner3D bridgeConnector = new() {
                    Name = $"BridgeConnector{OSExtension.GenerateRandomIdFromUnixTime()}",
                    Position = CurrentLastRoom?.Position ?? Vector3.Zero,
                    UseCollision = false
                };

                if (GenerateMeshPerRoom) {
                    CSGNode3DRoot?.AddChild(bridgeConnector);
                }
                else {
                    CsgCombinerRoot?.AddChild(bridgeConnector);
                }

                bridgeConnector.SetOwnerToEditedSceneRoot();

                CreateFloor(bridgeConnector, bridgeSize.Value);
                CreateCeil(bridgeConnector, bridgeSize.Value);
                CreateFrontWall(bridgeConnector, bridgeSize.Value);
                CreateBackWall(bridgeConnector, bridgeSize.Value);
                CreateRightWall(bridgeConnector, bridgeSize.Value);
                CreateLeftWall(bridgeConnector, bridgeSize.Value);

                CreateDoorSlotInWall(bridgeConnector.GetNode<CsgBox3D>("FrontWall"), bridgeSize.Value);
                CreateDoorSlotInWall(bridgeConnector.GetNode<CsgBox3D>("BackWall"), bridgeSize.Value, 2);

                return bridgeConnector;
            }

            return null;
        }


        private void CreateMaterialOnExistingCSGShapes(CsgCombiner3D roomParent) {
            if (GenerateMaterials) {
                foreach (var csgShape in roomParent.GetAllChildren<CsgBox3D>()) {
                    csgShape.Material = new StandardMaterial3D();
                }
            }

        }

        public void ConnectRooms(CsgCombiner3D roomA, CsgCombiner3D roomB) {
            Marker3D? roomASocket = AvailableSocketsFrom(roomA).FirstOrDefault();
            Marker3D? roomBSocket = AvailableSocketsFrom(roomB).FirstOrDefault();

            if (roomASocket is not null && roomBSocket is not null) {
                var wallRoomA = roomASocket.GetParent<CsgBox3D>();
                var wallRoomB = roomBSocket.GetParent<CsgBox3D>();

                var rotationToAlignRooms = _wallRotations[wallRoomB.Name.ToString()][wallRoomA.Name.ToString()];

                roomB.RotateY(rotationToAlignRooms - (-roomA.Rotation.Y)); // This -room calculation adapts the rotation relatively to last room
                roomB.GlobalTranslate(roomASocket.GlobalPosition - roomBSocket.GlobalPosition);

                roomASocket.SetMeta("connected", true);
                roomBSocket.SetMeta("connected", true);
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


        public IEnumerable<CsgBox3D> WallsFromRoom(CsgCombiner3D room)
            => room.GetChildren()
                    .Where(child => child.Name.ToString().Contains("wall", StringComparison.OrdinalIgnoreCase) && child.GetChildCount() == 0)
                    .Cast<CsgBox3D>();

        public void CreateDoorSlotInRandomWall(CsgCombiner3D roomParent, Vector3 roomSize, int socketNumber = 1) {
            IEnumerable<CsgBox3D> availableWalls = WallsFromRoom(roomParent);

            if (availableWalls.Any())
                CreateDoorSlotInWall(availableWalls.RandomElement(), roomSize, socketNumber);
        }

        public void CreateDoorSlotInWall(CsgBox3D wall, Vector3 roomSize, int socketNumber = 1) {
            if (wall.GetChildCount().IsZero()) {

                Vector3 doorPosition = new(0, Vector3.Down.Y * ((roomSize.Y / 2) - (DoorSize.Y / 2)), 0);
                Vector3 doorRotation = new(0, Regex.IsMatch(wall.Name.ToString(), "(front|back)", RegexOptions.IgnoreCase) ? 0 : Mathf.Pi / 2, 0);

                if (RandomizeDoorPositionInWall) {
                    if (doorRotation.Y != 0 && (wall.Size.Z - DoorSize.X) > DoorSize.X) {
                        doorPosition.Z = (_rng.Chance(0.5f) ? -1 : 1) * _rng.NextFloat(DoorSize.X, (wall.Size.Z - DoorSize.X) / 2);
                    }

                    if (doorRotation.Y == 0 && (wall.Size.X - DoorSize.X) > DoorSize.X) {
                        doorPosition.X = (_rng.Chance(0.5f) ? -1 : 1) * _rng.NextFloat(DoorSize.X, (wall.Size.X - DoorSize.X) / 2);

                    }
                }

                CsgBox3D doorSlot = new() {
                    Name = "DoorSlot",
                    Operation = CsgShape3D.OperationEnum.Subtraction,
                    Size = DoorSize,
                    Position = doorPosition,
                    Rotation = doorRotation
                };

                wall.AddChild(doorSlot);
                doorSlot.SetOwnerToEditedSceneRoot();

                Marker3D roomSocket = new() {
                    Name = $"RoomSocket{socketNumber}",
                    Position = new Vector3(doorSlot.Position.X, Math.Min((doorSlot.Position.Y + DoorSize.Y / 2) + 0.1f, roomSize.Y), doorSlot.Position.Z),
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

        private void NameSurfacesOnMesh(CsgCombiner3D room, MeshInstance3D roomMeshInstance) {
            for (int i = 0; i < roomMeshInstance.Mesh.GetSurfaceCount(); i++) {
                if (room.GetChildOrNull<CsgBox3D>(i) is CsgBox3D roomPart) {
                    ((ArrayMesh)roomMeshInstance.Mesh).SurfaceSetName(i, roomPart.Name);
                }
            }
        }

        private void GenerateCollisionsOnRoomMesh(MeshInstance3D roomMeshInstance) {
            if (GenerateCollisions) {
                switch (TypeOfCollision) {
                    case AvailableCollisions.Convex:
                        var convexCollision = new CollisionShape3D() {
                            Name = "ConvexCollision",
                            Shape = roomMeshInstance.Mesh.CreateConvexShape(CleanCollision, SimplifiedCollision)
                        };

                        if (CreateStaticBody) {
                            var body = new StaticBody3D() { Name = "StaticBody3D" };
                            roomMeshInstance.AddChild(body);
                            body.SetOwnerToEditedSceneRoot();
                            body.AddChild(convexCollision);

                        }
                        else {
                            roomMeshInstance.AddChild(convexCollision);
                        }

                        convexCollision.SetOwnerToEditedSceneRoot();

                        break;
                    case AvailableCollisions.Trimesh:
                        var trimeshCollision = new CollisionShape3D() {
                            Name = "TrimeshCollision",
                            Shape = roomMeshInstance.Mesh.CreateTrimeshShape()
                        };

                        if (CreateStaticBody) {
                            var body = new StaticBody3D() { Name = "StaticBody3D" };
                            roomMeshInstance.AddChild(body);
                            body.SetOwnerToEditedSceneRoot();
                            body.AddChild(trimeshCollision);
                            trimeshCollision.SetOwnerToEditedSceneRoot();
                        }
                        else {
                            roomMeshInstance.AddChild(trimeshCollision);
                        }

                        trimeshCollision.SetOwnerToEditedSceneRoot();

                        break;
                }
            }
        }

        private void GenerateRoomMeshes() {
            if (ToolCanBeUsed() && ((GenerateMeshPerRoom && CSGNode3DRoot is not null && CSGNode3DRoot.GetChildCount() > 0) || (!GenerateMeshPerRoom && CsgCombinerRoot is not null && CsgCombinerRoot.IsRootShape() && CsgCombinerRoot.GetChildCount() > 0))) {

                if (MeshOutputNode is not null) {
                    MeshOutputNode.Free();
                    MeshOutputNode = null;
                }

                MeshOutputNode = new Node3D() { Name = nameof(MeshOutputNode) };
                AddChild(MeshOutputNode);
                MeshOutputNode.SetOwnerToEditedSceneRoot();

                if (GenerateMeshPerRoom) {

                    foreach (CsgCombiner3D room in CSGNode3DRoot.GetChildren().Where(child => child is CsgCombiner3D).Cast<CsgCombiner3D>()) {
                        var roomMesh = room.GetMeshes();

                        if (roomMesh.Count > 1) {
                            var roomMeshInstance = new MeshInstance3D {
                                Name = room.Name,
                                Mesh = (Mesh)roomMesh[1],
                                Position = room.Position,
                                Rotation = room.Rotation
                            };

                            MeshOutputNode.AddChild(roomMeshInstance);
                            roomMeshInstance.SetOwnerToEditedSceneRoot();

                            NameSurfacesOnMesh(room, roomMeshInstance);
                            GenerateCollisionsOnRoomMesh(roomMeshInstance);
                        }

                    }
                }
                else {
                    var meshes = CsgCombinerRoot.GetMeshes();

                    if (meshes.Count > 1) {
                        var meshInstance = new MeshInstance3D {
                            Name = "GeneratedRoomMesh",
                            Mesh = (Mesh)meshes[1]
                        };

                        MeshOutputNode.AddChild(meshInstance);
                        meshInstance.SetOwnerToEditedSceneRoot();

                        NameSurfacesOnMesh(CsgCombinerRoot, meshInstance);
                        GenerateCollisionsOnRoomMesh(meshInstance);
                    }

                }
            }
        }

        private void ClearRoomsInSceneTree() {
            if (ToolCanBeUsed()) {

                foreach (var child in GetChildren())
                    child.Free();

                CsgCombinerRoot = null;
                CSGNode3DRoot = null;
                MeshOutputNode = null;
                CurrentLastRoom = null;
            }
        }

        private bool ToolCanBeUsed() => Engine.IsEditorHint() && IsInsideTree() || (!Engine.IsEditorHint() && IsNodeReady());
    }
}