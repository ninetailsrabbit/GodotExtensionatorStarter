using Godot;

namespace GodotExtensionatorStarter {
    [GlobalClass]
    [Tool]
    public partial class RoomParameters : Resource {

        [Export(PropertyHint.Range, "1, 1000, 1")] public int NumberOfRoomsPerGeneration = 3;
        [Export(PropertyHint.Range, "1, 4, 1")] public int DoorsPerRoom = 2;
        [Export] public bool UseBridgeConnectorsBetweenRooms = false;
        [Export] public bool RandomizeDoorPositionInWall = false;
        [Export] public Vector3 DoorSize = new(1.5f, 2f, 0.25f);
        [Export] public Vector3 MinBridgeConnectorSize = new(2f, 3f, 4f);
        [Export] public Vector3 MaxBridgeConnectorSize = new(2f, 3f, 10f);
        [Export] public Vector3 MinRoomSize = new(6f, 3.5f, 5f);
        [Export] public Vector3 MaxRoomSize = new(10f, 5f, 6f);
        [Export] public float WallThickness = 0.15f;
        [Export] public float CeilThickness = 0.1f;
        [Export] public float FloorThickness = 0.1f;
    }
}
