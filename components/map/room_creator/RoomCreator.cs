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
    public partial class MeshRoom : MeshInstance3D {

        public ArrayMesh RoomMesh { get; set; } = null!;
        public Material FloorMaterial { get; set; } = default!;
        public Material? GetFloorMaterial() => RoomMesh.SurfaceGetMaterial(0);

        public override void _EnterTree() {

        }
        public void ApplyMaterialOnFloor(Material newMaterial) {
            var material = RoomMesh.SurfaceGetMaterial(0);

            material = newMaterial;
        }


    }

    [Tool]
    public partial class RoomCreator : Node3D {

        [Signal]
        public delegate void RequestedGenerateRoomChunkEventHandler(int amount);
        [Signal]
        public delegate void GeneratedRoomChunkEventHandler(Array<MeshInstance3D> chunk);

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

        public List<MeshInstance3D> RoomsCreated = [];

        private CsgCombiner3D? CsgCombinerRoot { get; set; } = default!;
        private Node3D? CSGNode3DRoot { get; set; } = default!;
        private CSGRoom? CurrentLastRoom { get; set; } = default!;
        private CSGRoom? LastRoomGeneratedFromChunk { get; set; } = default!;
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

                var rootNode = GenerateMeshPerRoom ? CSGNode3DRoot : CsgCombinerRoot;

                int numberOfRooms = CalculateNumberOfRooms(UseBridgeConnectorsBetweenRooms);

                for (int i = 0; i < numberOfRooms; i++) {
                    bool isBridgeConnector = UseBridgeConnectorsBetweenRooms && i % 2 != 0;

                    var room = new CSGRoom() {
                        Name = $"Room{CsgCombinerRoot?.GetChildCount()}{CSGNode3DRoot?.GetChildCount()}",
                        Position = CurrentLastRoom?.Position ?? Vector3.Zero,
                        UseCollision = false,
                        IsBridgeRoomConnector = isBridgeConnector,
                        RoomSize = isBridgeConnector ? GenerateRoomSizeBasedOnRange(MinBridgeConnectorSize, MaxBridgeConnectorSize) : GenerateRoomSizeBasedOnRange(MinRoomSize, MaxRoomSize),
                        DoorSize = DoorSize,
                        NumberOfDoors = CurrentLastRoom is null ? 1 : DoorsPerRoom,
                        RandomizeDoorPositionInWall = RandomizeDoorPositionInWall,
                        IncludeFloor = IncludeFloor,
                        IncludeCeil = IncludeCeil,
                        IncludeBackWall = IncludeBackWall,
                        IncludeFrontWall = IncludeFrontWall,
                        IncludeLeftWall = IncludeLeftWall,
                        IncludeRightWall = IncludeRightWall,
                        GenerateMaterials = GenerateMaterials
                    };

                    rootNode?.AddChild(room);

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

        private void NameSurfacesOnCombinedMesh(CsgCombiner3D rootNodeForRooms, MeshInstance3D roomMeshInstance) {
            int index = 0;

            foreach (var room in rootNodeForRooms.GetChildren().Where(child => child is CSGRoom).Cast<CSGRoom>()) {

                foreach (var entry in room.MaterialsByRoomPart) {
                    ((ArrayMesh)roomMeshInstance.Mesh).SurfaceSetName(index, entry.Key.Name);
                    index += 1;
                }

            }


        }

        private void NameSurfacesOnRoomMesh(CSGRoom room, MeshInstance3D roomMeshInstance) {
            foreach (var entry in room.MaterialsByRoomPart)
                ((ArrayMesh)roomMeshInstance.Mesh).SurfaceSetName(entry.Value, entry.Key.Name);
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

                if (GenerateMeshPerRoom) {

                    MeshOutputNode ??= new Node3D() { Name = nameof(MeshOutputNode) };
                    AddChild(MeshOutputNode);
                    MeshOutputNode.SetOwnerToEditedSceneRoot();

                    foreach (CSGRoom room in CSGNode3DRoot.GetChildren().Where(child => child is CSGRoom).Cast<CSGRoom>()) {

                        if (room.GenerateMeshInstance() is MeshInstance3D roomMeshInstance) {
                            MeshOutputNode.AddChild(roomMeshInstance);
                            roomMeshInstance.SetOwnerToEditedSceneRoot();

                            NameSurfacesOnRoomMesh(room, roomMeshInstance);
                            GenerateCollisionsOnRoomMesh(roomMeshInstance);

                            RoomsCreated.Add(roomMeshInstance);
                        }
                    }
                }
                else {
                    MeshOutputNode?.Free();
                    MeshOutputNode = new Node3D() { Name = nameof(MeshOutputNode) };
                    AddChild(MeshOutputNode);
                    MeshOutputNode.SetOwnerToEditedSceneRoot();

                    var meshes = CsgCombinerRoot.GetMeshes();

                    if (meshes.Count > 1) {
                        var meshInstance = new MeshInstance3D {
                            Name = "GeneratedRoomMesh",
                            Mesh = (Mesh)meshes[1]
                        };

                        MeshOutputNode.AddChild(meshInstance);
                        meshInstance.SetOwnerToEditedSceneRoot();

                        NameSurfacesOnCombinedMesh(CsgCombinerRoot, meshInstance);
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
