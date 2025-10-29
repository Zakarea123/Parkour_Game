
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

}
