using HexStrategyGame.MapData;
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
    public Position Position { get; set; }
    public Position DisplayPosition { get => MovementData.GetDisplayPosition(); }
    public string Player { get; set; }
    public int MovementRange;
    private bool _Active = false;
    private UnitMovement MovementData { get; set; }
    public bool Active { get { return MovementData.CostToMove.Count > 0; } }

    public Unit()
    { 
      MovementData = new UnitMovement(this);
    }
    public Unit(Position position, string player)
    {
      MovementData = new UnitMovement(this);
      Position = position;
      Player = player;
      MovementRange = 7;
    }

    public Point GetPixelDisplayPoint()
    {
      return MovementData.GetDisplayPoint();
    }

    public void SetMovementOptions(Map map)
    {
      _Active = true;
      MovementData.SetMovementOptions(map);
    }

    public void ClearMovementData()
    {
      _Active = false;
      MovementData.Clear();
    }

    public bool HasPositionInRange(Position position)
    {
      return MovementData.HasPositionInRange(position);
    }

    public void SetMovementDestination(Position destination)
    {
      MovementData.Destination = destination;
    }

    public void UpdateMovementPath(MapTile nextStep)
    {
      MovementData.UpdatePath(nextStep);
    }

    public void ResetMovement()
    {
      MovementData.ResetMovement();
    }

    public void Move()
    {
      MovementData.Move();
    }

    public bool IsUnitAtDestination()
    {
      return MovementData.IsUnitAtDestination();
    }

    public void CompleteMovement()
    {
      Position = MovementData.Destination;
      MovementData.Clear();
    }

  }
}
