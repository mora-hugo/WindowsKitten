using Godot;
using System;

public partial class ShopItem : Node
{
	[Export] public CompressedTexture2D ObjectIcon;
	[Export] public int ObjectPrice = 100;
	[Export] public PackedScene ObjectToSpawn = null;
}
