using Godot;
using System;
using System.Collections.Generic;
using Godot.Collections;
using Array = System.Array;

public partial class MainMenu : Control
{
	private List<ShopItem> ShopObjects;
	[Export] private CompressedTexture2D BaseFoodIcon;
	
	private TextureButton OpenMenuBtn;
	private TextureButton CloseMenuBtn;
	
	private Panel MenuPanel;
	private VBoxContainer ShopContainer;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		OpenMenuBtn = GetNode<TextureButton>("OpenMenuBtn");
		OpenMenuBtn.Pressed += OnMenuPressed;
		
		CloseMenuBtn = GetNode<TextureButton>("MenuPanel/CloseMenuBtn");
		CloseMenuBtn.Pressed += OnCloseMenuPressed;

		MenuPanel = GetNode<Panel>("MenuPanel");
		MenuPanel.Hide();

		ShopContainer = GetNode<VBoxContainer>("MenuPanel/ScrollContainer/ShopContainer");
		
		// Create Object list

		ShopObjects = new List<ShopItem>();

		foreach (Node node in GetChildren())
		{
			if (node is ShopItem Object)
			{
				ShopObjects.Add(Object);
			}
		}
		
		
		
		foreach (var item in ShopObjects)
		{
			HBoxContainer ItemContainer = new HBoxContainer();

			// Icon
			TextureRect ItemText = new TextureRect();
			ItemText.Texture = item.ObjectIcon;
			
			ItemContainer.AddChild(ItemText);
			
			// Price
			Label ItemPrice = new Label();
			ItemPrice.Text = item.ObjectPrice.ToString();
			ItemPrice.HorizontalAlignment = HorizontalAlignment.Center;
			ItemPrice.SizeFlagsHorizontal = SizeFlags.ExpandFill;
			
			ItemContainer.AddChild(ItemPrice);
			
			// Food Icon
			TextureRect FoodIcon = new TextureRect();
			FoodIcon.Texture = BaseFoodIcon;
			FoodIcon.ExpandMode = TextureRect.ExpandModeEnum.FitWidth;
			FoodIcon.StretchMode = TextureRect.StretchModeEnum.KeepCentered;
			
			ItemContainer.AddChild(FoodIcon);
			
			// Buy Btn
			Button BuyBtn = new Button();
			BuyBtn.Text = "Buy";

			BuyBtn.Pressed += delegate { BuyBtnOnPressed(item.ObjectToSpawn); };

			ItemContainer.AddChild(BuyBtn);
			
			ShopContainer.AddChild(ItemContainer);

		}
		
		

	}

	private void BuyBtnOnPressed(PackedScene value)
	{
		Node NewObject = value.Instantiate();
		GetNode<Node>("../").AddChild(NewObject);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}

	private void OnCloseMenuPressed()
	{
		OpenMenuBtn.Show();
		MenuPanel.Hide();
	}

	

	public void OnMenuPressed()
	{
		OpenMenuBtn.Hide();
		MenuPanel.Show();
	}
}
