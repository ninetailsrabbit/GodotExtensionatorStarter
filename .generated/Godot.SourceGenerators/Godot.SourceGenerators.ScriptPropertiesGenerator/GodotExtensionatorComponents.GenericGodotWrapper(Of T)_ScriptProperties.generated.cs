using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorComponents {

partial class GenericGodotWrapper<T>
{
#pragma warning disable CS0109 // Disable warning about redundant 'new' keyword
    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : global::Godot.RefCounted.PropertyName {
    }
}

}
