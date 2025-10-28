using Godot;
using System;

public partial class SlimeEnmey : Node2D
{
	private int Speed = 30;
	private int Direction = 1;
	private RayCast2D rayLeft;
	private RayCast2D rayRight;
	private RayCast2D rayGround;
	private AnimatedSprite2D sprite;

	public override void _Ready()
	{
		rayLeft = GetNode<RayCast2D>("RayCastLeft");
		rayRight = GetNode<RayCast2D>("RayCastRight");
		rayGround = GetNode<RayCast2D>("RayCastGround");
		sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		
	}
	
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		// Handles enemy movement and automatically flips direction when colliding with walls or reaching edges
		if (rayRight.IsColliding())
		{
			Direction = -1;
			
		}

		if (rayLeft.IsColliding())
		{
			Direction = 1;

		}

		if (!rayGround.IsColliding())
		{
			Direction *= -1;
		}

		
		Position += new Vector2(Direction * Speed * (float)delta, 0);
		sprite.FlipH = Direction < 0;
		
	
	}
	
}
