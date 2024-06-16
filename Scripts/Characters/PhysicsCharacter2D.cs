using Godot;
using System;

public partial class PhysicsCharacter2D : CharacterBody2D
{
	
	// Get the gravity from the project settings to be synced with RigidBody nodes.
	private float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	[Export] protected float GravityScale = 1;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y += gravity * GravityScale * (float)delta;

		Velocity = velocity;
		MoveAndCollide(Velocity*(float)delta);
	}
}
