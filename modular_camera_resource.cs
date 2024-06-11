using Godot;
using System;

[Tool]
[GlobalClass]
public partial class modular_camera_resource : Resource
{
    [Signal]
    public delegate void ChangedEventHandler();

    [Export]
    public Godot.Vector3 pivot_offset = new Vector3(0.0f,0.0f,0.0f);
    [Export]
    public Godot.Vector3 camera_offset = new Vector3(0.0f,0.0f,0.0f);
    [ExportGroup("Invert")]
    [Export]
    private bool _invert_pitch = false;
    public bool invert_pitch {
        get { return _invert_pitch;}
        set { 
                _invert_pitch = value; 
                EmitSignal("Changed"); 
                GD.Print("Toggle pitch invert");
            }
    }

    [Export]
    public bool invert_pan = false;
    [ExportGroup("Threshold")]
    [Export]
    public float pitch_threshold = 0.1f;
    [Export]
    public float pan_threshold = 0.1f;
    [ExportGroup("Sensitivity")]
    [Export]
    public double pitch_sensitivity = 0.1f;
    [Export]
    public double pan_sensitivity = 0.1f;
    [ExportGroup("Limits")]
    [Export]
    public float pitch_upper_limit = 45.0f;
    [Export]
    public float pitch_lower_limit = -45.0f;

    public modular_camera_resource(){}
    
}
