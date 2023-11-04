using System.Collections.Generic;
using Microsoft.Xna.Framework;
using HexStrategyGame.Game_States.Gameplay.Camera;
using HexStrategyGame.MapData;
using HexStrategyGame.ScenarioData.Players;
using ControllerInput;
using System.Linq;
using NUnit.Framework.Interfaces;

namespace HexStrategyGame.ScenarioData
{
    public class Scenario
  {
    public Camera camera;
    public Map map;
    public Cursor cursor;
    public List<Player> Players;
    public UnitList Units;
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

    public Position GetCursorPosition()
    {
      return cursor.Position;
    }

    public void CursorPlayStateSelectUnitAtCursorLocation()
    {
      Unit selectedUnit = GetUnitAtCursorLocation();
      selectedUnit.SetMovementOptions(map);
    }

    public void UnitSelectedStateCancelAction()
    {
      List<Unit> activeUnits = CancelUnitMovementForActiveUnits();
      cursor.Position = activeUnits.First().Position;
    }

    private List<Unit> CancelUnitMovementForActiveUnits()
    {
      List<Unit> activeUnits = Units.GetActiveUnits();
      foreach (Unit unit in activeUnits) {
        unit.ClearMovementData();
      }
      return activeUnits;
    }

    public bool CursorPositionIsWithinActiveUnitRange()
    {
      return PositionIsWithinActiveUnitRange(GetCursorPosition());
    }

    public bool PositionIsWithinActiveUnitRange(Position position)
    {
      List<Unit> activeUnits = Units.GetActiveUnits();
      bool result = activeUnits.Count > 0;
      foreach (Unit unit in activeUnits) {
        result &= unit.HasPositionInRange(position);
      }
      return result;
    }

    public void SetActiveUnitDestinationToCursorLocation()
    {
      List<Unit> activeUnits = Units.GetActiveUnits();
      foreach (Unit unit in activeUnits) {
        unit.SetMovementDestination(cursor.Position);
      }
    }

    public void UnitSelectedStateCursorMovement(Input input)
    {
      MoveCursor(input);
      UpdateUnitRangePath();
    }

    public void UpdateUnitRangePath()
    {
      List<Unit> activeUnits = Units.GetActiveUnits();
      foreach (Unit unit in activeUnits) {
        unit.UpdateMovementPath(GetTileAtCursorLocation());
      }
    }

    public void ResetActiveUnitMovement()
    {
      List<Unit> activeUnits = Units.GetActiveUnits();
      foreach (Unit unit in activeUnits) {
        unit.ResetMovement();
      }
    }

    public void MoveActiveUnits()
    {
      List<Unit> activeUnits = Units.GetActiveUnits();
      foreach (Unit unit in activeUnits) {
        unit.Move();
      }
    }

    public bool HaveActiveUnitsCompletedMovement()
    {
      List<Unit> activeUnits = Units.GetActiveUnits();
      bool result = activeUnits.Count > 0;
      foreach (Unit unit in activeUnits) {
        result &= unit.IsUnitAtDestination();
      }
      return result;
    }

    public void CompleteUnitMovement()
    {
      List<Unit> activeUnits = Units.GetActiveUnits();
      foreach (Unit unit in activeUnits) {
        unit.CompleteMovement();
      }
    }

    /*public Rectangle DestinationRectangleForMovingUnit()
    {
      return new Rectangle(
        ((UnitRange.Leg.X - camera.X) * TileData.xStep) + camera.Offset.X + UnitRange.XMovementOffset(),
        ((UnitRange.Leg.Y - camera.Y) * TileData.yStep) + camera.Offset.Y + UnitRange.YMovementOffset(),
        TileData.width,
        TileData.height);
    }

    public Position GetActiveUnitDestination()
    {
      return UnitRange.destination;
    }

    public Position GetActiveUnitPosition()
    {
      return Units.GetActiveUnits;
    }
*/

    public bool IsActivePlayer(Player player)
    {
      return player.Name == ActivePlayer;
    }
  }
}
