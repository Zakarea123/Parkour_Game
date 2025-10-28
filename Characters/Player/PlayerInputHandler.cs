using Godot;
using Testing.Logic;

namespace Testing;

public class PlayerInputHandler
{
    private readonly Player _player;
    private readonly PlayerLogic _logic;

    public PlayerInputHandler(Player player, PlayerLogic logic)
    {
        _player = player;
        _logic = logic;

    }

    public void ProcessInput()
    {
        // Get movement direction (left/right)
        Vector2 direction = Input.GetVector("left", "right", "jump", "ui_down");

        // Prevent input while rolling or dying
        if (_logic.CurrentState == CharacterState.Rolling || _logic.CurrentState == CharacterState.Dying)
            return;

        HandleMovement(direction);
        HandleJump();
        HandleRoll();
    }

    private void HandleMovement(Vector2 direction)
    {
        // Move and face input direction
        if (direction.X != 0)
        {
            _player.Velocity = new Vector2(direction.X * Player.Speed, _player.Velocity.Y);
            _player.facingDirection = direction.X;

            if (_player.IsOnFloor())
               _logic.SetRunning();
        }
        else
        {
            // Gradually slow down when no input
            _player.Velocity = new Vector2(
                Mathf.MoveToward(_player.Velocity.X, 0, Player.Speed),
                _player.Velocity.Y
            );

            if (_player.IsOnFloor())
                _logic.SetIdle();
        }
    }

    private void HandleJump()
    {
        if (Input.IsActionJustPressed("ui_accept") && _player.IsOnFloor())
        {
            _player.Velocity = new Vector2(_player.Velocity.X, Player.JumpVelocity);
            _logic.Jump();
        }
    }

    private void HandleRoll()
    {
        if (Input.IsActionJustPressed("roll") && _player.IsOnFloor())
        {
            _logic.StartRoll();
            _player.Velocity = new Vector2(_player.facingDirection * Player.RollSpeed * 1.5f, 0);
        }
    }
}