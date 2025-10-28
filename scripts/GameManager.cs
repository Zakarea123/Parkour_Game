using Godot;
using System;
using System.Threading.Tasks;

public partial class GameManager : Node
{
    // --- Singleton Instance ---
    public static GameManager Instance { get; private set; }
    
    // --- Player & Game Data ---
    public int MaxHearts { get; private set; } = 3;
    public int CurrentHearts { get; private set; }
    public int Score { get; private set; } = 0;
    public Vector2 SpawnPoint { get; private set; }
    
    private Player player;

    // Events
    public event Action<int> OnScoreChanged;
    public event Action<int> OnHeartsChanged;
    
    public override void _EnterTree()
    {
        // Ensure only one instance exists
        Instance = this;
    }

    public override void _ExitTree()
    {
        if (Instance == this) Instance = null;
    }
    
    
    public override void _Ready()
    {
        // Initialize hearts and notify listeners
        CurrentHearts = MaxHearts;
        OnHeartsChanged?.Invoke(CurrentHearts);

        player = GetNode<Player>("../Characters/Player");
    }
    
    // --- Player Damage & Respawn ---
    public async Task DamagePlayer()
    {
        if (CurrentHearts <= 0)
        {
            return;
        }
        
        CurrentHearts--;
        
        OnHeartsChanged?.Invoke(CurrentHearts);

        if (CurrentHearts <= 0)
        {
            Console.WriteLine("Game Over");
           await player.Die();
           return;
           
        } 
        await RespawnPlayer();
    }
    
    
    public async Task RespawnPlayer()
    {
        await Task.Delay(100);
        player.GlobalPosition = SpawnPoint;
        player.Velocity = Vector2.Zero;
    }
    
    
    // Set the spawn point (when scene loads)
    public void SetSpawnPoint(Vector2 position)
    {
        SpawnPoint = position;
    }
    
    // --- Score Management ---
    public void AddScore(int amount = 1)
    {
        Score += amount;
        OnScoreChanged?.Invoke(Score);
    }

    public void ResetScore()
    {
        Score = 0;
        OnScoreChanged?.Invoke(Score);
    }
}
