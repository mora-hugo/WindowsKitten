using Godot;
using System;

public partial class GrabbableActor : RigidBody2D
{

	private bool bIsGrabbed = false;
	private float BaseGravityScale;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		BaseGravityScale = GravityScale;
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
		if (bIsGrabbed)
		{
			if (Input.IsActionJustReleased("Interact"))
			{
				bIsGrabbed = false;
				GravityScale = BaseGravityScale;

				LinearVelocity = Input.GetLastMouseVelocity();
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
				GravityScale = 0;
			}

		}
	}
}
