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
  public class UnitMenuState : IGameState
  {
    GameStateMachine gameStateMachine;
    UnitMenuPatron patron;
    Scenario scenario;

    public UnitMenuState(GameStateMachine gameStateMachine)
    {
      this.gameStateMachine = gameStateMachine;
      scenario = gameStateMachine.Scenario;
      patron = new UnitMenuPatron(scenario);
    }
    public void Update(Input input)
    {
      if (input.cancel.Pressed) {
        gameStateMachine.Pop();
        gameStateMachine.Push(gameStateMachine.unitSelectedState);
      }
      else if (input.confirm.Pressed){
        //I guess we're just waiting for now.
        scenario.CompleteUnitMovement();
        gameStateMachine.Pop();
      }
    }
    public void Draw(IArtist artist) 
    {
      patron.Draw(artist);
    }
  }
}
