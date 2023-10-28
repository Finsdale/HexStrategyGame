﻿using HexStrategyGame.MapData;
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
    public string Player { get; set; }
    public int MovementRange;
    private bool _Active = false;
    private UnitMovementWrapper MovementData { get; set; }
    public bool Active { get { return _Active; } }

    public Unit()
    { 
      MovementData = new UnitMovementWrapper(this);
    }
    public Unit(Position position, string player)
    {
      Position = position;
      Player = player;
      MovementRange = 7;
      MovementData = new UnitMovementWrapper(this);
    }

    public void SetMovementOptions(Map map)
    {
      _Active = true;
      MovementData.SetMovementOptions(map);
    }

    public void ClearMovementData()
    {
      _Active = false;
    }

    public bool HasPositionInRange(Position position)
    {
      return MovementData.HasPositionInRange(position);
    }

    public void SetMovementDestination(Position destination)
    {
      MovementData.destination = destination;
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
      //Ewwww, this changes the values of variables within this class!
      MovementData.CompleteMovement();
    }
  }
}
