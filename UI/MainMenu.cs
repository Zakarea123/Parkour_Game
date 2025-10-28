using Godot;
using System;

public partial class MainMenu : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetNode<Button>("VBoxContainer/StartButton").Pressed += OnStartGamePressed;
		GetNode<Button>("VBoxContainer/ExitButton").Pressed += OnExitGamePressed;
	}

	// Start game button logic
	private void OnStartGamePressed()
	{
		GetTree().ChangeSceneToFile("res://scenes/game.tscn");
	}
	
	// Exit game button logic
	private void OnExitGamePressed()
	{
		GetTree().Quit();
	}
	
}
