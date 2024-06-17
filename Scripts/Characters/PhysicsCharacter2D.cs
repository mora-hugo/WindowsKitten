using Godot;
using System;

public partial class PhysicsCharacter2D : CharacterBody2D
{
	
	// Get the gravity from the project settings to be synced with RigidBody nodes.
	private float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	private CollisionShape2D collisionShape;
	private bool isOnGround = false;
	[Export] protected float GravityScale = 1;

	[Signal]
	public delegate void OnIsOnGroundUpdateEventHandler(bool bIsGrabbed);
	
	public override void _Ready()
	{
		base._Ready();
		collisionShape = GetNode<CollisionShape2D>("KittenCols");
	}

	public bool IsOnGround()
	{
		
		//Cast to cube shape
		if (collisionShape.Shape is RectangleShape2D rect)
		{
			var spaceState = GetWorld2D().DirectSpaceState;
			var query = PhysicsRayQueryParameters2D.Create(Position, Position + new Vector2(0, rect.Size.Y+1));
			return spaceState.IntersectRay(query).Count > 0;
		}

		return false;

	}
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		bool bNewIsOnGround = IsOnGround();
		if(bNewIsOnGround != isOnGround)
		{
			isOnGround = bNewIsOnGround;
			EmitSignal(SignalName.OnIsOnGroundUpdate, isOnGround);
		}
		
		if (!isOnGround)
		{
			velocity.Y += gravity * GravityScale * (float)delta;
		}

		Velocity = velocity;
		MoveAndCollide(Velocity*(float)delta);
		
	}
}
