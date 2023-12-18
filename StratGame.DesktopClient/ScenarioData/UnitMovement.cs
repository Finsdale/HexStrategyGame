using HexStrategyGame.MapData;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexStrategyGame.ScenarioData
{
  public class UnitMovement
  {
    readonly Unit Unit;
    public Position Origin { get; set; }
    public Position Destination {get; set;}
    Position Leg { get { return UnitPath[PositionIndex].Position; } }
    Dictionary<MapTile, int> CostToMove { get; set; }
    Dictionary<MapTile, MapTile> PreviousStep { get; set; }
    List<MapTile> UnitPath { get; set; }
    float PercentTravelled = 0.0f;
    int PositionIndex = 0;

    public UnitMovement(Unit unit)
    {
      CostToMove = new Dictionary<MapTile, int>();
      PreviousStep = new Dictionary<MapTile, MapTile>();
      UnitPath = new List<MapTile>();
      Unit = unit;
    }

    public void SetMovementOptions(Map map)
    {
      MapTile UnitOrigin = map.GetTileAtLocation(Origin);
      CostToMove[UnitOrigin] = 0;
      PriorityQueue<MapTile, int> steps = new PriorityQueue<MapTile, int>();
      steps.Enqueue(UnitOrigin, 0);
      GenerateStepValues(map, steps);
    }

    private void GenerateStepValues(Map map, PriorityQueue<MapTile, int> steps)
    {
      do {
        MapTile currentStep = steps.Dequeue();
        List<MapTile> neighbors = map.GetNeighbors(currentStep);
        foreach (MapTile nextStep in neighbors) {
          int newCost = CostToMove[currentStep] + nextStep.Cost;
          if (IsCostToMoveImproved(nextStep, newCost) && IsWithinMovementRange(newCost)) {
            CostToMove[nextStep] = newCost;
            steps.Enqueue(nextStep, newCost);
            PreviousStep[nextStep] = currentStep;
          }
        }
      } while (steps.Count > 0);
    }

    private bool IsCostToMoveImproved(MapTile nextStep, int newCost)
    {
      return !CostToMove.ContainsKey(nextStep) || newCost < CostToMove[nextStep];
    }

    private bool IsWithinMovementRange(int cost)
    {
      return cost <= Unit.MovementRange;
    }

    public void Clear()
    {
      CostToMove.Clear();
      PreviousStep.Clear();
      UnitPath.Clear();
      ResetMovement();
    }

    public void UpdatePath(MapTile nextStep)
    {
      if (CostToMove.ContainsKey(nextStep)) {
        if (UnitPath.Contains(nextStep)) {
          int nextStepIndex = UnitPath.IndexOf(nextStep);
          UnitPath.RemoveRange(nextStepIndex + 1, UnitPath.Count - (nextStepIndex + 1));
        }
        else {
          UnitPath.Add(nextStep);
          int movementTotal = UnitPath.Sum(x => x.Cost);
          movementTotal -= UnitPath[0].Cost;
          if(movementTotal > Unit.MovementRange) {
            UnitPath = ShortestPathTo(nextStep);
          }
        }
      }
    }

    private List<MapTile> ShortestPathTo(MapTile nextStep)
    {
      List<MapTile> result = new List<MapTile>();
      if(PreviousStep.ContainsKey(nextStep)) {
        result = ShortestPathTo(PreviousStep[nextStep]);
      }
      result.Add(nextStep);
      return result;
    }

    public bool HasPositionInRange(Position position)
    {
      return CostToMove.Any(x => x.Key.Position == position);
    }

    public void Move()
    {
      if(!IsUnitAtDestination()) {
        PercentTravelled += 0.1f;
        if(PercentTravelled >= 1) {
          PercentTravelled = 0.0f;
          PositionIndex++;
        }
      }
    }

    public bool IsUnitAtDestination()
    {
      return (UnitPath.Count == PositionIndex + 1); 
    }

    public int XMovementOffset()
    {
      if (!IsUnitAtDestination()) {
        int result = (int)((UnitPath[PositionIndex + 1].Position.X - Leg.X) * PercentTravelled * TileData.xStep);
        return result;
      }
      else {
        return 0;
      }
    }
    public int YMovementOffset()
    {
      if (!IsUnitAtDestination()) {
        int result = (int)((UnitPath[PositionIndex + 1].Position.Y - Leg.Y) * PercentTravelled * TileData.yStep);
        return result;
      }
      else {
        return 0;
      }
    }

    public void ResetMovement()
    {
      PercentTravelled = 0.0f;
      PositionIndex = 0;
    }
  }
}
