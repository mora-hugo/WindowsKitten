using Godot;
using System;

public partial class Run : State
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public override async void Enter()
	{
		GD.Print("Entering Run State");
	}
	
	public override async void Exit()
	{
		GD.Print("Exiting Run State");
	}
}
