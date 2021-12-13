using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HexStrategyGame.MapData;

namespace HexStrategyGame.ScenarioData
{
  public class Scenario
  {
    public Map map;
    public Cursor cursor;

    public Scenario()
    {
      map = new Map(10, 10);
      cursor = new Cursor(map);
    }
  }
}
