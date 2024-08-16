using Extensionator;
using Godot;
using GodotExtensionator;
using System.Collections.Generic;
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

        public enum Transitions {
            NoTransition,
            FadeToBlack,
            FadeFromBlack,
            VoronoiInLeftToRight,
            VoronoiInRightToLeft,
            VoronoiOutLeftToRight,
            VoronoiOutRightToLeft,
        }

        public string NextScenePath = string.Empty;
        public List<Transitions> RemainingAnimations = [];

        public override void _EnterTree() {
            TransitionAnimationPlayer = GetNode<AnimationPlayer>(nameof(AnimationPlayer));
            ColorRect = GetNode<ColorRect>(nameof(ColorRect));

            TransitionAnimationPlayer.AnimationFinished += OnTransitionAnimationFinished;

            ColorRect.ZIndex = 100;
        }
        public async void TransitionToScene(
            string scenePath,
            bool loadingScreen = false,
            Transitions outTransition = Transitions.FadeToBlack,
            Transitions inTransition = Transitions.FadeFromBlack) {

            if (scenePath.FilePathIsValid()) {
                PrepareTransitionAnimations(loadingScreen, outTransition, inTransition);

                EmitSignal(SignalName.TransitionRequested, scenePath);

                if (RemainingAnimations.Count > 0)
                    await TriggerTransition(RemainingAnimations.PopBack());

                TransitionToSceneFile(scenePath, loadingScreen);
            }
        }

        public async void TransitionToScene(
           PackedScene scene,
           bool loadingScreen = false,
           Transitions outTransition = Transitions.FadeToBlack,
           Transitions inTransition = Transitions.FadeFromBlack) {

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


        private async Task TriggerTransition(Transitions transition) {
            if (transition.Equals(Transitions.NoTransition))
                return;

            string transitionName = AnimationNameFromTransition(transition);

            if (TransitionAnimationPlayer.HasAnimation(transitionName)) {
                TransitionAnimationPlayer.Play(transitionName);
                await ToSignal(TransitionAnimationPlayer, AnimationMixer.SignalName.AnimationFinished);
            }
        }


        private void PrepareTransitionAnimations(bool loadingScreen, Transitions outTransition, Transitions inTransition) {
            RemainingAnimations.Clear();

            if (loadingScreen)
                RemainingAnimations.Add(outTransition);
            else
                RemainingAnimations.AddRange([inTransition, outTransition]);

            RemainingAnimations = RemainingAnimations.Where((transition) => !transition.Equals(Transitions.NoTransition)).Cast<Transitions>().ToList();
        }

        private static string AnimationNameFromTransition(Transitions transition) {
            string animationName = transition switch {
                Transitions.FadeToBlack => "fade_to_black",
                Transitions.FadeFromBlack => "fade_from_black",
                Transitions.VoronoiInLeftToRight => "voronoi_in_left",
                Transitions.VoronoiInRightToLeft => "voronoi_in_right",
                Transitions.VoronoiOutRightToLeft => "voronoi_out_left",
                Transitions.VoronoiOutLeftToRight => "voronoi_out_right",
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

            string animation = AnimationNameFromTransition(RemainingAnimations.PopBack());

            if (!string.IsNullOrEmpty(animation) && TransitionAnimationPlayer.HasAnimation(animation))
                TransitionAnimationPlayer.Play(animation);

        }

    }

}