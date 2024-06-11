using Godot;
using System;

[Tool]
public partial class modular_camera : Marker3D
{

    [Export]
    public modular_camera_resource _camera_data = new modular_camera_resource();
    public Camera3D _camera;
    private Vector2 _mouse_motion;
    private double _pan_inverse_coefficient;
    private double _pitch_inverse_coefficient;
    public override void _Ready()
    {
        this.Position = _camera_data.pivot_offset;
        _camera = new Camera3D();
        AddChild(_camera);
        _camera.Position = _camera_data.camera_offset;
        Input.MouseMode = Input.MouseModeEnum.Captured;
        if(_camera_data.invert_pan){
            _pan_inverse_coefficient = -1.0f;
        }else{
            _pan_inverse_coefficient = 1.0f;
        }

        if(_camera_data.invert_pitch){
            _pitch_inverse_coefficient = -1.0f;
        }else{
            _pitch_inverse_coefficient = 1.0f;
        }
        _camera_data.Changed += OnCameraDataChanged;
    }

    public override void _PhysicsProcess(double delta)
    {
        //PAN
        this.Basis = this.Basis.Rotated(Vector3.Up,_mouse_motion.X * (float)delta);

        //PITCH
        float _pitch_change = _mouse_motion.Y * (float)delta;
        _pitch_change = Mathf.Clamp(_pitch_change,Mathf.DegToRad(_camera_data.pitch_lower_limit)-this.Rotation.X,Mathf.DegToRad(_camera_data.pitch_upper_limit)-this.Rotation.X);
        this.Basis = this.Basis.Rotated(this.Basis.X, _pitch_change);
        
        this.Basis = this.Basis.Orthonormalized();
        _mouse_motion = Vector2.Zero;
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        
        if(@event is InputEventMouseMotion mouseInput){
            _mouse_motion = Vector2.Zero;
            double mouse_motion_x = _pan_inverse_coefficient*mouseInput.Relative.X*_camera_data.pan_sensitivity;
            double mouse_motion_y = _pitch_inverse_coefficient* mouseInput.Relative.Y*_camera_data.pitch_sensitivity;
            if(Math.Abs(mouse_motion_x) >= _camera_data.pan_threshold){
                _mouse_motion.X = (float)mouse_motion_x;
            }
            if(Math.Abs(mouse_motion_y) >= _camera_data.pitch_threshold){
                _mouse_motion.Y = (float)mouse_motion_y;
            }
            
        }
    }

    public void OnCameraDataChanged(){
        GD.Print("Camera settings changed");
        this.Position = _camera_data.pivot_offset;
        _camera.Position = _camera_data.camera_offset;
        Input.MouseMode = Input.MouseModeEnum.Captured;
        if(_camera_data.invert_pan){
            _pan_inverse_coefficient = -1.0f;
        }else{
            _pan_inverse_coefficient = 1.0f;
        }

        if(_camera_data.invert_pitch){
            _pitch_inverse_coefficient = -1.0f;
        }else{
            _pitch_inverse_coefficient = 1.0f;
        }
    }
}
