using Godot;
using System;

public partial class kitten : GrabbablePhysicsCharacter2D
{

	public AnimatedSprite2D CatSprite;

	
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();

		CatSprite = GetNode<AnimatedSprite2D>("./CatSprite");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		base._Process(delta);
	}

	public override void _PhysicsProcess(double delta)
	{
		base._PhysicsProcess(delta);
	}
}
