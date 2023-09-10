using ControllerInput;
using HexStrategyGame.Artists;
using HexStrategyGame.Game_States.Gameplay.UnitSelected;
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
    public UnitSelectedState(GameStateMachine gameStateMachine) {
      this.gameStateMachine = gameStateMachine;
      this.patron = new UnitSelectedPatron();
    }
     
    public void Update(Input input)
    {
      if (input.cancel.Pressed) {
        gameStateMachine.Pop();
      }
    }

    public void Draw(IArtist artist) {
      patron.Draw(artist);
    }
  }
}
