using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorComponents {

partial class FiniteStateMachine
{
#pragma warning disable CS0109 // Disable warning about redundant 'new' keyword
    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : global::Godot.Node.MethodName {
        /// <summary>
        /// Cached name for the '_Ready' method.
        /// </summary>
        public new static readonly global::Godot.StringName _Ready = "_Ready";
        /// <summary>
        /// Cached name for the 'CurrentStateIs' method.
        /// </summary>
        public new static readonly global::Godot.StringName CurrentStateIs = "CurrentStateIs";
        /// <summary>
        /// Cached name for the 'CurrentStateIsNot' method.
        /// </summary>
        public new static readonly global::Godot.StringName CurrentStateIsNot = "CurrentStateIsNot";
        /// <summary>
        /// Cached name for the 'StateExists' method.
        /// </summary>
        public new static readonly global::Godot.StringName StateExists = "StateExists";
        /// <summary>
        /// Cached name for the 'EnterState' method.
        /// </summary>
        public new static readonly global::Godot.StringName EnterState = "EnterState";
        /// <summary>
        /// Cached name for the 'ExitState' method.
        /// </summary>
        public new static readonly global::Godot.StringName ExitState = "ExitState";
        /// <summary>
        /// Cached name for the 'GetStateByName' method.
        /// </summary>
        public new static readonly global::Godot.StringName GetStateByName = "GetStateByName";
        /// <summary>
        /// Cached name for the 'LastState' method.
        /// </summary>
        public new static readonly global::Godot.StringName LastState = "LastState";
        /// <summary>
        /// Cached name for the 'PushStateToStack' method.
        /// </summary>
        public new static readonly global::Godot.StringName PushStateToStack = "PushStateToStack";
        /// <summary>
        /// Cached name for the '_UnhandledInput' method.
        /// </summary>
        public new static readonly global::Godot.StringName _UnhandledInput = "_UnhandledInput";
        /// <summary>
        /// Cached name for the '_PhysicsProcess' method.
        /// </summary>
        public new static readonly global::Godot.StringName _PhysicsProcess = "_PhysicsProcess";
        /// <summary>
        /// Cached name for the '_Process' method.
        /// </summary>
        public new static readonly global::Godot.StringName _Process = "_Process";
        /// <summary>
        /// Cached name for the 'LockStateMachine' method.
        /// </summary>
        public new static readonly global::Godot.StringName LockStateMachine = "LockStateMachine";
        /// <summary>
        /// Cached name for the 'UnlockStateMachine' method.
        /// </summary>
        public new static readonly global::Godot.StringName UnlockStateMachine = "UnlockStateMachine";
        /// <summary>
        /// Cached name for the 'InitializeStateNodes' method.
        /// </summary>
        public new static readonly global::Godot.StringName InitializeStateNodes = "InitializeStateNodes";
        /// <summary>
        /// Cached name for the 'RegisterTransitions' method.
        /// </summary>
        public new static readonly global::Godot.StringName RegisterTransitions = "RegisterTransitions";
        /// <summary>
        /// Cached name for the 'RegisterTransition' method.
        /// </summary>
        public new static readonly global::Godot.StringName RegisterTransition = "RegisterTransition";
        /// <summary>
        /// Cached name for the 'BuildTransitionName' method.
        /// </summary>
        public new static readonly global::Godot.StringName BuildTransitionName = "BuildTransitionName";
        /// <summary>
        /// Cached name for the 'AddStateToDictionary' method.
        /// </summary>
        public new static readonly global::Godot.StringName AddStateToDictionary = "AddStateToDictionary";
        /// <summary>
        /// Cached name for the 'OnStateChanged' method.
        /// </summary>
        public new static readonly global::Godot.StringName OnStateChanged = "OnStateChanged";
        /// <summary>
        /// Cached name for the 'OnStateChangeFailed' method.
        /// </summary>
        public new static readonly global::Godot.StringName OnStateChangeFailed = "OnStateChangeFailed";
    }
    /// <summary>
    /// Get the method information for all the methods declared in this class.
    /// This method is used by Godot to register the available methods in the editor.
    /// Do not call this method.
    /// </summary>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    internal new static global::System.Collections.Generic.List<global::Godot.Bridge.MethodInfo> GetGodotMethodList()
    {
        var methods = new global::System.Collections.Generic.List<global::Godot.Bridge.MethodInfo>(21);
        methods.Add(new(name: MethodName._Ready, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName.CurrentStateIs, returnVal: new(type: (global::Godot.Variant.Type)1, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)4, name: "name", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.CurrentStateIsNot, returnVal: new(type: (global::Godot.Variant.Type)1, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)34, name: "states", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.StateExists, returnVal: new(type: (global::Godot.Variant.Type)1, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)24, name: "state", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("Node")),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.EnterState, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)24, name: "state", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("Node")),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.ExitState, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)24, name: "state", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("Node")), new(type: (global::Godot.Variant.Type)24, name: "nextState", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("Node")),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.GetStateByName, returnVal: new(type: (global::Godot.Variant.Type)24, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("Node")), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)4, name: "name", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.LastState, returnVal: new(type: (global::Godot.Variant.Type)24, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("Node")), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName.PushStateToStack, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)24, name: "state", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("Node")),  }, defaultArguments: null));
        methods.Add(new(name: MethodName._UnhandledInput, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)24, name: "event", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("InputEvent")),  }, defaultArguments: null));
        methods.Add(new(name: MethodName._PhysicsProcess, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)3, name: "delta", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false),  }, defaultArguments: null));
        methods.Add(new(name: MethodName._Process, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)3, name: "delta", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.LockStateMachine, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName.UnlockStateMachine, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName.InitializeStateNodes, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: null, defaultArguments: null));
        methods.Add(new(name: MethodName.RegisterTransitions, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)28, name: "transitions", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.RegisterTransition, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)24, name: "transition", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("RefCounted")),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.BuildTransitionName, returnVal: new(type: (global::Godot.Variant.Type)4, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)24, name: "from", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("Node")), new(type: (global::Godot.Variant.Type)24, name: "to", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("Node")),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.AddStateToDictionary, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)24, name: "state", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("Node")),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.OnStateChanged, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)24, name: "from", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("Node")), new(type: (global::Godot.Variant.Type)24, name: "to", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("Node")),  }, defaultArguments: null));
        methods.Add(new(name: MethodName.OnStateChangeFailed, returnVal: new(type: (global::Godot.Variant.Type)0, name: "", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false), flags: (global::Godot.MethodFlags)1, arguments: new() { new(type: (global::Godot.Variant.Type)24, name: "from", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("Node")), new(type: (global::Godot.Variant.Type)24, name: "to", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)6, exported: false, className: new global::Godot.StringName("Node")),  }, defaultArguments: null));
        return methods;
    }
