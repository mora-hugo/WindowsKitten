using Godot;
using System;

public partial class BaseAnimatedSpriteState : State
{

	[Export] public String SpriteNodePath = "";
	protected AnimatedSprite2D _animatedSprite;
	
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_animatedSprite = GetNode<AnimatedSprite2D>(SpriteNodePath);
		if (_animatedSprite == null)
		{
			GD.PrintErr("AnimatedSprite2D not found in the node : " + SpriteNodePath);
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
