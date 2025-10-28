using Godot;
using System;
using System.Collections.Generic;

public partial class HealthBar : CanvasLayer
{
    private List<AnimatedSprite2D> heartsSprites = new ();


    public override void _Ready()
    {
        var container = GetNode("HBoxContainer");
        heartsSprites.Add(container.GetNode<AnimatedSprite2D>("heart/Heart"));
        heartsSprites.Add(container.GetNode<AnimatedSprite2D>("heart2/Heart"));
        heartsSprites.Add(container.GetNode<AnimatedSprite2D>("heart3/Heart"));

        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnHeartsChanged += UpdateHearts;
            UpdateHearts(GameManager.Instance.CurrentHearts);
        }
    }
    
    
    // Updates the heart icons based on the player's current health.
    private void UpdateHearts(int currentHearts)
    {
        for (int i = 0; i < heartsSprites.Count; i++)
        {
            bool filled = i < currentHearts;
            heartsSprites[i].Visible = filled;
            heartsSprites[i].Play("glowing");
        }
    }

    // Unsub from the Event
    public override void _ExitTree()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.OnHeartsChanged -= UpdateHearts;
    }
}
