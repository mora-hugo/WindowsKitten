using Godot;
using System;

public partial class Idle : BaseAnimatedSpriteState
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public override async void Enter()
	{
		GD.Print("Entering Idle State");
		_animatedSprite.Play("Idle");
		await ToSignal(GetTree().CreateTimer(5), "timeout");
		_stateMachine.ChangeState("Run");
	}
	
	public override async void Exit()
	{
		GD.Print("Exiting Idle State");
	}
	
	
}
