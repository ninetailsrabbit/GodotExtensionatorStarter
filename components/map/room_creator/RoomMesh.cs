using Godot;

namespace GodotExtensionatorStarter {
    [Tool]
    public partial class RoomMesh : MeshInstance3D {
        #region Walls
        public ArrayMesh RoomMeshShape { get; set; } = null!;
        public Material FloorMaterial { get; set; } = default!;
        public Material CeilMaterial { get; set; } = default!;
        public Material FrontWallMaterial { get; set; } = default!;
        public Material BackWallMaterial { get; set; } = default!;
        public Material LeftWallMaterial { get; set; } = default!;
        public Material RightWallMaterial { get; set; } = default!;
        #endregion

        #region Door slots
        public Material FrontWallDoorSlootMaterial { get; set; } = default!;
        public Material BackWallDoorSlootMaterial { get; set; } = default!;
        public Material RightWallDoorSlootMaterial { get; set; } = default!;
        public Material LeftWallDoorSlootMaterial { get; set; } = default!;
        #endregion

        public override void _EnterTree() {
            RoomMeshShape = (ArrayMesh)Mesh;

            if (!Engine.IsEditorHint()) {
                UpdateRoomMaterials();
            }
        }

        public Material? GetSurfaceMaterial(string name) {
            int surfaceIndex = RoomMeshShape.SurfaceFindByName(name);

            return surfaceIndex == -1 ? null : RoomMeshShape.SurfaceGetMaterial(surfaceIndex);
        }

        public void UpdateRoomMaterials() {
            RoomMeshShape ??= (ArrayMesh)Mesh;

            FloorMaterial = GetSurfaceMaterial("Floor");
            CeilMaterial = GetSurfaceMaterial("Ceil");
            FrontWallMaterial = GetSurfaceMaterial("FrontWall");
            BackWallMaterial = GetSurfaceMaterial("BackWall");
            LeftWallMaterial = GetSurfaceMaterial("LeftWall");
            RightWallMaterial = GetSurfaceMaterial("RightWall");

            RightWallDoorSlootMaterial = GetSurfaceMaterial("RightWallDoorSlot");
            LeftWallMaterial = GetSurfaceMaterial("LeftWallDoorSlot");
            FrontWallMaterial = GetSurfaceMaterial("FrontWallDoorSlot");
            BackWallMaterial = GetSurfaceMaterial("BackWallDoorSlot");
        }

    }
}
