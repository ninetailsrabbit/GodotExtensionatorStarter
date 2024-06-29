using Godot;
using Godot.NativeInterop;

namespace GodotExtensionatorStarter {

partial class Interactable3D
{
#pragma warning disable CS0109 // Disable warning about redundant 'new' keyword
    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : global::Godot.Area3D.PropertyName {
        /// <summary>
        /// Cached name for the 'FocusPointer' property.
        /// </summary>
        public new static readonly global::Godot.StringName FocusPointer = "FocusPointer";
        /// <summary>
        /// Cached name for the 'InteractPointer' property.
        /// </summary>
        public new static readonly global::Godot.StringName InteractPointer = "InteractPointer";
        /// <summary>
        /// Cached name for the 'GameGlobals' property.
        /// </summary>
        public new static readonly global::Godot.StringName GameGlobals = "GameGlobals";
        /// <summary>
        /// Cached name for the 'GlobalGameEvents' property.
        /// </summary>
        public new static readonly global::Godot.StringName GlobalGameEvents = "GlobalGameEvents";
        /// <summary>
        /// Cached name for the 'TimesInteracted' property.
        /// </summary>
        public new static readonly global::Godot.StringName TimesInteracted = "TimesInteracted";
        /// <summary>
        /// Cached name for the 'NumberOfTimesYouCanInteract' field.
        /// </summary>
        public new static readonly global::Godot.StringName NumberOfTimesYouCanInteract = "NumberOfTimesYouCanInteract";
        /// <summary>
        /// Cached name for the 'Title' field.
        /// </summary>
        public new static readonly global::Godot.StringName Title = "Title";
        /// <summary>
        /// Cached name for the 'Description' field.
        /// </summary>
        public new static readonly global::Godot.StringName Description = "Description";
        /// <summary>
        /// Cached name for the 'Category' field.
        /// </summary>
        public new static readonly global::Godot.StringName Category = "Category";
        /// <summary>
        /// Cached name for the 'Scannable' field.
        /// </summary>
        public new static readonly global::Godot.StringName Scannable = "Scannable";
        /// <summary>
        /// Cached name for the 'Pickable' field.
        /// </summary>
        public new static readonly global::Godot.StringName Pickable = "Pickable";
        /// <summary>
        /// Cached name for the 'PickupMessage' field.
        /// </summary>
        public new static readonly global::Godot.StringName PickupMessage = "PickupMessage";
        /// <summary>
        /// Cached name for the 'PullPower' field.
        /// </summary>
        public new static readonly global::Godot.StringName PullPower = "PullPower";
        /// <summary>
        /// Cached name for the 'ThrowPower' field.
        /// </summary>
        public new static readonly global::Godot.StringName ThrowPower = "ThrowPower";
        /// <summary>
        /// Cached name for the 'Usable' field.
        /// </summary>
        public new static readonly global::Godot.StringName Usable = "Usable";
        /// <summary>
        /// Cached name for the 'UsableMessage' field.
        /// </summary>
        public new static readonly global::Godot.StringName UsableMessage = "UsableMessage";
        /// <summary>
        /// Cached name for the 'CanBeSaved' field.
        /// </summary>
        public new static readonly global::Godot.StringName CanBeSaved = "CanBeSaved";
        /// <summary>
        /// Cached name for the 'InventorySaveMessage' field.
        /// </summary>
        public new static readonly global::Godot.StringName InventorySaveMessage = "InventorySaveMessage";
        /// <summary>
        /// Cached name for the 'LockPlayer' field.
        /// </summary>
        public new static readonly global::Godot.StringName LockPlayer = "LockPlayer";
        /// <summary>
        /// Cached name for the '_timesInteracted' field.
        /// </summary>
        public new static readonly global::Godot.StringName _timesInteracted = "_timesInteracted";
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool SetGodotClassPropertyValue(in godot_string_name name, in godot_variant value)
    {
        if (name == PropertyName.FocusPointer) {
            this.FocusPointer = global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.CompressedTexture2D>(value);
            return true;
        }
        else if (name == PropertyName.InteractPointer) {
            this.InteractPointer = global::Godot.NativeInterop.VariantUtils.ConvertTo<global::Godot.CompressedTexture2D>(value);
            return true;
        }
        else if (name == PropertyName.GameGlobals) {
            this.GameGlobals = global::Godot.NativeInterop.VariantUtils.ConvertTo<global::GodotExtensionatorStarter.GameGlobals>(value);
            return true;
        }
        else if (name == PropertyName.GlobalGameEvents) {
            this.GlobalGameEvents = global::Godot.NativeInterop.VariantUtils.ConvertTo<global::GodotExtensionatorStarter.GlobalGameEvents>(value);
            return true;
        }
        else if (name == PropertyName.TimesInteracted) {
            this.TimesInteracted = global::Godot.NativeInterop.VariantUtils.ConvertTo<int>(value);
            return true;
        }
        else if (name == PropertyName.NumberOfTimesYouCanInteract) {
            this.NumberOfTimesYouCanInteract = global::Godot.NativeInterop.VariantUtils.ConvertTo<int>(value);
            return true;
        }
        else if (name == PropertyName.Title) {
            this.Title = global::Godot.NativeInterop.VariantUtils.ConvertTo<string>(value);
            return true;
        }
        else if (name == PropertyName.Description) {
            this.Description = global::Godot.NativeInterop.VariantUtils.ConvertTo<string>(value);
            return true;
        }
        else if (name == PropertyName.Category) {
            this.Category = global::Godot.NativeInterop.VariantUtils.ConvertTo<global::GodotExtensionatorStarter.Interactable3D.CATEGORY>(value);
            return true;
        }
        else if (name == PropertyName.Scannable) {
            this.Scannable = global::Godot.NativeInterop.VariantUtils.ConvertTo<bool>(value);
            return true;
        }
        else if (name == PropertyName.Pickable) {
            this.Pickable = global::Godot.NativeInterop.VariantUtils.ConvertTo<bool>(value);
            return true;
        }
        else if (name == PropertyName.PickupMessage) {
            this.PickupMessage = global::Godot.NativeInterop.VariantUtils.ConvertTo<string>(value);
            return true;
        }
        else if (name == PropertyName.PullPower) {
            this.PullPower = global::Godot.NativeInterop.VariantUtils.ConvertTo<float>(value);
            return true;
        }
        else if (name == PropertyName.ThrowPower) {
            this.ThrowPower = global::Godot.NativeInterop.VariantUtils.ConvertTo<float>(value);
            return true;
        }
        else if (name == PropertyName.Usable) {
            this.Usable = global::Godot.NativeInterop.VariantUtils.ConvertTo<bool>(value);
            return true;
        }
        else if (name == PropertyName.UsableMessage) {
            this.UsableMessage = global::Godot.NativeInterop.VariantUtils.ConvertTo<string>(value);
            return true;
        }
        else if (name == PropertyName.CanBeSaved) {
            this.CanBeSaved = global::Godot.NativeInterop.VariantUtils.ConvertTo<bool>(value);
            return true;
        }
        else if (name == PropertyName.InventorySaveMessage) {
            this.InventorySaveMessage = global::Godot.NativeInterop.VariantUtils.ConvertTo<string>(value);
            return true;
        }
        else if (name == PropertyName.LockPlayer) {
            this.LockPlayer = global::Godot.NativeInterop.VariantUtils.ConvertTo<bool>(value);
            return true;
        }
        else if (name == PropertyName._timesInteracted) {
            this._timesInteracted = global::Godot.NativeInterop.VariantUtils.ConvertTo<int>(value);
            return true;
        }
        return base.SetGodotClassPropertyValue(name, value);
    }
    /// <inheritdoc/>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool GetGodotClassPropertyValue(in godot_string_name name, out godot_variant value)
    {
        if (name == PropertyName.FocusPointer) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<global::Godot.CompressedTexture2D>(this.FocusPointer);
            return true;
        }
        else if (name == PropertyName.InteractPointer) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<global::Godot.CompressedTexture2D>(this.InteractPointer);
            return true;
        }
        else if (name == PropertyName.GameGlobals) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<global::GodotExtensionatorStarter.GameGlobals>(this.GameGlobals);
            return true;
        }
        else if (name == PropertyName.GlobalGameEvents) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<global::GodotExtensionatorStarter.GlobalGameEvents>(this.GlobalGameEvents);
            return true;
        }
        else if (name == PropertyName.TimesInteracted) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<int>(this.TimesInteracted);
            return true;
        }
        else if (name == PropertyName.NumberOfTimesYouCanInteract) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<int>(this.NumberOfTimesYouCanInteract);
            return true;
        }
        else if (name == PropertyName.Title) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<string>(this.Title);
            return true;
        }
        else if (name == PropertyName.Description) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<string>(this.Description);
            return true;
        }
        else if (name == PropertyName.Category) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<global::GodotExtensionatorStarter.Interactable3D.CATEGORY>(this.Category);
            return true;
        }
        else if (name == PropertyName.Scannable) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<bool>(this.Scannable);
            return true;
        }
        else if (name == PropertyName.Pickable) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<bool>(this.Pickable);
            return true;
        }
        else if (name == PropertyName.PickupMessage) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<string>(this.PickupMessage);
            return true;
        }
        else if (name == PropertyName.PullPower) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<float>(this.PullPower);
            return true;
        }
        else if (name == PropertyName.ThrowPower) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<float>(this.ThrowPower);
            return true;
        }
        else if (name == PropertyName.Usable) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<bool>(this.Usable);
            return true;
        }
        else if (name == PropertyName.UsableMessage) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<string>(this.UsableMessage);
            return true;
        }
        else if (name == PropertyName.CanBeSaved) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<bool>(this.CanBeSaved);
            return true;
        }
        else if (name == PropertyName.InventorySaveMessage) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<string>(this.InventorySaveMessage);
            return true;
        }
        else if (name == PropertyName.LockPlayer) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<bool>(this.LockPlayer);
            return true;
        }
        else if (name == PropertyName._timesInteracted) {
            value = global::Godot.NativeInterop.VariantUtils.CreateFrom<int>(this._timesInteracted);
            return true;
        }
        return base.GetGodotClassPropertyValue(name, out value);
    }
    /// <summary>
    /// Get the property information for all the properties declared in this class.
    /// This method is used by Godot to register the available properties in the editor.
    /// Do not call this method.
    /// </summary>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    internal new static global::System.Collections.Generic.List<global::Godot.Bridge.PropertyInfo> GetGodotPropertyList()
    {
        var properties = new global::System.Collections.Generic.List<global::Godot.Bridge.PropertyInfo>();
        properties.Add(new(type: (global::Godot.Variant.Type)2, name: PropertyName.NumberOfTimesYouCanInteract, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4102, exported: true));
        properties.Add(new(type: (global::Godot.Variant.Type)0, name: "Pointers", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)64, exported: true));
        properties.Add(new(type: (global::Godot.Variant.Type)24, name: PropertyName.FocusPointer, hint: (global::Godot.PropertyHint)17, hintString: "CompressedTexture2D", usage: (global::Godot.PropertyUsageFlags)4102, exported: true));
        properties.Add(new(type: (global::Godot.Variant.Type)24, name: PropertyName.InteractPointer, hint: (global::Godot.PropertyHint)17, hintString: "CompressedTexture2D", usage: (global::Godot.PropertyUsageFlags)4102, exported: true));
        properties.Add(new(type: (global::Godot.Variant.Type)0, name: "Information", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)64, exported: true));
        properties.Add(new(type: (global::Godot.Variant.Type)4, name: PropertyName.Title, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4102, exported: true));
        properties.Add(new(type: (global::Godot.Variant.Type)4, name: PropertyName.Description, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4102, exported: true));
        properties.Add(new(type: (global::Godot.Variant.Type)2, name: PropertyName.Category, hint: (global::Godot.PropertyHint)2, hintString: "DOOR,WINDOW,OBJECT,ITEM,WEAPON,KEY", usage: (global::Godot.PropertyUsageFlags)4102, exported: true));
        properties.Add(new(type: (global::Godot.Variant.Type)0, name: "Scan", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)64, exported: true));
        properties.Add(new(type: (global::Godot.Variant.Type)1, name: PropertyName.Scannable, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4102, exported: true));
        properties.Add(new(type: (global::Godot.Variant.Type)0, name: "Pickup", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)64, exported: true));
        properties.Add(new(type: (global::Godot.Variant.Type)1, name: PropertyName.Pickable, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4102, exported: true));
        properties.Add(new(type: (global::Godot.Variant.Type)4, name: PropertyName.PickupMessage, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4102, exported: true));
        properties.Add(new(type: (global::Godot.Variant.Type)3, name: PropertyName.PullPower, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4102, exported: true));
        properties.Add(new(type: (global::Godot.Variant.Type)3, name: PropertyName.ThrowPower, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4102, exported: true));
        properties.Add(new(type: (global::Godot.Variant.Type)0, name: "Usable", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)64, exported: true));
        properties.Add(new(type: (global::Godot.Variant.Type)1, name: PropertyName.Usable, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4102, exported: true));
        properties.Add(new(type: (global::Godot.Variant.Type)4, name: PropertyName.UsableMessage, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4102, exported: true));
        properties.Add(new(type: (global::Godot.Variant.Type)0, name: "Inventory", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)64, exported: true));
        properties.Add(new(type: (global::Godot.Variant.Type)1, name: PropertyName.CanBeSaved, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4102, exported: true));
        properties.Add(new(type: (global::Godot.Variant.Type)4, name: PropertyName.InventorySaveMessage, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4102, exported: true));
        properties.Add(new(type: (global::Godot.Variant.Type)0, name: "Player", hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)64, exported: true));
        properties.Add(new(type: (global::Godot.Variant.Type)1, name: PropertyName.LockPlayer, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4102, exported: true));
        properties.Add(new(type: (global::Godot.Variant.Type)24, name: PropertyName.GameGlobals, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)24, name: PropertyName.GlobalGameEvents, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)2, name: PropertyName.TimesInteracted, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        properties.Add(new(type: (global::Godot.Variant.Type)2, name: PropertyName._timesInteracted, hint: (global::Godot.PropertyHint)0, hintString: "", usage: (global::Godot.PropertyUsageFlags)4096, exported: false));
        return properties;
    }
#pragma warning restore CS0109
}

}
