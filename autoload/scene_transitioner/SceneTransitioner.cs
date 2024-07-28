using Extensionator;
using Godot;
using Godot.Collections;
using GodotExtensionator;
using System.Linq;
using System.Threading.Tasks;

namespace GodotExtensionatorStarter {

    public sealed partial class SceneTransitioner : Node {
        #region Signals

        [Signal]
        public delegate void TransitionRequestedEventHandler(string nextScenePath);

        [Signal]
        public delegate void TransitionFinishedEventHandler(string nextScenePath);
        #endregion

        [Export] public PackedScene LoadingScreenScene = Preloader.Instance.LoadingScreenDefaultScene;

        public AnimationPlayer TransitionAnimationPlayer { get; set; } = default!;
        public ColorRect ColorRect { get; set; } = default!;

        public enum TRANSITIONS {
            NoTransition,
            FadeToBlack,
            FadeFromBlack,
            VoronoiInLeftToRight,
            VoronoiInRightToLeft,
            VoronoiOutLeftToRight,
            VoronoiOutRightToLeft,
        }

        public string NextScenePath = string.Empty;
        public Array<TRANSITIONS> RemainingAnimations = [];

        public override void _EnterTree() {
            TransitionAnimationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
            ColorRect = GetNode<ColorRect>("ColorRect");

            TransitionAnimationPlayer.AnimationFinished += OnTransitionAnimationFinished;
        }
        public async void TransitionToScene(
            string scenePath,
            bool loadingScreen = false,
            TRANSITIONS outTransition = TRANSITIONS.FadeToBlack,
            TRANSITIONS inTransition = TRANSITIONS.FadeFromBlack) {

            if (scenePath.FilePathIsValid()) {
                PrepareTransitionAnimations(loadingScreen, outTransition, inTransition);

                EmitSignal(SignalName.TransitionRequested, scenePath);

                if (RemainingAnimations.Count > 0)
                    await TriggerTransition(RemainingAnimations.Last());

                TransitionToSceneFile(scenePath, loadingScreen);
            }
        }

        public async void TransitionToScene(
           PackedScene scene,
           bool loadingScreen = false,
           TRANSITIONS outTransition = TRANSITIONS.FadeToBlack,
           TRANSITIONS inTransition = TRANSITIONS.FadeFromBlack) {

            PrepareTransitionAnimations(loadingScreen, outTransition, inTransition);

            EmitSignal(SignalName.TransitionRequested, scene.ResourcePath);

            if (RemainingAnimations.Count > 0)
                await TriggerTransition(RemainingAnimations.Last());

            TransitionToScenePacked(scene, loadingScreen);
        }

        private void TransitionToSceneFile(string scenePath, bool loadingScreen = false) {
            if (loadingScreen) {
                TransitionWithLoadingScreen(LoadingScreenScene);
            }
            else {
                EmitSignal(SignalName.TransitionFinished, scenePath);
                GetTree().CallDeferred(SceneTree.MethodName.ChangeSceneToFile, scenePath);
            }

        }

        private void TransitionToScenePacked(PackedScene scene, bool loadingScreen = false) {
            if (loadingScreen) {
                TransitionWithLoadingScreen(LoadingScreenScene);
            }
            else {
                EmitSignal(SignalName.TransitionFinished, scene.ResourcePath);
                GetTree().CallDeferred(SceneTree.MethodName.ChangeSceneToPacked, scene);
            }

        }

        private void TransitionWithLoadingScreen(string? loadingScene = null) {
            loadingScene ??= LoadingScreenScene.ResourcePath;

            EmitSignal(SignalName.TransitionFinished, loadingScene);
            GetTree().CallDeferred(SceneTree.MethodName.ChangeSceneToFile, loadingScene);
        }

        private void TransitionWithLoadingScreen(PackedScene? loadingScene = null) {
            loadingScene ??= LoadingScreenScene;

            EmitSignal(SignalName.TransitionFinished, loadingScene.ResourcePath);
            GetTree().CallDeferred(SceneTree.MethodName.ChangeSceneToPacked, loadingScene);
        }


        private async Task TriggerTransition(TRANSITIONS transition) {
            if (transition.Equals(TRANSITIONS.NoTransition))
                return;

            string transitionName = AnimationNameFromTransition(transition);

            if (TransitionAnimationPlayer.HasAnimation(transitionName)) {
                TransitionAnimationPlayer.Play(transitionName);
                await ToSignal(TransitionAnimationPlayer, AnimationMixer.SignalName.AnimationFinished);
            }
        }


        private void PrepareTransitionAnimations(bool loadingScreen, TRANSITIONS outTransition, TRANSITIONS inTransition) {
            RemainingAnimations.Clear();

            if (loadingScreen)
                RemainingAnimations.Add(outTransition);
            else
                RemainingAnimations.AddRange([inTransition, outTransition]);

            RemainingAnimations = (Array<TRANSITIONS>)RemainingAnimations.Where((transition) => !transition.Equals(TRANSITIONS.NoTransition));
        }

        private static string AnimationNameFromTransition(TRANSITIONS transition) {
            string animationName = transition switch {
                TRANSITIONS.FadeToBlack => "fade_to_black",
                TRANSITIONS.FadeFromBlack => "fade_from_black",
                TRANSITIONS.VoronoiInLeftToRight => "voronoi_in_left",
                TRANSITIONS.VoronoiInRightToLeft => "voronoi_in_right",
                TRANSITIONS.VoronoiOutRightToLeft => "voronoi_out_left",
                TRANSITIONS.VoronoiOutLeftToRight => "voronoi_out_right",
                _ => string.Empty,
            };

            return animationName;
        }

        private void VoronoiInTransition(bool flip = false, float duration = 1f) {
            ShaderMaterial material = Preloader.Instance.VoronoiMaterial;
            material.SetShaderParameter("flip", flip);

            ColorRect.Material = material;

            Tween tween = GetTree().CreateTween();
            tween.TweenProperty(ColorRect.Material, "shader_parameter/threshold", 1f, duration).From(0f);
        }

        public void VoronoiOutTransition(bool flip = false, float duration = 1f) {
            ShaderMaterial material = Preloader.Instance.VoronoiMaterial;
            material.SetShaderParameter("flip", flip);

            ColorRect.Material = material;

            Tween tween = GetTree().CreateTween();
            tween.TweenProperty(ColorRect.Material, "shader_parameter/threshold", 0f, duration).From(1f);
        }

        public void OnTransitionAnimationFinished(StringName animationName) {
            if (RemainingAnimations.IsEmpty())
                return;

            string animation = AnimationNameFromTransition(RemainingAnimations.Last());

            if (!string.IsNullOrEmpty(animation) && TransitionAnimationPlayer.HasAnimation(animation))
                TransitionAnimationPlayer.Play(animation);

        }

    }

}