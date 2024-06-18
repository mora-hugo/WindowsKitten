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
		

	}
	public override void Exit()
	{
		base.Exit();
	}

	private void OnTreeExit()
	{
		//_kitten.OnGrabStateChange -= OnGrabStateChange;
	}
	
	
	private void OnGrabStateChange(bool bIsGrab)
	{
		if (!bIsGrab)
		{
			_stateMachine.ChangeState("Fall");
		}
	}

	public override void StateProcess(double delta)
	{
		base.StateProcess(delta);
		if (_kitten.IsOnFloor())
		{

			if (_kitten.GetLastSlideCollision().GetCollider() is Bed bed)
			{
				_kitten.Reparent(bed);
				_stateMachine.ChangeState("Sleep");
			}
			else
			{
				_stateMachine.ChangeState("Idle");
			}
			
			
		}
	}
}
