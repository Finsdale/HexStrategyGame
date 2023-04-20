using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HexStrategyGame.Game_States.Gameplay.Camera;
using HexStrategyGame.MapData;

namespace HexStrategyGame.ScenarioData
{
  public class Scenario
  {
    public Camera camera;
    public Map map;
    public Cursor cursor;

    public Scenario()
    {
      map = new Map(30, 30);
      cursor = new Cursor(map);
      camera = new Camera(map);
    }
  }
}
