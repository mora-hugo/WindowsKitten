using Godot;
using System;

public partial class Grab : BaseAnimatedSpriteState
{
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
		GD.Print("Entering Grab State");
		_animatedSprite.Play("Grab");
		//await ToSignal(GetTree().CreateTimer(5), "timeout");
		//_stateMachine.ChangeState("Run");
	}
	
	public override async void Exit()
	{
		GD.Print("Exiting Idle State");
	}
}
