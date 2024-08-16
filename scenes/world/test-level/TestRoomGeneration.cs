using Extensionator;
using Godot;
using Godot.Collections;
using GodotExtensionator;
using GodotExtensionatorStarter;
using System;
using System.Linq;

public partial class TestRoomGeneration : Node3D {
    public RoomCreator RoomCreator { get; set; } = null!;

    public Node3D RoomMeshesOutputNode { get; set; } = default!;
    public FirstPersonController FirstPersonController { get; set; } = null!;
    public override void _Ready() {
        FirstPersonController = this.FirstNodeOfClass<FirstPersonController>();
        RoomCreator = this.FirstNodeOfClass<RoomCreator>();
        RoomMeshesOutputNode = GetNode<Node3D>(nameof(RoomMeshesOutputNode));

        ArgumentNullException.ThrowIfNull(FirstPersonController);
        ArgumentNullException.ThrowIfNull(RoomCreator);

        //foreach (RoomMesh room in RoomMeshesOutputNode.GetChildren().Where(child => child is RoomMesh).Cast<RoomMesh>()) {
        //    var material = (StandardMaterial3D)room.FloorMaterial;
        //    var material2 = (StandardMaterial3D)room.CeilMaterial;
        //    material.AlbedoColor = ColorExtension.RandomColor(); ;
        //    material2.AlbedoColor = ColorExtension.RandomColor();
        //}
        //RoomCreator.CreatedRooms += OnCreatedRooms;

        //RoomCreator.ClearRoomsInSceneTree();
        //RoomCreator.CreateCSGRooms();
        //RoomCreator.GenerateRoomsMeshes();

        GD.Print(string.Join(",", RoomCreator.CSGRoomsCreated), string.Join(",", RoomCreator.RoomsCreated));


    }

    private void OnCreatedRooms(Array<RoomMesh> rooms) {
        //foreach (var csgRoom in RoomCreator.CSGRoomsCreated) {
        //    csgRoom.Hide();
        //}

        if (rooms.IsEmpty()) {
            return;
        }

    }


}
