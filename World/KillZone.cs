using Godot;
using System;

public partial class KillZone : Area2D
{
    private AnimatedSprite2D sprite;
    
    public async void _on_body_entered(Node body)
    {
        // Remove 1 heart when colliding with the Kill zone
        if (body is Player player)
        {
           await GameManager.Instance.DamagePlayer();
        }
    }

}

