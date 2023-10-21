using System.Collections.Generic;
using Microsoft.Xna.Framework;
using HexStrategyGame.Game_States.Gameplay.Camera;
using HexStrategyGame.MapData;
using HexStrategyGame.ScenarioData.Players;
using ControllerInput;
using System.Linq;

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

    public void MoveCursor(Input input)
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

    public Rectangle DestinationRectangleForMovingUnit()
    {
      return new Rectangle(
        ((UnitRange.Leg.X - camera.X) * TileData.xStep) + camera.Offset.X + UnitRange.XMovementOffset(),
        ((UnitRange.Leg.Y - camera.Y) * TileData.yStep) + camera.Offset.Y + UnitRange.YMovementOffset(),
        TileData.width,
        TileData.height);
    }

    public void SetMovementOptions()
    {
      Unit selectedUnit = Units.RemoveUnit(cursor.Position);
      UnitRange.SetMovementOptions(map, selectedUnit);
    }

    public void SetUnitDestinationToCursorLocation()
    {
      UnitRange.destination = cursor.Position;
    }
    public void CompleteUnitMovement()
    {
      Units.AddUnit(UnitRange.CompleteMovement());
    }

    public Position GetActiveUnitPosition()
    {
      return UnitRange.origin;
    }
    public Position GetActiveUnitDestination()
    {
      return UnitRange.destination;
    }

    public bool PositionIsWithinUnitRange(Position position)
    {
      return UnitRange.IsInMovementRange(position);
    }

    public Position GetCursorPosition()
    {
      return cursor.Position;
    }

    public void UpdateUnitRangePath()
    {
      UnitRange.UpdatePath(GetTileAtCursorLocation());
    }

    public void UnitSelectedStateCancelAction()
    {
      cursor.Position = UnitRange.origin;
      Units.AddUnit(UnitRange.ActiveUnit);
      UnitRange.Clear();
    }

    public bool CursorPositionIsWithinUnitRange()
    {
      return PositionIsWithinUnitRange(GetCursorPosition());
    }

    public void UnitSelectedStateCursorMovement(Input input)
    {
      MoveCursor(input);
      UpdateUnitRangePath();
    }

    public void UpdateUnitMovement() 
    {
      UnitRange.UpdateMovement();
    }
    public bool IsUnitMovementComplete()
    {
      return UnitRange.IsUnitAtDestination();
    }

    public void ClearUnitMovement()
    {
      UnitRange.ClearMovement();
    }
  }
}
