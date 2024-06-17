using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using WindowsKitten.Scripts.Utils;

public partial class AutoAnimatedState : BaseAnimatedSpriteState
{
	private List<StateAnim> _stateAnims = new List<StateAnim>();
	private List<String> _animationQueue = new List<String>();

	

	public override void _Ready()
	{
		base._Ready();
		float chance = 0.0f;
		foreach (Node child in GetChildren())
		{
			if (child is StateAnim animChild)
			{
				_stateAnims.Add(animChild);
				chance += (animChild.AnimationChance);
			}
		}
	}

	public override async void Enter()
	{
		_animatedSprite.AnimationFinished += OnAnimationFinished;
		
		PlayNextAnimation();
	}
	
	public override async void Exit()
	{
		_animatedSprite.AnimationFinished -= OnAnimationFinished;
		
	}
	

	
	private void OnAnimationFinished()
	{
		PlayNextAnimation();
	}

	private void PlayRandomAnimation()
	{
		float chance = 0.0f;
		float random = Utils.GetRandomFloatInRange(0, 1);
		foreach (StateAnim anim in _stateAnims)
		{
			chance += anim.AnimationChance;
			if (random <= chance)
			{
				PlayAnimation(anim);
				return;
			}
			
		}

		// 
		if (_animationQueue.Count > 0)
		{
			PlayAnimation(_stateAnims.First());

		}
		
	}

	private void PlayAnimation(StateAnim anim)
	{
		_animationQueue.Clear();
		if (anim.AnimationNumber == 0)
		{
			return;
		}
		
		for(int i = 0; i < anim.AnimationNumber; i++)
		{
			_animationQueue.Add(anim.AnimationName);
		}
		PlayNextAnimation();
		
	}

	private void PlayNextAnimation()
	{
		if (_animationQueue.Count > 0)
		{
			_animatedSprite.Play(_animationQueue[0]);
			_animationQueue.RemoveAt(0);
		}
		else
		{
			PlayRandomAnimation();
		}
	}
}
