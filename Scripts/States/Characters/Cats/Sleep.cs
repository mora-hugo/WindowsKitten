using Godot;
using System;

public partial class Sleep : AutoAnimatedState
{
    kitten _kitten;
    
    public override void _Ready()
    {
        base._Ready();
        _kitten = (kitten)Owner;
        
    }

    public override void Enter()
    {
        base.Enter();
        _kitten.SetPhysicsProcess(false);
        _kitten.Position = Vector2.Zero + Vector2.Up*15;
    }

    public override void Exit()
    {
        base.Exit();
        _kitten.Reparent(GetTree().Root);
        _kitten.SetPhysicsProcess(true);
    }
}
