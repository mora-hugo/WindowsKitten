using Godot;
using System;

public partial class Run : AutoAnimatedState
{
    private CharacterBody2D Owner;
    
    private Timer MoveTimer;

    [Export] private float RunSpeed = 13;

    public override void _Ready()
    {
        base._Ready();

        Owner = GetNode<CharacterBody2D>("../../../");

        MoveTimer = new Timer();
        
        AddChild(MoveTimer);

        MoveTimer.Timeout += MoveTimerOnTimeout;

    }

    private void MoveTimerOnTimeout()
    {
        _stateMachine.ChangeState("Idle");
    }

    public override void Enter()
    {
        base.Enter();
        
        SetProcess(true);
        //Owner.MoveAndSlide();
        
        MoveTimer.Start(5);
    }

    public override void Exit()
    {
        base.Exit();
        
        MoveTimer.Stop();

        Owner.Velocity = Vector2.Zero;
        
        SetProcess(false);
    }

    public override void StateProcess(double delta)
    {
        base.StateProcess(delta);
        
        Owner.Velocity = Vector2.Right * RunSpeed;

        if (Owner.GetLastSlideCollision().GetAngle() > 0)
        {
            _stateMachine.ChangeState("Idle");
        }


    }
}
