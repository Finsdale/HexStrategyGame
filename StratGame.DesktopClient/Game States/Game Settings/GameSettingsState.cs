using ControllerInput;
using HexStrategyGame.MapData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using HexStrategyGame.Artists;

namespace HexStrategyGame.GameSettings
{
  public class GameSettingsState : IGameState
  {
        readonly GameStateMachine gameStateMachine;
        readonly IPatron patron;

        public GameSettingsState(GameStateMachine gameStateMachine)
    {
      this.gameStateMachine = gameStateMachine;
      patron = new GameSettingsPatron();
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
        gameStateMachine.Push(gameStateMachine.mapPlayState);
        gameStateMachine.Push(gameStateMachine.cursorPlayState);
      }
    }

    public void Draw(IArtist artist)
    {
            patron.Draw(artist);
    }
  }
}
