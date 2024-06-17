using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using WindowsKitten.Scripts.Utils;

public partial class StateAnim : Node
{
    [Export] public String AnimationName { get; set; } = "";
    [Export] public int AnimationNumber { get; set; } = 1;
    [Export] public float AnimationChance { get; set; } = 0.5f;
}