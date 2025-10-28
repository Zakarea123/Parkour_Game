namespace Testing.Logic;

public class PlayerLogic
{
    public CharacterState CurrentState { get; private set; } = CharacterState.Idle;
    public float RollTimer { get; private set; } = 0f;

    private readonly float _rollDuration;

    public PlayerLogic(float rollDuration)
    {
        _rollDuration = rollDuration;
    }
    
    // Declare states of the player 
    public void SetIdle()=> CurrentState = CharacterState.Idle;
    public void SetRunning()=> CurrentState = CharacterState.Running;
    public void SetDying()=> CurrentState = CharacterState.Dying;

    // Trigger Jump state
    public void Jump()
    {
        if (CurrentState == CharacterState.Dying) return;
        CurrentState = CharacterState.Jumping;
    }

    // Starts a roll action and resets the roll timer.
    public void StartRoll()
    {
        if (CurrentState == CharacterState.Dying) return;
        CurrentState = CharacterState.Rolling;
        RollTimer = _rollDuration;
    }

    // Updates the roll timer each frame and resets state to Idle when the roll ends.
    public void UpdateRoll(double delta)
    {
        if (CurrentState != CharacterState.Rolling) return;

        RollTimer -= (float)delta;
        if (RollTimer <= 0f)
            CurrentState = CharacterState.Idle;
    }
}