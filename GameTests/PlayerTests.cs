
using GdUnit4;
using Testing.Logic;
namespace Testing.GameTests;
using static GdUnit4.Assertions;
[TestSuite]
public class PlayerTests
{

[TestCase]
public void Constructor_DefaultState_IsIdle()
{
    var logic = new PlayerLogic(0.5f);
    AssertThat(logic.CurrentState).IsEqual(CharacterState.Idle);
}

[TestCase]
public void StartRoll_SetsRollingState()
{
    var logic = new PlayerLogic(0.5f);
    logic.StartRoll();
    AssertThat(logic.CurrentState).IsEqual(CharacterState.Rolling);
}

[TestCase]
public void UpdateRoll_WhenTimerExpires_SetsIdle()
{
    var logic = new PlayerLogic(0.5f);
    logic.StartRoll();
    logic.UpdateRoll(0.6);
    AssertThat(logic.CurrentState).IsEqual(CharacterState.Idle);
}


[TestCase]
public void Jump_WhenDying_DoesNothing()
{
    var logic = new PlayerLogic(0.5f);
    logic.SetDying();
    logic.Jump();
    AssertThat(logic.CurrentState).IsEqual(CharacterState.Dying);
}

[TestCase]
public void SetRunning_ChangesStateToRunning()
{
    var logic = new PlayerLogic(0.5f);
    logic.SetRunning();
    AssertThat(logic.CurrentState).IsEqual(CharacterState.Running);
}
}
