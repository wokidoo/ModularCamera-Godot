#if TOOLS
using Godot;
using System;

[Tool]
public partial class ModularCameraPlugin : EditorPlugin
{
	public override void _EnterTree()
	{
		// Initialization of the plugin goes here.
		var script = GD.Load<Script>("res://addons/ModularCamera/modular_camera.cs");
		var texture = GD.Load<Texture2D>("res://addons/ModularCamera/icon.svg");
		this.AddCustomType("ModularCamera","Marker3D",script,texture);
	}

	public override void _ExitTree()
	{
		// Clean-up of the plugin goes here.
		RemoveCustomType("ModularCamera");
	}
}
#endif
