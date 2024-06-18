using Godot;
using static WindowsKitten.Scripts.Utils.Utils;

public partial class Run : AutoAnimatedState
{
    kitten _kitten;
    
    private CharacterBody2D characterBody2D;
    
    private Timer MoveTimer;

    private Vector2 Direction = Vector2.Right;

    [Export] private float RunSpeed = 13;

    public override void _Ready()
    {
        base._Ready();
        
        _kitten = (kitten)Owner;

        characterBody2D = (CharacterBody2D)Owner;

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

        Direction *= -1;

        if (Direction == Vector2.Right)
        {
            _kitten.CatSprite.FlipH = false;
        }
        else
        {
            _kitten.CatSprite.FlipH = true;
        }
        
        
        MoveTimer.Start(GetRandomFloatInRange(2,10));
    }

    public override void Exit()
    {
        base.Exit();
        
        MoveTimer.Stop();

        characterBody2D.Velocity = Vector2.Zero;
        
        SetProcess(false);
    }

    public override void StateProcess(double delta)
    {
        base.StateProcess(delta);
        
        characterBody2D.Velocity = Direction * RunSpeed;

        if (characterBody2D.GetLastSlideCollision().GetCollider() is RigidBody2D)
        {
            _stateMachine.ChangeState("Idle");
        }


    }
}
