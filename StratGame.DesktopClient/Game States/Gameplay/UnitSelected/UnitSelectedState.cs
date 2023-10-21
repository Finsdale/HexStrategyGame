using ControllerInput;
using HexStrategyGame.Artists;
using HexStrategyGame.MapData;
using HexStrategyGame.ScenarioData;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexStrategyGame.Gameplay
{
  public class UnitSelectedState : IGameState
  {
    readonly GameStateMachine gameStateMachine;
    readonly UnitSelectedPatron patron;
    readonly Scenario scenario;

    public UnitSelectedState(GameStateMachine gameStateMachine) {
      this.gameStateMachine = gameStateMachine;
      scenario = gameStateMachine.Scenario;
      patron = new UnitSelectedPatron(scenario);
    }
     
    public void Update(Input input)
    {
      if (input.cancel.Pressed) {
        scenario.UnitSelectedStateCancelAction();
        gameStateMachine.Pop();
      } 
      else if (input.confirm.Pressed) {
        if (scenario.CursorPositionIsWithinUnitRange()) {
          scenario.SetUnitDestinationToCursorLocation();
          gameStateMachine.Pop();
          gameStateMachine.Push(gameStateMachine.unitMovingState);
        }
      }
      else {
        scenario.UnitSelectedStateCursorMovement(input);
      }
    }

    public void Draw(IArtist artist) {
      patron.Draw(artist);
    }
  }
}
