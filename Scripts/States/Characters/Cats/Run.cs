using Godot;
using System;

public partial class Run : BaseAnimatedSpriteState
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
		GD.Print("Entering Run State");
		_animatedSprite.Play("Run");
		await ToSignal(GetTree().CreateTimer(2), "timeout");
		_stateMachine.ChangeState("Idle");
	}
	
	public override async void Exit()
	{
		GD.Print("Exiting Run State");
	}
}
