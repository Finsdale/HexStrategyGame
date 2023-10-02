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
    public UnitList Units;
    public UnitMovementWrapper UnitRange;
    public string ActivePlayer;

    public Scenario()
    {
      map = new Map(28, 18);
      camera = new Camera(this, new Point(2,2));
      cursor = new Cursor(this);
      Units = new UnitList();
      Players = new List<Player>
      {
        new Player("Player1"),
        new Player("Player2")
      };
      ActivePlayer = Players[0].Name;
      UnitRange = new UnitMovementWrapper();
      Units.AddUnit(new Unit(new Position(2, 5, -7), Players[0].Name));
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
      return Units.GetUnitAtLocation(cursor.Position) != null;
    }

    public bool IsUnitAtLocation(Position location)
    {
      return Units.GetUnitAtLocation(location) != null;
    }

    public Unit GetUnitAtCursorLocation()
    {
      return Units.GetUnitAtLocation(cursor.Position);
    }

    public Unit GetUnitAtLocation(Position position)
    {
      return Units.GetUnitAtLocation(position);
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

    public void SetMovementOptions()
    {
      Unit selectedUnit = Units.RemoveUnit(cursor.Position);
      UnitRange.SetMovementOptions(map, selectedUnit);
    }

    public void CancelMovementOptions()
    {
      Units.AddUnit(UnitRange.ActiveUnit);
      UnitRange.Clear();
    }
    public void SetUnitDestinationToCursorLocation()
    {
      UnitRange.destination = cursor.Position;
    }
    public void CompleteUnitMovement()
    {
      Units.AddUnit(UnitRange.CompleteMovement());
    }
  }
}
