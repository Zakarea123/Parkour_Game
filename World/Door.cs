using Godot;
using System;
using System.Threading.Tasks;

public partial class Door : Area2D
{
    [Export] private string targetScenePath = "";
    private bool bodyEnterd = false;
    private Player player;
    private Label interactionLabel;

    public override void _Ready()
    {
        BodyEntered += OnBodyEntered;
        BodyExited += OnBodyExited;
        interactionLabel = GetNode<Label>("InteractionLabel");
    }
    

    public override async void _Process(double delta)
    {

        if (bodyEnterd && Input.IsActionJustPressed("Enter") && !string.IsNullOrEmpty(targetScenePath))
        {
            // prevent player movement while loading
            if (player != null)
                player.canMove = false;
            
            if (interactionLabel != null)
                interactionLabel.Text = "Loading...";
            await Task.Delay(1000);
            
            GetTree().ChangeSceneToFile(targetScenePath);
        }
    }
    
    
    public void OnBodyEntered(Node2D body)
    {
        Console.WriteLine("Body Enterd");
        if (body is Player)
            bodyEnterd = true;
        interactionLabel.Text = "Press E to Enter";
    }
    
    
    public void OnBodyExited(Node2D body)
    {
        Console.WriteLine("Body exited");
        if (body is Player)
            bodyEnterd = false;
        interactionLabel.Text = "";
    }
    
    
    
}
