using Extensionator;
using Godot;
using Godot.Collections;
using GodotExtensionator;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GodotExtensionatorStarter {

    [Tool]
    [GlobalClass, Icon("res://components/map/room_creator/room_creator.svg")]
    public partial class RoomCreator : Node3D {
        [Signal]
        public delegate void CreatedCSGRoomsEventHandler(Array<CSGRoom> newRooms);
        [Signal]
        public delegate void CreatedRoomsEventHandler(Array<RoomMesh> newRooms);

        [ExportGroup("Tool buttons")]
        [Export] public bool CreateNewRoom { get => _createNewRoom; set { CreateCSGRooms(); } } // Tool button
        [Export] public bool GenerateFinalMesh { get => _generateFinalMesh; set { GenerateRoomsMeshes(); } } // Tool button
        [Export] public bool ClearGeneratedRooms { get => _clearRoom; set { ClearRoomsInSceneTree(); } } // Tool button
        [Export] public bool ClearLastGeneratedRooms { get => _clearLastGeneratedRooms; set { ClearLastGeneratedRoomsInSceneTree(); } } // Tool button
        [Export] public RoomParameters RoomParameters { get; set; } = default!;
        [ExportGroup("Include in generation")]
        [Export] public bool GenerateMeshPerRoom = true;
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

        public List<CSGRoom> CSGRoomsCreated = [];
        public List<RoomMesh> RoomsCreated = [];

        private Node3D? CSGRoomsOutputNode { get; set; } = default!;
        private Node3D? RoomMeshesOutputNode { get; set; } = default!;

        private bool _createNewRoom = false;
        private bool _clearRoom = false;
        private bool _clearLastGeneratedRooms = false;
        private bool _generateFinalMesh = false;

        // (Pi / 2) * wallRotation selected
        private readonly Godot.Collections.Dictionary<string, Godot.Collections.Dictionary<string, float>> _wallRotations = new() {
            { "FrontWall", new() { {"FrontWall", Mathf.Pi}, { "BackWall", 0f}, { "RightWall", Mathf.Pi / 2 }, { "LeftWall", -Mathf.Pi / 2 } } },
            { "BackWall", new() { {"FrontWall", 0f}, { "BackWall", Mathf.Pi }, { "RightWall", -Mathf.Pi / 2 }, { "LeftWall",  Mathf.Pi / 2 } } },
            { "RightWall", new() { {"FrontWall", -Mathf.Pi / 2}, { "BackWall",  Mathf.Pi / 2}, { "RightWall", Mathf.Pi }, { "LeftWall", 0f} } },
            { "LeftWall", new() { {"FrontWall",  Mathf.Pi / 2}, { "BackWall", -Mathf.Pi / 2}, { "RightWall", 0f}, { "LeftWall", Mathf.Pi } } },
        };

        private readonly Random _rng = new();

        public void CreateCSGRooms() {
            if (ToolCanBeUsed()) {

                if (CSGRoomsOutputNode is null) {
                    CSGRoomsOutputNode = new Node3D() { Name = nameof(CSGRoomsOutputNode) };
                    AddChild(CSGRoomsOutputNode);
                    CSGRoomsOutputNode.SetOwnerToEditedSceneRoot();
                }

                var rootNode = CSGRoomsOutputNode;

                if (!GenerateMeshPerRoom) {
                    CsgCombiner3D CSGCombinerRoot = CSGRoomsOutputNode.GetNodeOrNull<CsgCombiner3D>("CSGCombinerRoot") ??
                        new() { Name = "CSGCombinerRoot", UseCollision = false };

                    if (!CSGCombinerRoot.IsInsideTree()) {
                        CSGRoomsOutputNode.AddChild(CSGCombinerRoot);
                        CSGCombinerRoot.SetOwnerToEditedSceneRoot();
                    }

                    rootNode = CSGCombinerRoot;
                }

                int numberOfRooms = CalculateNumberOfRooms(RoomParameters.UseBridgeConnectorsBetweenRooms);

                for (int i = 0; i < numberOfRooms; i++) {
                    bool isBridgeConnector = RoomParameters.UseBridgeConnectorsBetweenRooms && CSGRoomsCreated.Count > 0 && !CSGRoomsCreated.Last().IsBridgeRoomConnector;

                    var room = new CSGRoom() {
                        Name = $"Room{CSGRoomsCreated.Count}",
                        Position = CSGRoomsCreated.Count > 0 ? CSGRoomsCreated.Last().Position : Vector3.Zero,
                        UseCollision = false,
                        IsBridgeRoomConnector = isBridgeConnector,
                        RoomSize = isBridgeConnector ?
                            GenerateRoomSizeBasedOnRange(RoomParameters.MinBridgeConnectorSize, RoomParameters.MaxBridgeConnectorSize) :
                            GenerateRoomSizeBasedOnRange(RoomParameters.MinRoomSize, RoomParameters.MaxRoomSize),
                        DoorSize = RoomParameters.DoorSize,
                        NumberOfDoors = CSGRoomsCreated.IsEmpty() ? 1 : RoomParameters.DoorsPerRoom,
                        RandomizeDoorPositionInWall = RoomParameters.RandomizeDoorPositionInWall,
                        IncludeFloor = IncludeFloor,
                        IncludeCeil = IncludeCeil,
                        IncludeBackWall = IncludeBackWall,
                        IncludeFrontWall = IncludeFrontWall,
                        IncludeLeftWall = IncludeLeftWall,
                        IncludeRightWall = IncludeRightWall,
                        GenerateMaterials = GenerateMaterials
                    };

                    rootNode.AddChild(room);

                    if (CSGRoomsCreated.Count > 0 && room is not null) {
                        ConnectRooms(CSGRoomsCreated.Last(), room);
                    }

                    CSGRoomsCreated.Add(room);
                }

                EmitSignal(SignalName.CreatedCSGRooms, new Array<CSGRoom>(CSGRoomsCreated.Skip(CSGRoomsCreated.Count - numberOfRooms).Take(numberOfRooms)));

            }
        }

        public int CalculateNumberOfRooms(bool useBridgeConnectors = false) {
            int numberOfRooms = RoomParameters.NumberOfRoomsPerGeneration;

            if (useBridgeConnectors) {
                numberOfRooms += (int)Mathf.Ceil(numberOfRooms / 2f);

                // When use bridge connectors the number of rooms always needs to be odd to fit the correct bridges amount
                if (numberOfRooms % 2 == 0)
                    numberOfRooms += 1;
            }

            return numberOfRooms;
        }

        public void ConnectRooms(CSGRoom roomA, CSGRoom roomB) {
            if (roomA.AvailableSockets().FirstOrDefault() is Marker3D roomASocket && roomB.AvailableSockets().FirstOrDefault() is Marker3D roomBSocket) {
                var wallRoomA = roomASocket.GetParent<CsgBox3D>();
                var wallRoomB = roomBSocket.GetParent<CsgBox3D>();

                var rotationToAlignRooms = _wallRotations[wallRoomB.Name.ToString()][wallRoomA.Name.ToString()];

                // This -room calculation adapts the rotation relatively to last room
                roomB.RotateY(rotationToAlignRooms - (-roomA.Rotation.Y));
                roomB.GlobalTranslate(roomASocket.GlobalPosition - roomBSocket.GlobalPosition);

                roomASocket.SetMeta("connected", true);
                roomBSocket.SetMeta("connected", true);
            }
        }

        public Vector3 GenerateRoomSizeBasedOnRange(Vector3? minRoomSize = null, Vector3? maxRoomSize = null) {
            minRoomSize ??= RoomParameters.MinRoomSize;
            maxRoomSize ??= RoomParameters.MaxRoomSize;

            if (minRoomSize.Value.IsEqualApprox(maxRoomSize.Value))
                return minRoomSize.Value;
            else
                return new Vector3(
                    _rng.NextFloat(minRoomSize.Value.X, maxRoomSize.Value.X),
                    _rng.NextFloat(minRoomSize.Value.Y, maxRoomSize.Value.Y),
                    _rng.NextFloat(minRoomSize.Value.Z, maxRoomSize.Value.Z));
        }

        private void NameSurfacesOnCombinedMesh(CsgCombiner3D rootNodeForRooms, MeshInstance3D roomMeshInstance) {
            int index = 0;

            foreach (var room in rootNodeForRooms.GetChildren().Where(child => child is CSGRoom).Cast<CSGRoom>()) {

                foreach (var entry in room.MaterialsByRoomPart) {
                    ((ArrayMesh)roomMeshInstance.Mesh).SurfaceSetName(index, entry.Key.Name);
                    index += 1;
                }

            }
        }

        private void NameSurfacesOnRoomMesh(CSGRoom room, RoomMesh roomMeshInstance) {
            foreach (var entry in room.MaterialsByRoomPart)
                ((ArrayMesh)roomMeshInstance.Mesh).SurfaceSetName(entry.Value, entry.Key.Name);
        }

        private void GenerateCollisionsOnRoomMesh(RoomMesh roomMeshInstance) {
            if (GenerateCollisions) {
                switch (TypeOfCollision) {
                    case AvailableCollisions.Convex:
                        var convexCollision = new CollisionShape3D() {
                            Name = $"{roomMeshInstance.Name}ConvexCollision",
                            Shape = roomMeshInstance.Mesh.CreateConvexShape(CleanCollision, SimplifiedCollision)
                        };

                        if (CreateStaticBody) {
                            var body = new StaticBody3D() { Name = $"{roomMeshInstance.Name}StaticBody3D" };
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
                            Name = $"{roomMeshInstance.Name}TrimeshCollision",
                            Shape = roomMeshInstance.Mesh.CreateTrimeshShape()
                        };

                        if (CreateStaticBody) {
                            var body = new StaticBody3D() { Name = $"{roomMeshInstance.Name}StaticBody3D" };
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

        public void GenerateRoomsMeshes() {
            if (ToolCanBeUsed()) {

                if (GenerateMeshPerRoom) {

                    RoomMeshesOutputNode ??= new Node3D() { Name = nameof(RoomMeshesOutputNode) };
                    AddChild(RoomMeshesOutputNode);
                    RoomMeshesOutputNode.SetOwnerToEditedSceneRoot();

                    var roomCreatedNames = RoomsCreated.Select(room => room.Name);
                    var newRooms = CSGRoomsCreated.Where(csgRoom => !roomCreatedNames.Contains(csgRoom.Name));

                    foreach (CSGRoom room in newRooms) {
                        if (room.GenerateMeshInstance() is RoomMesh roomMeshInstance) {

                            RoomMeshesOutputNode.AddChild(roomMeshInstance);
                            roomMeshInstance.SetOwnerToEditedSceneRoot();

                            NameSurfacesOnRoomMesh(room, roomMeshInstance);
                            GenerateCollisionsOnRoomMesh(roomMeshInstance);
                            RoomsCreated.Add(roomMeshInstance);
                        }
                    }

                    EmitSignal(SignalName.CreatedRooms, new Array<RoomMesh>(RoomsCreated.Skip(RoomsCreated.Count - newRooms.Count()).Take(newRooms.Count())));
                }
                else {
                    if (CSGRoomsOutputNode?.GetNode<CsgCombiner3D>("CSGCombinerRoot") is CsgCombiner3D csgCombinerRoot) {

                        RoomMeshesOutputNode?.Free();
                        RoomMeshesOutputNode = new Node3D() { Name = nameof(RoomMeshesOutputNode) };
                        AddChild(RoomMeshesOutputNode);
                        RoomMeshesOutputNode.SetOwnerToEditedSceneRoot();

                        var meshes = csgCombinerRoot.GetMeshes();

                        if (meshes.Count > 1) {
                            var roomMeshInstance = new RoomMesh {
                                Name = "GeneratedRoomMesh",
                                Mesh = (Mesh)meshes[1]
                            };

                            RoomMeshesOutputNode.AddChild(roomMeshInstance);
                            roomMeshInstance.SetOwnerToEditedSceneRoot();

                            NameSurfacesOnCombinedMesh(csgCombinerRoot, roomMeshInstance);
                            GenerateCollisionsOnRoomMesh(roomMeshInstance);
                        }

                    }

                }
            }
        }

        public void ClearRoomsInSceneTree() {
            if (ToolCanBeUsed()) {

                foreach (var child in GetChildren())
                    child.Free();

                CSGRoomsOutputNode = null;
                RoomMeshesOutputNode = null;

                CSGRoomsCreated.Clear();
                RoomsCreated.Clear();
            }
        }

        public void ClearLastGeneratedRoomsInSceneTree() {
            if (ToolCanBeUsed() && !CSGRoomsCreated.IsEmpty()) {

                var roomsToRemoveCount = RoomParameters.NumberOfRoomsPerGeneration + (RoomParameters.UseBridgeConnectorsBetweenRooms ? (int)Mathf.Ceil(RoomParameters.NumberOfRoomsPerGeneration / 2) : 0);

                var lastRoomsCreated = CSGRoomsCreated.Skip(Math.Max(0, CSGRoomsCreated.Count - roomsToRemoveCount));
                CSGRoomsCreated = CSGRoomsCreated.Take(Math.Max(0, CSGRoomsCreated.Count - roomsToRemoveCount)).ToList();

                foreach (var child in lastRoomsCreated)
                    child.Free();

            }
        }

        private bool ToolCanBeUsed() => RoomParameters is not null && ((Engine.IsEditorHint() && IsInsideTree()) || (!Engine.IsEditorHint() && IsNodeReady()));
    }
}
