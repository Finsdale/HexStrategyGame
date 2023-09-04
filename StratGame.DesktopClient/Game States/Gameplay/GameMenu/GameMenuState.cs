using ControllerInput;
using HexStrategyGame.Artists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexStrategyGame.Gameplay
{
  internal class GameMenuState: IGameState
  {
    readonly GameStateMachine gameStateMachine;
    readonly GameMenuArtist artist;
    public GameMenuState(GameStateMachine gameStateMachine)
    {
      this.gameStateMachine = gameStateMachine;
      this.artist = new GameMenuArtist();
    }
    public void Update(Input input)
    {
      if (input.cancel.Pressed) {
        gameStateMachine.Pop();
      }
    }
    public void Draw(IArtist artist)
    {
      this.artist.Draw(artist);
    }
  }
}
