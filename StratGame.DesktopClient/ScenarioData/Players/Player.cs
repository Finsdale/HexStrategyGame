using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexStrategyGame.ScenarioData.Players
{
  internal class Player
  {
    public string Name { get; set; }
    List<Unit> UnitList { get; set; }

    public Player(string name)
    {
      Name = name;
      UnitList = new List<Unit>();
    }

    public Unit GetUnit(Point unitLocation)
    {
      return UnitList.First(x => x.Location == unitLocation);
    }
  }
}
