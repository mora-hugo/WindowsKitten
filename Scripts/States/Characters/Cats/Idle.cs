using Godot;
using System;

public partial class Idle : AutoAnimatedState
{
    private Timer MovingToTimer;
    public override void _Ready()
    {
        base._Ready();

        MovingToTimer = new Timer();
        AddChild(MovingToTimer);
        MovingToTimer.Timeout += MovingToTimerOnTimeout;
    }

    public override void Enter()
    {
        base.Enter();
        
        SetProcess(true);
        
        MovingToTimer.Start(5);
    }

    public override void Exit()
    {
        base.Exit();
        
        MovingToTimer.Stop();
        
        SetProcess(false);
    }

    private void MovingToTimerOnTimeout()
    {
        _stateMachine.ChangeState("Run");
    }
}
