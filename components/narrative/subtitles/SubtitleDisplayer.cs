using Godot;
using GodotExtensionator;
using System;


namespace GodotExtensionatorStarter {
    public partial class SubtitleDisplayer : Control {

        [Export] public bool CanBeSkipped = false;

        public AutoTypedText AutoTypedText { get; set; } = null!;

        public override void _Ready() {
            AutoTypedText = GetNode<AutoTypedText>($"%{nameof(AutoTypedText)}");

            ArgumentNullException.ThrowIfNull(AutoTypedText);

            AutoTypedText.ManualStart = false;
            AutoTypedText.CanBeSkipped = CanBeSkipped;

            AutoTypedText.ReloadText("COMEME LA POLLA GITANO DE MIERDA [b]CHUPAMELAAA AAAAAH[/b]");
        }



    }

}