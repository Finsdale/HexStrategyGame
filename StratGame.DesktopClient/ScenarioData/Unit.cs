using HexStrategyGame.Game_States.Gameplay.UnitSelected;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexStrategyGame.ScenarioData
{
  public class Unit
  {
    public Position Position { get; set; }
    public string Player { get; set; }
    public int movement;

    public Unit() { }
    public Unit(Position position, string player)
    {
      Position = position;
      Player = player;
      movement = 7;
    }
  }
}
