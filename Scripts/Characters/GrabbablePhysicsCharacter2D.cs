using Godot;
using System;

public partial class GrabbablePhysicsCharacter2D : PhysicsCharacter2D
{
	public bool bIsGrabbed = false;
	private float BaseGravityScale;
	[Export] private bool bShouldUnGrabApplyVelocity = true;
	[Export] private double MinXVelocityWhenUngrabbed = -500;
	[Export] private double MaxXVelocityWhenUngrabbed = 500;
	[Export] private double MinYVelocityWhenUngrabbed = -500;
	[Export] private double MaxYVelocityWhenUngrabbed = 500;
	
	// Signals
	[Signal]
	public delegate void OnGrabStateChangeEventHandler(bool bIsGrabbed);
	
	
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
		BaseGravityScale = GravityScale;
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		base._Process(delta);
		if (bIsGrabbed)
		{
			if (Input.IsActionJustReleased("Interact"))
			{
				bIsGrabbed = false;
				EmitSignal(SignalName.OnGrabStateChange, bIsGrabbed);
				GravityScale = BaseGravityScale;

				if (bShouldUnGrabApplyVelocity)
				{
					Vector2 v2D = Input.GetLastMouseVelocity();
					Vector2 v2Dc;
					v2Dc.X = (float)Math.Clamp(v2D.X, MinXVelocityWhenUngrabbed, MaxXVelocityWhenUngrabbed);
					v2Dc.Y = (float)Math.Clamp(v2D.Y, MinYVelocityWhenUngrabbed, MaxYVelocityWhenUngrabbed);
					Velocity = v2Dc;
				}
				
			}
			else
			{
				GlobalPosition = GetGlobalMousePosition();
			}
			
		}
	}
	
	public override void _InputEvent(Viewport viewport, InputEvent @event, int shapeIdx)
	{
		base._Input(@event);
		if(@event is InputEventMouseButton MouseBtnEvent){

			if (MouseBtnEvent.IsPressed())
			{
				bIsGrabbed = true;
				EmitSignal(SignalName.OnGrabStateChange, bIsGrabbed);
				GravityScale = 0;
			}

		}
	}

	public virtual void _OnGrab()
	{
		
	}
}
