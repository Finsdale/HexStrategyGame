using ControllerInput;
using HexStrategyGame.Artists;
using HexStrategyGame.ScenarioData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexStrategyGame.Gameplay
{
  public class UnitMovingState : IGameState
  {
    readonly GameStateMachine gameStateMachine;
    readonly UnitMovingPatron patron;
    readonly Scenario scenario;

    public UnitMovingState(GameStateMachine gameStateMachine)
    {
      this.gameStateMachine = gameStateMachine;
      scenario = gameStateMachine.Scenario;
      patron = new UnitMovingPatron(scenario);
    }
    public void Update(Input input)
    {
      if(input.cancel.Pressed) {
        scenario.ResetActiveUnitMovement();
        gameStateMachine.Pop();
        gameStateMachine.Push(gameStateMachine.unitSelectedState);
      }
      else {
        scenario.MoveActiveUnits();
        if(scenario.HaveActiveUnitsCompletedMovement()) {
          gameStateMachine.Pop();
          gameStateMachine.Push(gameStateMachine.unitMenuState);
        }
      }
    }
    public void Draw(IArtist artist)
    {
      patron.Draw(artist);
    }
  }
}
