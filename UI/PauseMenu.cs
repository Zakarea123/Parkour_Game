using Godot;
using System;

public partial class PauseMenu : Control
{
	private AnimationPlayer animationPlayer;
	private bool paused = false;

	public override void _Ready()
	{
		animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer"); 
		Console.WriteLine("Pause Menu is Ready");
		Visible = false;     
		
		GetNode<Button>("PanelContainer/VBoxContainer/ResumeButton").Pressed += OnResumePressed;
		GetNode<Button>("PanelContainer/VBoxContainer/ExitButton").Pressed += OnExitPressed;
	}

	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("pause"))
		{
			Console.WriteLine("Paused");
			if (!paused)
				Pause();
			
			else
				Resume();
		}
		
	}

	// Fade out and pause the game 
	private void Pause()
	{
		Visible = true;
		animationPlayer.Play("Blur");
		GetTree().Paused = true;
		paused = true;
	}

	// Clear input and fade back into the game 
	private void Resume()
	{
		GetTree().Paused = false;
		animationPlayer.PlayBackwards("Blur");
		paused = false;
		Input.FlushBufferedEvents();   // clears input pressed during pause
		Visible = false;   
	}

	private void OnResumePressed()
	{
		Resume();
	}
	
	// Fade out to Main menu
	private void OnExitPressed()
	{
		GetTree().Paused = false;
		animationPlayer.PlayBackwards("Blur");
		GetTree().ChangeSceneToFile("res://scenes/main_menu.tscn");
	}
}
