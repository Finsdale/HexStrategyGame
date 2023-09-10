using ControllerInput;
using HexStrategyGame.Artists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexStrategyGame.Gameplay
{
  public class GameMenuState: IGameState
  {
    readonly GameStateMachine gameStateMachine;
    readonly GameMenuPatron patron;
    public GameMenuState(GameStateMachine gameStateMachine)
    {
      this.gameStateMachine = gameStateMachine;
      patron = new GameMenuPatron();
    }
    public void Update(Input input)
    {
      if (input.cancel.Pressed) {
        gameStateMachine.Pop();
      }
    }
    public void Draw(IArtist artist)
    {
      patron.Draw(artist);
    }
  }
}
