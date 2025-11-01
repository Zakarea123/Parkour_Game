using Godot;
using System;

public partial class Coin : Area2D

{
	private GameManager gameManager;
    private AnimationPlayer animationPlayer;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		BodyEntered += OnBodyEntered;
		animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
	}
	public void OnBodyEntered(Node body)
	{
		if (body is Player)
		{
			GameManager.Instance?.AddScore(1);
			animationPlayer.Play("pickup");
		}
		
	}
	
}
