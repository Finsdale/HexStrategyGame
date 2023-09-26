using System.Collections.Generic;
using Microsoft.Xna.Framework;
using HexStrategyGame.Game_States.Gameplay.Camera;
using HexStrategyGame.MapData;
using HexStrategyGame.ScenarioData.Players;
using ControllerInput;

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
      camera = new Camera(this, new Point(2,2));
      cursor = new Cursor(this);
      Players = new List<Player>
      {
        new Player("Player1"),
        new Player("Player2")
      };
      ActivePlayer = Players[0].Name;
    }

    public List<Position> VisibleTilePositions()
    {
      return camera.VisibleTiles(map);
    }

    public void DefineCameraValues(int width, int height)
    {
      camera.SetScreenValues(width, height);
    }

    public MapTile GetTileAtMapLocation(Position location)
    {
      return map.GetTileAtLocation(location);
    }

    public bool IsUnitAtCursorLocation()
    {
      return map.GetTileAtLocation(cursor.Position).Unit != null;
    }

    public Unit UnitAtCursorLocation()
    {
      return map.GetTileAtLocation(cursor.Position).Unit;
    }

    public void UpdateCursor(Input input)
    {
      cursor.Update(input);
    }

    public MapTile GetTileAtCursorLocation()
    {
      return map.GetTileAtLocation(cursor.Position);
    }

    public void ClampCameraToPosition(Position point){
      camera.ClampToPosition(point);
    }

    public Rectangle DestinationRectangleForPosition(Position position)
    {
      return camera.DestinationRectangleForPosition(position);
    }
  }
}
