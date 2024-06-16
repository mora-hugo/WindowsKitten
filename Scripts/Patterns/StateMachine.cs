using Godot;
using System;
using Godot.Collections;

public partial class StateMachine : Node
{
	State _currentState = null;
	Dictionary<string, State> _states = new Dictionary<string, State>();
	[Export] public String InitialState = "";
	public override void _Ready()
	{
		foreach (Node node in GetChildren())
		{
			if (node is State state)
			{
				
				_states[state.Name.ToString().ToLower()] = state;
				state.SetStateMachine(this);
			}
		}
		ChangeState(InitialState);
		
	}
	
	public void ChangeState(string stateName)
	{
		if (_states.ContainsKey(stateName.ToLower()))
		{
			if (_currentState != null)
			{
				_currentState.Exit();
			}
			
			_currentState = _states[stateName.ToLower()];
			_currentState.Enter();
		}
		else
		{
			GD.PrintErr("State : " + stateName + " not found in the state machine.");
		}
		
	}

	
}
