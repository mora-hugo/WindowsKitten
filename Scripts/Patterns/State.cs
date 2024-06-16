using Godot;
using System;

public partial class State : Node
{
	protected StateMachine _stateMachine;
	
	public void SetStateMachine(StateMachine stateMachine)
	{
		_stateMachine = stateMachine;
	}
	public virtual async void Enter()
	{
	}
	
	public virtual async void Exit()
	{
	}
}
