using System.Collections.Generic;
using Microsoft.Xna.Framework;
using HexStrategyGame.Game_States.Gameplay.Camera;
using HexStrategyGame.MapData;
using HexStrategyGame.ScenarioData.Players;

namespace HexStrategyGame.ScenarioData
{
  public class Scenario
  {
    public Camera camera;
    public Map map;
    public Cursor cursor;
    public List<Player> Players;

    public Scenario()
    {
      map = new Map(28, 18);
      camera = new Camera(map, new Point(2,2));
      cursor = new Cursor(map, camera);
      Players = new List<Player>
      {
        new Player("Player1"),
        new Player("Player2")
      };
      Players[0].AddUnit(new Unit(new Point(5, 5)));
      map.GetTileAtLocation(new Point(5, 5)).HasUnit = true;
    }
  }
}
