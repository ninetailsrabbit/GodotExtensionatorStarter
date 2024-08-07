using Extensionator;
using Godot;
using GodotExtensionator;
using System;
using System.ComponentModel;


namespace GodotExtensionatorStarter {
    [Tool]
    public partial class RoomCreator : Node3D {
        [Export] public CsgCombiner3D CSGCombinerRoot { get; set; } = null!;
        [Export] public bool CreateNewRoom { get => _createNewRoom; set { CreateRoom(); } } // Tool button
        [Export] public bool ClearRoom { get => _clearRoom; set { ClearExistingRoom(); } } // Tool button
        [Export] public bool GenerateFinalMesh { get => _generateFinalMesh; set { GenerateRoomMesh(); } } // Tool button
        [Export] public Node3D MeshOutputNode { get; set; } = null!;
        [ExportGroup("Include in generation")]
        [Export] public bool GenerateMaterials = true;
        [Export] public bool IncludeCeil = true;
        [Export] public bool IncludeFloor = true;
        [Export] public bool IncludeRightWall = true;
        [Export] public bool IncludeLeftWall = true;
        [Export] public bool IncludeFrontWall = true;
        [Export] public bool IncludeBackWall = true;
        [ExportGroup("Collisions")]
        [Export] public bool IncludeCeilCollisions = true;
        [Export] public bool IncludeFloorCollisions = true;
        [Export] public bool IncludeRightWallCollisions = true;
        [Export] public bool IncludeLeftWallCollisions = true;
        [Export] public bool IncludeFrontWallCollisions = true;
        [Export] public bool IncludeBackWallCollisions = true;

        [ExportGroup("Sizes")]
        [Export]
        public Vector3 RoomSize {
            get => _roomSize;
            set {
                if (_roomSize != value) {
                    _roomSize = value;
                    CreateRoom();
                }
            }
        }
        [Export]
        public float WallThickness {
            get => _wallThickness;
            set {
                if (_wallThickness != value) {
                    _wallThickness = value;
                    CreateRoom();
                }
            }
        }
        [Export]
        public float CeilThickness {
            get => _ceilThickness;
            set {
                if (_ceilThickness != value) {
                    _ceilThickness = value;
                    CreateRoom();
                }
            }
        }
        [Export]
        public float FloorThickness {
            get => _floorThickness;
            set {
                if (_floorThickness != value) {
                    _floorThickness = value;
                    CreateRoom();
                }
            }
        }

        private bool _createNewRoom = false;
        private bool _clearRoom = false;
        private bool _generateFinalMesh = false;

        private Vector3 _roomSize = new(6f, 3.5f, 5f);
        private float _wallThickness = 0.15f;
        private float _ceilThickness = 0.1f;
        private float _floorThickness = 0.1f;

        public event PropertyChangedEventHandler? PropertyChanged;

        public override void _EnterTree() {
            CSGCombinerRoot ??= GetNode<CsgCombiner3D>(nameof(CsgCombiner3D));
            MeshOutputNode ??= GetNode<Node3D>(nameof(MeshOutputNode));

            ArgumentNullException.ThrowIfNull(CSGCombinerRoot);
            ArgumentNullException.ThrowIfNull(MeshOutputNode);

            CSGCombinerRoot.SetOwnerToEditedSceneRoot();
            MeshOutputNode.SetOwnerToEditedSceneRoot();
        }

        public override void _Ready() {
            if (!Engine.IsEditorHint())
                QueueFree();

        }

        public void CreateRoom() {
            if (ToolCanBeUsed()) {

                ClearExistingRoom();
                CreateFloor();
                CreateCeil();
                CreateFrontWall();
                CreateBackWall();
                CreateRightWall();
                CreateLeftWall();
                CreateMaterialOnExistingCSGShapes();
            }

        }

        public void GenerateRoomMesh() {
            if (ToolCanBeUsed() && CSGCombinerRoot.IsRootShape() && CSGCombinerRoot.GetChildCount().IsGreaterThanZero()) {
                var meshes = CSGCombinerRoot.GetMeshes();

                var meshInstance = new MeshInstance3D {
                    Name = "GeneratedRoomMesh",
                    Mesh = (Mesh)meshes[1]
                };

                MeshOutputNode.AddChild(meshInstance);
                meshInstance.SetOwnerToEditedSceneRoot();

                for (int i = 0; i < meshInstance.Mesh.GetSurfaceCount(); i++) {
                    if (CSGCombinerRoot.GetChildOrNull<CsgBox3D>(i) is CsgBox3D roomPart) {
                        ((ArrayMesh)meshInstance.Mesh).SurfaceSetName(i, roomPart.Name);
                    }
                }
            }

        }

