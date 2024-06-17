using Godot;
using System;

public partial class Fall : AutoAnimatedState
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
		_kitten.OnGrabStateChange += OnGrabStateChange;
		
		// EndPlay() like method
		TreeExiting += OnTreeExit;
	}

	private void OnTreeExit()
	{
		_kitten.OnGrabStateChange -= OnGrabStateChange;
	}
	
	
	private void OnGrabStateChange(bool bIsGrab)
	{
		if (!bIsGrab)
		{
			_stateMachine.ChangeState("Fall");
		}
	}
}
