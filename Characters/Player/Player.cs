using Godot;
using System.Threading.Tasks;
using Testing;
using Testing.Logic;

public partial class Player : CharacterBody2D
{
	// Constants 
	public const float Speed = 130.0f;
	public const float JumpVelocity = -300.0f;
	public const float RollSpeed = 100.0f;
	public const float RollDuration = 0.5f;
	
	// Components
	private AnimatedSprite2D sprite;
	private Label scoreLabel;
	private Label endScoreLabel;
	private PlayerInputHandler inputHandler;
	private PlayerLogic _logic;
	
	
	internal float facingDirection = 1;
	internal bool canMove = true;
	
	
	public override void _Ready()
	{
		// Initialize helpers
		_logic = new PlayerLogic(RollDuration);
		inputHandler = new PlayerInputHandler(this, _logic);
		
		sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		scoreLabel = GetNode<Label>("../../UI/CanvasLayer/Score");
		endScoreLabel = GetNode<Label>("../../Labels/TheScore");
		
		if (GameManager.Instance != null)
		{
			GameManager.Instance.SetSpawnPoint(GlobalPosition);
			GameManager.Instance.OnScoreChanged += UpdateScore;
			//Initialize the label immediately with the current score
			UpdateScore(GameManager.Instance.Score);
		}
	}
	

	public override void _PhysicsProcess(double delta)
	{
		
		if (!canMove)
			return;
		
		if (_logic.CurrentState == CharacterState.Dying)
		{
			// keep FlipH but don't accept input/move/change states
			UpdateAnimation();
			return;
		}
		ApplyGravity(delta);
		inputHandler.ProcessInput();
		_logic.UpdateRoll(delta);
		MoveAndSlide();
		
		// Air/land transitions
		if (!IsOnFloor() && _logic.CurrentState != CharacterState.Jumping && _logic.CurrentState != CharacterState.Rolling)
			_logic.Jump();

		if (_logic.CurrentState == CharacterState.Jumping && IsOnFloor())
		{
			if (Mathf.Abs(Velocity.X) > 0)
				_logic.SetRunning();
			else
				_logic.SetIdle();
		}
		
		UpdateAnimation();
	}
	
	
	public override void _ExitTree()
	{
		// Unsubscribe when destroyed to avoid memory leaks
		if (GameManager.Instance != null)
			GameManager.Instance.OnScoreChanged -= UpdateScore;
	}
	
	
	public void UpdateScore(int newScore)
	{
		scoreLabel.Text = $"Score: {newScore}";
		endScoreLabel.Text = $"Level Completed \n End Score: {newScore} /22";
		
	}
	
	// Sets an animation to each state 
	private void UpdateAnimation()
	{
		sprite.FlipH = facingDirection < 0;

		switch (_logic.CurrentState)
		{
			case CharacterState.Dying: 
				if (sprite.Animation != "death")
					sprite.Play("death");
				break;
			case CharacterState.Idle:
				sprite.Play("idle");
				break;
			case CharacterState.Running:
				sprite.Play("sprint");
				break;
			case CharacterState.Jumping:
				sprite.Play("jump");
				break;
			case CharacterState.Rolling:
				sprite.Play("roll");
				break;
		}
	}
	
	
	private void ApplyGravity(double delta)
	{
		Vector2 velocity = Velocity;

		if (!IsOnFloor())
			velocity += GetGravity() * (float)delta;

		Velocity = velocity;
	}

	
	public async Task Die()
	{
		if (_logic.CurrentState == CharacterState.Dying)
		{
			return;
		}
		_logic.SetDying();
		Velocity = Vector2.Zero;
		// Slow down time for dramatic effect
		Engine.TimeScale = 0.5;
		sprite.Play("death");
		// Wait for 0.6 seconds (in real time)
		await ToSignal(GetTree().CreateTimer(0.6), SceneTreeTimer.SignalName.Timeout);
		Engine.TimeScale = 1;
		GetTree().ReloadCurrentScene();
	}
	
}
