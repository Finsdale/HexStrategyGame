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
    GameStateMachine gameStateMachine;
    UnitMovingPatron patron;
    Scenario scenario;

    public UnitMovingState(GameStateMachine gameStateMachine)
    {
      this.gameStateMachine = gameStateMachine;
      scenario = gameStateMachine.Scenario;
      patron = new UnitMovingPatron(scenario);
    }
    public void Update(Input input)
    {
      if(input.cancel.Pressed) {
        scenario.ClearUnitMovement();
        gameStateMachine.Pop();
        gameStateMachine.Push(gameStateMachine.unitSelectedState);
      }
      else {
        scenario.UpdateUnitMovement();
        if(scenario.IsUnitMovementComplete()) {
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
