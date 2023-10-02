using HexStrategyGame.MapData;
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
    public Position origin, leg, destination;
    public Dictionary<MapTile, int> CostToMove { get; set; }
    public Dictionary<MapTile, MapTile> PreviousStep { get; set; }

    public UnitMovementWrapper()
    {
      CostToMove = new Dictionary<MapTile, int>();
      PreviousStep = new Dictionary<MapTile, MapTile>();
    }

    public void SetMovementOptions(Map map, Unit selectedUnit)
    {
      ActiveUnit = selectedUnit;
      Position position = selectedUnit.Position;
      MapTile mapTile = map.GetTileAtLocation(position);
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
    }

    public Unit CompleteMovement()
    {
      Clear();
      ActiveUnit.Position = destination;
      return ActiveUnit;
    }
  }
}
