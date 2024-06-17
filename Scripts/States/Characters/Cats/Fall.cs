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
	
	public override void Enter()
	{
		base.Enter();
		_kitten.OnIsOnGroundUpdate += OnIsOnGroundUpdated;

	}
	public override void Exit()
	{
		base.Exit();
		_kitten.OnIsOnGroundUpdate -= OnIsOnGroundUpdated;
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
	
	private void OnIsOnGroundUpdated(bool bIsOnGround)
	{
		if (bIsOnGround)
		{
			_stateMachine.ChangeState("Idle");
		}
	}
}
