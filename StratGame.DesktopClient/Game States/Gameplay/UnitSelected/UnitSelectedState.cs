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
    bool Active;

    public UnitSelectedState(GameStateMachine gameStateMachine) {
      this.gameStateMachine = gameStateMachine;
      scenario = gameStateMachine.Scenario;
      patron = new UnitSelectedPatron();
      Active = false;
    }
     
    public void Update(Input input)
    {
      if(!Active) {
        Active = true;
        scenario.SetMovementOptions();
      }
      if (input.cancel.Pressed) {
        Active = false;
        scenario.CancelMovementOptions();
        gameStateMachine.Pop();
      } 
      if (input.confirm.Pressed) {
        scenario.SetUnitDestinationToCursorLocation();
        gameStateMachine.Push(gameStateMachine.unitMovingState);
      }
    }

    public void Draw(IArtist artist) {
      patron.Draw(artist);
    }
  }
}
