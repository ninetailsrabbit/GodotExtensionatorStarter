using Extensionator;
using Godot;
using System.Collections.Generic;

namespace GodotExtensionatorStarter {
    [Tool]
    public partial class RoomMesh : MeshInstance3D {
        public ArrayMesh RoomMeshShape { get; set; } = null!;
        public Material FloorMaterial { get; set; } = default!;
        public Material CeilMaterial { get; set; } = default!;

        #region Walls
        public Material FrontWallMaterial { get; set; } = default!;
        public Material BackWallMaterial { get; set; } = default!;
        public Material LeftWallMaterial { get; set; } = default!;
        public Material RightWallMaterial { get; set; } = default!;
        #endregion

        #region Door slots
        public Material FrontWallDoorSlotMaterial { get; set; } = default!;
        public Material BackWallDoorSlotMaterial { get; set; } = default!;
        public Material RightWallDoorSlotMaterial { get; set; } = default!;
        public Material LeftWallDoorSlotMaterial { get; set; } = default!;
        #endregion

        public override void _EnterTree() {
            RoomMeshShape = (ArrayMesh)Mesh;

            if (!Engine.IsEditorHint()) {
                UpdateRoomMaterials();
            }
        }

        public IEnumerable<Material> WallMaterials() {
            List<Material> wallMaterials = [FrontWallMaterial, BackWallMaterial, RightWallMaterial, LeftWallMaterial];

            return wallMaterials.RemoveNullables();
        }

        public IEnumerable<Material> DoorSlotsMaterials() {
            List<Material> doorSlotMaterials = [FrontWallDoorSlotMaterial, BackWallDoorSlotMaterial, RightWallDoorSlotMaterial, LeftWallDoorSlotMaterial];

            return doorSlotMaterials.RemoveNullables();
        }

        public Material? GetSurfaceMaterial(string name) {
            int surfaceIndex = RoomMeshShape.SurfaceFindByName(name);

            return surfaceIndex == -1 ? null : RoomMeshShape.SurfaceGetMaterial(surfaceIndex);
        }

        public RoomMesh ChangeMaterialOnFloor(Material newMaterial) {
            FloorMaterial = newMaterial;

            return this;
        }

        public void ChangeMaterialOnCeil(Material newMaterial) {
            CeilMaterial = newMaterial;
        }
        public RoomMesh ChangeMaterialOnWalls(Material newMaterial) {
            if (RightWallMaterial is not null)
                RightWallMaterial = newMaterial;

            if (LeftWallMaterial is not null)
                LeftWallMaterial = newMaterial;

            if (FrontWallMaterial is not null)
                FrontWallMaterial = newMaterial;

            if (BackWallMaterial is not null)
                BackWallMaterial = newMaterial;

            return this;

        }

        public RoomMesh ChangeMaterialOnDoorSlots(Material newMaterial) {
            if (RightWallDoorSlotMaterial is not null)
                RightWallDoorSlotMaterial = newMaterial;

            if (LeftWallDoorSlotMaterial is not null)
                LeftWallDoorSlotMaterial = newMaterial;

            if (FrontWallDoorSlotMaterial is not null)
                FrontWallDoorSlotMaterial = newMaterial;

            if (BackWallDoorSlotMaterial is not null)
                BackWallDoorSlotMaterial = newMaterial;

            return this;

        }

        private void UpdateRoomMaterials() {
            RoomMeshShape ??= (ArrayMesh)Mesh;

            FloorMaterial = GetSurfaceMaterial("Floor");
            CeilMaterial = GetSurfaceMaterial("Ceil");
            FrontWallMaterial = GetSurfaceMaterial("FrontWall");
            BackWallMaterial = GetSurfaceMaterial("BackWall");
            LeftWallMaterial = GetSurfaceMaterial("LeftWall");
            RightWallMaterial = GetSurfaceMaterial("RightWall");

            RightWallDoorSlotMaterial = GetSurfaceMaterial("RightWallDoorSlot");
            LeftWallDoorSlotMaterial = GetSurfaceMaterial("LeftWallDoorSlot");
            FrontWallDoorSlotMaterial = GetSurfaceMaterial("FrontWallDoorSlot");
            BackWallDoorSlotMaterial = GetSurfaceMaterial("BackWallDoorSlot");
        }

    }
}