        public void CreateMaterialOnExistingCSGShapes() {
            if (GenerateMaterials) {
                foreach (var csgShape in CSGCombinerRoot.GetAllChildren<CsgBox3D>()) {
                    csgShape.Material = new StandardMaterial3D();
                }
            }

        }

        public void CreateFloor() {
            if (IncludeFloor) {
                CsgBox3D floor = new() {
                    Name = "Floor",
                    Size = new Vector3(RoomSize.X, FloorThickness, RoomSize.Z),
                    Position = Position with { Y = 0 }
                };

                CSGCombinerRoot.AddChild(floor);

                floor.SetOwnerToEditedSceneRoot();
            }

        }

        public void CreateCeil() {
            if (IncludeCeil) {
                CsgBox3D ceil = new() {
                    Name = "Ceil",
                    Size = new Vector3(RoomSize.X, CeilThickness, RoomSize.Z),
                    Position = Position with { Y = Mathf.Max(RoomSize.Y, (RoomSize.Y + CeilThickness) - RoomSize.Y / 2.5f) }
                };

                CSGCombinerRoot.AddChild(ceil);

                ceil.SetOwnerToEditedSceneRoot();
            }
        }

        public void CreateFrontWall() {
            if (IncludeFrontWall) {
                CsgBox3D frontWall = new() {
                    Name = "FrontWall",
                    Size = new Vector3(RoomSize.X, RoomSize.Y, WallThickness),
                    Position = Position with { X = 0, Y = RoomSize.Y / 2, Z = Mathf.Min(-RoomSize.Z / 2, -(RoomSize.Z + WallThickness) / 2.5f) }
                };

                CSGCombinerRoot.AddChild(frontWall);

                frontWall.SetOwnerToEditedSceneRoot();
            }
        }

        public void CreateBackWall() {
            if (IncludeBackWall) {
                CsgBox3D backWall = new() {
                    Name = "BackWall",
                    Size = new Vector3(RoomSize.X, RoomSize.Y, WallThickness),
                    Position = Position with { X = 0, Y = RoomSize.Y / 2, Z = Mathf.Max(RoomSize.Z / 2, (RoomSize.Z + WallThickness) / 2.5f) }
                };

                CSGCombinerRoot.AddChild(backWall);

                backWall.SetOwnerToEditedSceneRoot();
            }
        }

        public void CreateRightWall() {
            if (IncludeRightWall) {

                CsgBox3D rightWall = new() {
                    Name = "RightWall",
                    Size = new Vector3(WallThickness, RoomSize.Y, RoomSize.Z),
                    Position = Position with { X = Mathf.Max(RoomSize.X / 2, (RoomSize.X + WallThickness) / 2.5f), Y = RoomSize.Y / 2, Z = 0 }
                };

                CSGCombinerRoot.AddChild(rightWall);

                rightWall.SetOwnerToEditedSceneRoot();
            }
        }

        public void CreateLeftWall() {
            if (IncludeLeftWall) {
                CsgBox3D leftWall = new() {
                    Name = "LeftWall",
                    Size = new Vector3(WallThickness, RoomSize.Y, RoomSize.Z),
                    Position = Position with { X = Mathf.Min(-RoomSize.X / 2, -(RoomSize.X + WallThickness) / 2.5f), Y = RoomSize.Y / 2, Z = 0 }
                };

                CSGCombinerRoot.AddChild(leftWall);

                leftWall.SetOwnerToEditedSceneRoot();
            }
        }


        public void ClearExistingRoom() {
            if (ToolCanBeUsed()) {
                var nodesToDelete = CSGCombinerRoot.GetAllChildren();
                nodesToDelete.AddRange(MeshOutputNode.GetAllChildren());

                foreach (var child in nodesToDelete)
                    child.Free();
            }
        }

        private bool ToolCanBeUsed() => Engine.IsEditorHint() && IsInsideTree() && CSGCombinerRoot is not null && MeshOutputNode is not null;
    }
}