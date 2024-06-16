using Godot;
using System;

public partial class Ball : GrabbableActor
{

	private AnimatedSprite2D Sprite;
	[Export] private float RotationOffset = 1;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
		
		Sprite = GetNode<AnimatedSprite2D>("BallSprite");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		base._Process(delta);
	}

	public override void _PhysicsProcess(double delta)
	{
		base._PhysicsProcess(delta);
		
		double v_x = (double)LinearVelocity.X;
		double v_y = (double)LinearVelocity.Y;
		double vLength = Math.Abs(v_x+v_y);
		if (vLength>20)
		{
			Sprite.Play("Flying");
			Sprite.LookAt(GlobalPosition + LinearVelocity);
			Sprite.Rotation += RotationOffset;

		}
		else if (vLength > 1)
		{
			Sprite.Play("SlowFly");
			Sprite.GlobalRotation = 0;
		}
		else
		{
			Sprite.GlobalRotation = 0;
			if (bIsGrabbed)
			{
				Sprite.Play("SlowFly");
			}
			else
			{
				Sprite.Play("Idle");
			}
			
		}
		
	}

	public override void _OnGrab()
	{
		base._OnGrab();
	}
}
