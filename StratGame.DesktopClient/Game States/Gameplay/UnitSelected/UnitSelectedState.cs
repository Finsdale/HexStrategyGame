using ControllerInput;
using HexStrategyGame.Artists;
using HexStrategyGame.Game_States.Gameplay.UnitSelected;
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
    Point UnitLocation;
    bool Active;
    Dictionary<Point, int> cost_to_location = new Dictionary<Point, int>();

    public UnitSelectedState(GameStateMachine gameStateMachine) {
      this.gameStateMachine = gameStateMachine;
      patron = new UnitSelectedPatron();
      UnitLocation = new Point();
      Active = false;
    }
     
    public void Update(Input input)
    {
      if (Active) {

        if (input.cancel.Pressed) {
          gameStateMachine.Pop();
        }
      }
    }

    public void Draw(IArtist artist) {
      patron.Draw(artist);
    }

    public bool SelectUnit(Point unitLocation)
    {
      Unit unit = gameStateMachine.Scenario.map.GetTileAtLocation(unitLocation).Unit;
      if (unit != null) {
        UnitLocation = unitLocation;
        Active = true;
      }
      return Active;
    }
  }
}
