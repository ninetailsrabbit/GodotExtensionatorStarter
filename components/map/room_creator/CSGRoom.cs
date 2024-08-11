using Extensionator;
using Godot;
using GodotExtensionator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace GodotExtensionatorStarter {
    [Tool]
    public partial class CSGRoom : CsgCombiner3D {
        [Export] public Vector3 RoomSize { get; set; } = Vector3.Zero; // Vector3(width, height, deep)
        [Export] public Vector3 DoorSize = new(1.5f, 2f, 0.25f);
        [Export(PropertyHint.Range, "1, 4, 1")] public int NumberOfDoors = 1;
        [Export] public bool RandomizeDoorPositionInWall = false;

        [Export] public float WallThickness = 0.15f;
        [Export] public float CeilThickness = 0.1f;
        [Export] public float FloorThickness = 0.1f;
        [Export] public bool IsBridgeRoomConnector = false;
        [Export] public bool GenerateMaterials = true;
        [Export] public bool IncludeCeil = true;
        [Export] public bool IncludeFloor = true;
        [Export] public bool IncludeRightWall = true;
        [Export] public bool IncludeLeftWall = true;
        [Export] public bool IncludeFrontWall = true;
        [Export] public bool IncludeBackWall = true;
        public CsgBox3D Floor { get; set; } = default!;
        public CsgBox3D Ceil { get; set; } = default!;
        public CsgBox3D FrontWall { get; set; } = default!;
        public CsgBox3D BackWall { get; set; } = default!;
        public CsgBox3D LeftWall { get; set; } = default!;
        public CsgBox3D RightWall { get; set; } = default!;

        public CsgBox3D[] DoorSlots = [];

        private readonly Random _rng = new();

        public override void _EnterTree() {
            if (GetChildCount().IsZero() && RoomSize.IsNotZeroApprox())
                Build();
        }

        public void Build() {
            this.SetOwnerToEditedSceneRoot();

            if (IsBridgeRoomConnector)
                Name = $"BridgeConnector{Name}";

            if (IncludeFloor)
                CreateFloor(RoomSize);

            if (IncludeCeil)
                CreateCeil(RoomSize);

            if (IncludeFrontWall)
                CreateFrontWall(RoomSize);

            if (IncludeBackWall)
                CreateBackWall(RoomSize);

            if (IncludeLeftWall)
                CreateLeftWall(RoomSize);

            if (IncludeRightWall)
                CreateRightWall(RoomSize);

            if (IsBridgeRoomConnector) {
                CreateDoorSlotInWall(FrontWall, RoomSize, DoorSize, 1);
                CreateDoorSlotInWall(BackWall, RoomSize, DoorSize, 2);
            }
            else {
                for (int i = 0; i < NumberOfDoors; i++) {
                    CreateDoorSlotInRandomWall(RoomSize, DoorSize, i);
                }
            }

            CreateMaterialsOnRoom();
        }

        public MeshInstance3D? GenerateMeshInstance() {
            var meshes = GetMeshes();

            if (meshes.Count > 1) {
                return new MeshInstance3D {
                    Name = Name,
                    Mesh = (Mesh)meshes[1],
                    Position = Position,
                    Rotation = Rotation
                };
            }

            return null;
        }

        #region Getters
        public IEnumerable<CsgBox3D> Walls() {
            List<CsgBox3D> walls = [FrontWall, BackWall, RightWall, LeftWall];

            return walls.RemoveNullables();
        }

        public IEnumerable<Marker3D> AvailableSockets() {
            return FindChildren("*", typeof(Marker3D).Name)
               .Where(socket => IsInstanceValid(socket) && !(bool)socket.GetMeta("connected"))
               .Cast<Marker3D>();
        }
        #endregion

        #region Doors

        public CsgBox3D? GetDoorSlotFromWall(CsgBox3D wall) {
            if (wall is not null && wall.GetNode<CsgBox3D>("DoorSlot") is CsgBox3D doorSlot)
                return doorSlot;

            return null;
        }
        public void CreateDoorSlotInRandomWall(Vector3 roomSize, Vector3 doorSize, int socketNumber = 1) {
            IEnumerable<CsgBox3D> availableWalls = Walls()
                .Where(wall => wall.Name.ToString().Contains("wall", StringComparison.OrdinalIgnoreCase) && wall.GetChildCount().IsZero());

            if (availableWalls.Any())
                CreateDoorSlotInWall(availableWalls.RandomElement(), roomSize, doorSize, socketNumber);
        }

        public void CreateDoorSlotInWall(CsgBox3D wall, Vector3 roomSize, Vector3 doorSize, int socketNumber = 1) {
            if (wall.GetChildCount().IsZero()) {

                Vector3 doorPosition = new(0, Vector3.Down.Y * ((roomSize.Y / 2) - (doorSize.Y / 2)), 0);
                Vector3 doorRotation = new(0, FrontBackWallsRegex().IsMatch(wall.Name.ToString()) ? 0 : Mathf.Pi / 2, 0);

                if (RandomizeDoorPositionInWall) {
                    if (doorRotation.Y != 0 && (wall.Size.Z - doorSize.X) > doorSize.X) {
                        doorPosition.Z = (_rng.Chance(0.5f) ? -1 : 1) * _rng.NextFloat(doorSize.X, (wall.Size.Z - doorSize.X) / 2);
                    }

                    if (doorRotation.Y == 0 && (wall.Size.X - doorSize.X) > doorSize.X) {
                        doorPosition.X = (_rng.Chance(0.5f) ? -1 : 1) * _rng.NextFloat(doorSize.X, (wall.Size.X - doorSize.X) / 2);

                    }
                }

                CsgBox3D doorSlot = new() {
                    Name = $"{wall.Name}DoorSlot",
                    Operation = OperationEnum.Subtraction,
                    Size = doorSize,
                    Position = doorPosition,
                    Rotation = doorRotation
                };

                wall.AddChild(doorSlot);
                doorSlot.SetOwnerToEditedSceneRoot();

                Marker3D roomSocket = new() {
                    Name = $"RoomSocket{socketNumber}",
                    Position = new Vector3(doorSlot.Position.X, Math.Min((doorSlot.Position.Y + doorSize.Y / 2) + 0.1f, roomSize.Y), doorSlot.Position.Z),
                };

                roomSocket.SetMeta("connected", false);

                wall.AddChild(roomSocket);
                roomSocket.SetOwnerToEditedSceneRoot();


            }
        }
        #endregion

        #region Room creation
        private void CreateFloor(Vector3 roomSize) {
            Floor ??= new() {
                Name = nameof(Floor),
                Size = new Vector3(roomSize.X + FloorThickness * 2, FloorThickness, roomSize.Z + FloorThickness * 2),
                Position = Vector3.Zero
            };

            AddChild(Floor);

            Floor.SetOwnerToEditedSceneRoot();
        }

        private void CreateCeil(Vector3 roomSize) {
            Ceil ??= new() {
                Name = nameof(Ceil),
                Size = new Vector3(roomSize.X + CeilThickness * 2, CeilThickness, roomSize.Z + CeilThickness * 2),
                Position = Position with { X = 0, Y = Mathf.Max(roomSize.Y, (roomSize.Y + CeilThickness) - roomSize.Y / 2.5f), Z = 0 }
            };

            AddChild(Ceil);

            Ceil.SetOwnerToEditedSceneRoot();
        }

        private void CreateFrontWall(Vector3 roomSize) {
            FrontWall ??= new() {
                Name = nameof(FrontWall),
                Size = new Vector3(roomSize.X, roomSize.Y, WallThickness),
                Position = Position with { X = 0, Y = roomSize.Y / 2, Z = Mathf.Min(-roomSize.Z / 2, -(roomSize.Z + WallThickness) / 2.5f) }
            };

            AddChild(FrontWall);

            FrontWall.SetOwnerToEditedSceneRoot();
        }

        public void CreateBackWall(Vector3 roomSize) {
            BackWall ??= new() {
                Name = nameof(BackWall),
                Size = new Vector3(roomSize.X, roomSize.Y, WallThickness),
                Position = Position with { X = 0, Y = roomSize.Y / 2, Z = Mathf.Max(roomSize.Z / 2, (roomSize.Z + WallThickness) / 2.5f) }
            };

            AddChild(BackWall);

            BackWall.SetOwnerToEditedSceneRoot();
        }


        public void CreateRightWall(Vector3 roomSize) {
            RightWall ??= new() {
                Name = nameof(RightWall),
                Size = new Vector3(WallThickness, roomSize.Y, roomSize.Z),
                Position = Position with { X = Mathf.Max(roomSize.X / 2, (roomSize.X + WallThickness) / 2.5f), Y = roomSize.Y / 2, Z = 0 }
            };

            AddChild(RightWall);

            RightWall.SetOwnerToEditedSceneRoot();
        }

        public void CreateLeftWall(Vector3 roomSize) {
            LeftWall ??= new() {
                Name = nameof(LeftWall),
                Size = new Vector3(WallThickness, roomSize.Y, roomSize.Z),
                Position = Position with { X = Mathf.Min(-roomSize.X / 2, -(roomSize.X + WallThickness) / 2.5f), Y = roomSize.Y / 2, Z = 0 }
            };

            AddChild(LeftWall);

            LeftWall.SetOwnerToEditedSceneRoot();
        }

        private void CreateMaterialsOnRoom() {
            if (GenerateMaterials)
                foreach (var csgShape in this.GetAllChildren<CsgBox3D>())
                    csgShape.Material = new StandardMaterial3D();
        }
        #endregion

        [GeneratedRegex("(front|back)", RegexOptions.IgnoreCase, "en-GB")]
        private static partial Regex FrontBackWallsRegex();
    }

}