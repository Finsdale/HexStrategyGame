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
    public Point Location { get; set; }
    public bool Selected { get; set; }
    public string Player { get; set; }
    public Unit() { }
    public Unit(Point location, string player)
    {
      Location = location;
      Selected = false;
      Player = player;
    }
  }
}
