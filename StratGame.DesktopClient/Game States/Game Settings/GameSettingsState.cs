using ControllerInput;
using HexStrategyGame.MapData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace HexStrategyGame.GameSettings
{
  public class GameSettingsState : IGameState
  {
        readonly GameStateMachine gameStateMachine;
        readonly IPatron artist;

        public GameSettingsState(GameStateMachine gameStateMachine)
    {
      this.gameStateMachine = gameStateMachine;
      artist = new GameSettingsArtist();
    }

    public void Update(Input input)
    {
      if(input.cancel.Pressed == true)
      { 
        gameStateMachine.Pop();
        gameStateMachine.Push(gameStateMachine.mainMenuState);
      } else if(input.confirm.Pressed == true)
      {
        gameStateMachine.Pop();
        gameStateMachine.Push(gameStateMachine.mapStateMachine);
        gameStateMachine.Push(gameStateMachine.cursorPlayState);
      }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
            artist.Draw(spriteBatch);
    }
  }
}
