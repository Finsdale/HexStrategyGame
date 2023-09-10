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
    public string ActivePlayer;

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
      ActivePlayer = Players[0].Name;
    }
  }
}
