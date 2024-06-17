using Godot;
using System;

public partial class Grab : AutoAnimatedState
{
	kitten _kitten;
    
	public override void _Ready()
	{
		base._Ready();
		_kitten = (kitten)Owner;
		if (_kitten == null)
		{
			GD.Print("Idle: _kitten is null");
		}
		
		//We bind the delegate here because the state can be reach from any other state
		_kitten.OnGrabStateChange += OnGrabStateChange;
		
		// EndPlay() like method
		TreeExiting += OnTreeExit;
	}
	private void OnTreeExit()
	{
	}
	
	private	void OnGrabStateChange(bool bIsGrab)
	{
		if (bIsGrab)
		{
			_stateMachine.ChangeState("Grab");
		}
	}

	public override void Exit()
	{
		base.Exit();
		
	}
}
