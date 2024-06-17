using Godot;
using System;

public partial class MainMenu : Control
{

	private TextureButton OpenMenuBtn;
	private TextureButton CloseMenuBtn;
	private Panel MenuPanel;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		OpenMenuBtn = GetNode<TextureButton>("OpenMenuBtn");
		OpenMenuBtn.Pressed += OnMenuPressed;
		
		CloseMenuBtn = GetNode<TextureButton>("MenuPanel/CloseMenuBtn");
		CloseMenuBtn.Pressed += OnCloseMenuPressed;

		MenuPanel = GetNode<Panel>("MenuPanel");
		MenuPanel.Hide();
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
