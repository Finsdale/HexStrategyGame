using HexStrategyGame.MapData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace HexStrategyGame.ScenarioData
{
    static public class UnitHelperMethods
    {
      static public MovementOptions GenerateMovementOptions(Unit unit, Map map)
    {
      MovementOptions result = new MovementOptions();
      MapTile UnitOrigin = map.GetTileAtLocation(unit.Position);
      result.CostToMove[UnitOrigin] = 0;
      PriorityQueue<MapTile, int> steps = new PriorityQueue<MapTile, int>();
      steps.Enqueue(UnitOrigin, 0);
      do {
        MapTile currentStep = steps.Dequeue();
        List<MapTile> neighbors = map.GetNeighbors(currentStep);
        foreach (MapTile nextStep in neighbors) {
          int newCost = result.CostToMove[currentStep] + nextStep.Cost;
          if (IsCostToMoveImproved(result.CostToMove, nextStep, newCost) && IsNewCostWithinRange(newCost, unit.MovementRange)) {
            result.CostToMove[nextStep] = newCost;
            steps.Enqueue(nextStep, newCost);
            result.PreviousStep[nextStep] = currentStep;
          }
        }
      } while (steps.Count > 0);
      return result;
    }

    private static bool IsCostToMoveImproved(Dictionary<MapTile, int> costToMove, MapTile nextStep, int newCost)
    {
      return !costToMove.ContainsKey(nextStep) || newCost < costToMove[nextStep];
    }

    private static bool IsNewCostWithinRange(int cost, int range)
    {
      return cost >= range;
    }
  }
}
