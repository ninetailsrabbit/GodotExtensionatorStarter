using Godot;

namespace GodotExtensionatorStarter {
    [Tool]
    public partial class RoomMesh : MeshInstance3D {
        public ArrayMesh RoomMeshShape { get; set; } = null!;
        public Material FloorMaterial { get; set; } = default!;
        public Material CeilMaterial { get; set; } = default!;
        public Material FrontWallMaterial { get; set; } = default!;
        public Material BackWallMaterial { get; set; } = default!;
        public Material LeftWallMaterial { get; set; } = default!;
        public Material RightWallMaterial { get; set; } = default!;

        public override void _EnterTree() {
            if (!Engine.IsEditorHint()) {
                int floorSurfaceIndex = RoomMeshShape.SurfaceFindByName("Floor");
                int ceilSurfaceIndex = RoomMeshShape.SurfaceFindByName("Ceil");
                int frontWallSurfaceIndex = RoomMeshShape.SurfaceFindByName("FrontWall");
                int backWallSurfaceIndex = RoomMeshShape.SurfaceFindByName("BackWall");
                int leftWallSurfaceIndex = RoomMeshShape.SurfaceFindByName("LeftWall");
                int rightWallSurfaceIndex = RoomMeshShape.SurfaceFindByName("RightWall");

                if (floorSurfaceIndex != -1)
                    FloorMaterial = RoomMeshShape.SurfaceGetMaterial(floorSurfaceIndex);

                if (ceilSurfaceIndex != -1)
                    CeilMaterial = RoomMeshShape.SurfaceGetMaterial(ceilSurfaceIndex);

                if (frontWallSurfaceIndex != -1)
                    CeilMaterial = RoomMeshShape.SurfaceGetMaterial(frontWallSurfaceIndex);

                if (backWallSurfaceIndex != -1)
                    BackWallMaterial = RoomMeshShape.SurfaceGetMaterial(backWallSurfaceIndex);

                if (leftWallSurfaceIndex != -1)
                    LeftWallMaterial = RoomMeshShape.SurfaceGetMaterial(leftWallSurfaceIndex);

                if (rightWallSurfaceIndex != -1)
                    RightWallMaterial = RoomMeshShape.SurfaceGetMaterial(rightWallSurfaceIndex);
            }
        }


    }
}
