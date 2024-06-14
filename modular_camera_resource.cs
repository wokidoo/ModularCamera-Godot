using Godot;
using System;

[Tool]
[GlobalClass]
public partial class modular_camera_resource : Resource
{
    [Signal]
    public delegate void ChangedEventHandler();

    [Export]
    public Godot.Vector3 pivot_offset{
        get{ return _pivot_offset;}
        set{
            _pivot_offset = value;
            EmitSignal("Changed");
        }
    }
    private Godot.Vector3 _pivot_offset = new Vector3(0.0f,0.0f,0.0f);
    [Export]
    public Godot.Vector3 camera_offset{
        get{ return _camera_offset;}
        set{
            _camera_offset = value;
            EmitSignal("Changed");
        }
    }
    private Godot.Vector3 _camera_offset = new Vector3(0.0f,0.0f,0.0f);
    [ExportGroup("Invert")]
    [Export]
    public bool invert_pitch {
        get { return _invert_pitch;}
        set { 
                _invert_pitch = value; 
                EmitSignal("Changed"); 
            }
    }
    private bool _invert_pitch = false;
    
    [Export]
    public bool invert_pan {
        get { return _invert_pan;}
        set { 
                _invert_pan = value; 
                EmitSignal("Changed"); 
            }
    }
    private bool _invert_pan = false;

    [ExportGroup("Threshold")]
    [Export]
    public float pitch_threshold{
        get{return _pitch_threshold;}
        set{
                _pitch_threshold = value;
                EmitSignal("Changed");
        }
    }
    private float _pitch_threshold = 0.1f;
    [Export]
    public float pan_threshold{
        get{return _pan_threshold;}
        set{
                _pan_threshold = value;
                EmitSignal("Changed");
        }
    }
    private float _pan_threshold = 0.1f;
    [ExportGroup("Sensitivity")]
    [Export]
    public double pitch_sensitivity{
        get{ return _pitch_sensitivity;}
        set{
            _pitch_sensitivity = value;
            EmitSignal("Changed");
        }
    }
    private double _pitch_sensitivity = 0.1f;
    [Export]
    public double pan_sensitivity{
        get{ return _pan_sensitivity;}
        set{
            _pan_sensitivity = value;
            EmitSignal("Changed");
        }
    }
    private double _pan_sensitivity = 0.1f;
    
    [ExportGroup("Limits")]
    [Export]
    public float pitch_upper_limit{
        get{ return _pitch_upper_limit;}
        set{
            _pitch_upper_limit = value;
            EmitSignal("Changed");
        }
    }
    private float _pitch_upper_limit = 45.0f;
    [Export]
    public float pitch_lower_limit{
        get{ return _pitch_lower_limit;}
        set{
            _pitch_lower_limit = value;
            EmitSignal("Changed");
        }
    }
    private float _pitch_lower_limit = -45.0f;

    public modular_camera_resource(){}
    
}
