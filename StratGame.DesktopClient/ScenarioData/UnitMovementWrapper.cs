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
  public class UnitMovementWrapper
  {
    public Unit ActiveUnit;
    public Position origin, destination;
    public Position Leg { get { return UnitPath[PositionIndex].Position; } }
    public Dictionary<MapTile, int> CostToMove { get; set; }
    public Dictionary<MapTile, MapTile> PreviousStep { get; set; }
    public List<MapTile> UnitPath { get; set; }
    public float Movement = 0.0f;
    public int PositionIndex = 0;

    public UnitMovementWrapper()
    {
      CostToMove = new Dictionary<MapTile, int>();
      PreviousStep = new Dictionary<MapTile, MapTile>();
      UnitPath = new List<MapTile>();
    }

    public void SetMovementOptions(Map map, Unit selectedUnit)
    {
      ActiveUnit = selectedUnit;
      origin = selectedUnit.Position;
      MapTile mapTile = map.GetTileAtLocation(origin);
      PriorityQueue<MapTile, int> steps = new PriorityQueue<MapTile, int>();
      steps.Enqueue(mapTile, 0);
      do {
        MapTile current = steps.Dequeue();
        List<MapTile> neighbors = map.GetNeighbors(current);
        if (!CostToMove.ContainsKey(current)) CostToMove[current] = 0;
        foreach (MapTile step in neighbors) {
          int newCost = CostToMove[current] + step.Cost;
          if ((!CostToMove.ContainsKey(step) || newCost < CostToMove[step]) && newCost <= selectedUnit.movement) {
            CostToMove[step] = newCost;
            steps.Enqueue(step, newCost);
            PreviousStep[step] = current;
          }
        }
      } while (steps.Count > 0);
    }

    public void Clear()
    {
      CostToMove.Clear();
      PreviousStep.Clear();
      UnitPath.Clear();
      ClearMovement();
    }

    public Unit CompleteMovement()
    {
      Clear();
      ActiveUnit.Position = destination;
      return ActiveUnit;
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
          if(movementTotal > ActiveUnit.movement) {
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

    public bool IsInMovementRange(Position position)
    {
      return CostToMove.Any(x => x.Key.Position == position);
    }

    public void UpdateMovement()
    {
      if(!IsUnitAtDestination()) {
        Movement += 0.1f;
        if(Movement >= 1) {
          Movement = 0.0f;
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
        int result = (int)((UnitPath[PositionIndex + 1].Position.X - Leg.X) * Movement * TileData.xStep);
        return result;
      }
      else {
        return 0;
      }
    }
    public int YMovementOffset()
    {
      if (!IsUnitAtDestination()) {
        int result = (int)((UnitPath[PositionIndex + 1].Position.Y - Leg.Y) * Movement * TileData.yStep);
        return result;
      }
      else {
        return 0;
      }
    }

    public void ClearMovement()
    {
      Movement = 0.0f;
      PositionIndex = 0;
    }
  }
}
