using ControllerInput;
using HexStrategyGame.MapData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using HexStrategyGame.Game_States.Gameplay.Camera;
using HexStrategyGame.Artists;
using HexStrategyGame.ScenarioData;

namespace HexStrategyGame.Gameplay
{
  public class CursorPlayState : IGameState
  {
    readonly GameStateMachine gameStateMachine;
    readonly Scenario scenario;
    readonly CursorPatron patron;

    public CursorPlayState(GameStateMachine gameStateMachine)
    {
      this.gameStateMachine = gameStateMachine;
      scenario = gameStateMachine.Scenario;
      patron = new CursorPatron(scenario.cursor, scenario.camera);
    }

    public void Update(Input input)
    {
      if (input.confirm.Pressed)
      {
        if (scenario.IsUnitAtCursorLocation()) {
          if (gameStateMachine.Scenario.ActivePlayer == scenario.GetUnitAtCursorLocation().Player) {
            scenario.SetMovementOptionsForUnitAtCursor();
            gameStateMachine.Push(gameStateMachine.unitSelectedState);
          }
          else {

          }
        }
        else {
          gameStateMachine.Push(new GameMenuState(gameStateMachine));
        }
      }
      else if (input.cancel.Pressed)
      {

      }
      else
      {
        scenario.MoveCursor(input);
      }
    }

    public void Draw(IArtist artist)
    {
      patron.Draw(artist);
    }
  }
}