#pragma warning restore CS0109
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool InvokeGodotClassMethod(in godot_string_name method, NativeVariantPtrArgs args, out godot_variant ret)
    {
        if (method == MethodName._Ready && args.Count == 0) {
            _Ready();
            ret = default;
            return true;
        }
        if (method == MethodName.CurrentStateIs && args.Count == 1) {
            var callRet = CurrentStateIs(global::Godot.NativeInterop.VariantUtils.ConvertTo<string>(args[0]));
            ret = global::Godot.NativeInterop.VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if (method == MethodName.CurrentStateIsNot && args.Count == 1) {
            var callRet = CurrentStateIsNot(global::Godot.NativeInterop.VariantUtils.ConvertTo<string[]>(args[0]));
            ret = global::Godot.NativeInterop.VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if (method == MethodName.StateExists && args.Count == 1) {
            var callRet = StateExists(global::Godot.NativeInterop.VariantUtils.ConvertTo<global::GodotExtensionatorComponents.MachineState>(args[0]));
            ret = global::Godot.NativeInterop.VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if (method == MethodName.EnterState && args.Count == 1) {
            EnterState(global::Godot.NativeInterop.VariantUtils.ConvertTo<global::GodotExtensionatorComponents.MachineState>(args[0]));
            ret = default;
            return true;
        }
        if (method == MethodName.ExitState && args.Count == 2) {
            ExitState(global::Godot.NativeInterop.VariantUtils.ConvertTo<global::GodotExtensionatorComponents.MachineState>(args[0]), global::Godot.NativeInterop.VariantUtils.ConvertTo<global::GodotExtensionatorComponents.MachineState>(args[1]));
            ret = default;
            return true;
        }
        if (method == MethodName.GetStateByName && args.Count == 1) {
            var callRet = GetStateByName(global::Godot.NativeInterop.VariantUtils.ConvertTo<string>(args[0]));
            ret = global::Godot.NativeInterop.VariantUtils.CreateFrom<global::GodotExtensionatorComponents.MachineState>(callRet);
            return true;
        }
        if (method == MethodName.LastState && args.Count == 0) {
            var callRet = LastState();
            ret = global::Godot.NativeInterop.VariantUtils.CreateFrom<global::GodotExtensionatorComponents.MachineState>(callRet);
            return true;
        }
        if (method == MethodName.PushStateToStack && args.Count == 1) {
            PushStateToStack(global::Godot.NativeInterop.VariantUtils.ConvertTo<global::GodotExtensionatorComponents.MachineState>(args[0]));
            ret = default;
            return true;
        }
        if (method == MethodName._UnhandledInput && args.Count == 1) {
            _UnhandledInput(global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.InputEvent>(args[0]));
            ret = default;
            return true;
        }
        if (method == MethodName._PhysicsProcess && args.Count == 1) {
            _PhysicsProcess(global::Godot.NativeInterop.VariantUtils.ConvertTo<double>(args[0]));
            ret = default;
            return true;
        }
        if (method == MethodName._Process && args.Count == 1) {
            _Process(global::Godot.NativeInterop.VariantUtils.ConvertTo<double>(args[0]));
            ret = default;
            return true;
        }
        if (method == MethodName.LockStateMachine && args.Count == 0) {
            LockStateMachine();
            ret = default;
            return true;
        }
        if (method == MethodName.UnlockStateMachine && args.Count == 0) {
            UnlockStateMachine();
            ret = default;
            return true;
        }
        if (method == MethodName.InitializeStateNodes && args.Count == 0) {
            InitializeStateNodes();
            ret = default;
            return true;
        }
        if (method == MethodName.RegisterTransitions && args.Count == 1) {
            RegisterTransitions(global::Godot.NativeInterop.VariantUtils.ConvertToSystemArrayOfGodotObject<global::GodotExtensionatorComponents.Transition>(args[0]));
            ret = default;
            return true;
        }
        if (method == MethodName.RegisterTransition && args.Count == 1) {
            RegisterTransition(global::Godot.NativeInterop.VariantUtils.ConvertTo<global::GodotExtensionatorComponents.Transition>(args[0]));
            ret = default;
            return true;
        }
        if (method == MethodName.BuildTransitionName && args.Count == 2) {
            var callRet = BuildTransitionName(global::Godot.NativeInterop.VariantUtils.ConvertTo<global::GodotExtensionatorComponents.MachineState>(args[0]), global::Godot.NativeInterop.VariantUtils.ConvertTo<global::GodotExtensionatorComponents.MachineState>(args[1]));
            ret = global::Godot.NativeInterop.VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if (method == MethodName.AddStateToDictionary && args.Count == 1) {
            AddStateToDictionary(global::Godot.NativeInterop.VariantUtils.ConvertTo<global::GodotExtensionatorComponents.MachineState>(args[0]));
            ret = default;
            return true;
        }
        if (method == MethodName.OnStateChanged && args.Count == 2) {
            OnStateChanged(global::Godot.NativeInterop.VariantUtils.ConvertTo<global::GodotExtensionatorComponents.MachineState>(args[0]), global::Godot.NativeInterop.VariantUtils.ConvertTo<global::GodotExtensionatorComponents.MachineState>(args[1]));
            ret = default;
            return true;
        }
        if (method == MethodName.OnStateChangeFailed && args.Count == 2) {
            OnStateChangeFailed(global::Godot.NativeInterop.VariantUtils.ConvertTo<global::GodotExtensionatorComponents.MachineState>(args[0]), global::Godot.NativeInterop.VariantUtils.ConvertTo<global::GodotExtensionatorComponents.MachineState>(args[1]));
            ret = default;
            return true;
        }
        return base.InvokeGodotClassMethod(method, args, out ret);
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool HasGodotClassMethod(in godot_string_name method)
    {
        if (method == MethodName._Ready) {
           return true;
        }
        else if (method == MethodName.CurrentStateIs) {
           return true;
        }
        else if (method == MethodName.CurrentStateIsNot) {
           return true;
        }
        else if (method == MethodName.StateExists) {
           return true;
        }
        else if (method == MethodName.EnterState) {
           return true;
        }
        else if (method == MethodName.ExitState) {
           return true;
        }
        else if (method == MethodName.GetStateByName) {
           return true;
        }
        else if (method == MethodName.LastState) {
           return true;
        }
        else if (method == MethodName.PushStateToStack) {
           return true;
        }
        else if (method == MethodName._UnhandledInput) {
           return true;
        }
        else if (method == MethodName._PhysicsProcess) {
           return true;
        }
        else if (method == MethodName._Process) {
           return true;
        }
        else if (method == MethodName.LockStateMachine) {
           return true;
        }
        else if (method == MethodName.UnlockStateMachine) {
           return true;
        }
        else if (method == MethodName.InitializeStateNodes) {
           return true;
        }
        else if (method == MethodName.RegisterTransitions) {
           return true;
        }
        else if (method == MethodName.RegisterTransition) {
           return true;
        }
        else if (method == MethodName.BuildTransitionName) {
           return true;
        }
        else if (method == MethodName.AddStateToDictionary) {
           return true;
        }
        else if (method == MethodName.OnStateChanged) {
           return true;
        }
        else if (method == MethodName.OnStateChangeFailed) {
           return true;
        }
        return base.HasGodotClassMethod(method);
    }
}

}
