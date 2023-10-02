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
    float movementDelay; // using this to pretend to move the unit to its destination

    public UnitMovingState(GameStateMachine gameStateMachine)
    {
      this.gameStateMachine = gameStateMachine;
      scenario = gameStateMachine.Scenario;
      patron = new UnitMovingPatron(scenario);
      movementDelay = 0.0f;
    }
    public void Update(Input input)
    {
      if(input.cancel.Pressed) {
        movementDelay = 0.0f;
        gameStateMachine.Pop();
      }
      else {
        if(movementDelay >= 1.0f) {
          movementDelay = 0.0f;
          gameStateMachine.Pop();
          gameStateMachine.Push(gameStateMachine.unitMenuState);
        }
        else {
          movementDelay += 0.1f;
        }
      }
    }
    public void Draw(IArtist artist)
    {
      patron.Draw(artist);
    }
  }
}
