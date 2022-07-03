using ControllerInput;
using HexStrategyGame.MapData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexStrategyGame.GameSettings
{
  public class GameSettingsState : IGameState
  {
        readonly GameStateMachine gameStateMachine;
        readonly IArtist artist;
        readonly Map map;

    public GameSettingsState(GameStateMachine gameStateMachine)
    {
      this.gameStateMachine = gameStateMachine;
      artist = new GameSettingsArtist();
      map = new Map(10, 10);
    }

    public void Update(Input input)
    {
      if(input.cancel.Pressed == true)
      {
        gameStateMachine.GameState = gameStateMachine.mainMenuState;
      } else if(input.confirm.Pressed == true)
      {
        gameStateMachine.Scenario.map = map;
        gameStateMachine.GameState = gameStateMachine.playStateMachine;
      }
    }

    public IArtist GetArtist()
    {
      return artist;
    }
  }
}
