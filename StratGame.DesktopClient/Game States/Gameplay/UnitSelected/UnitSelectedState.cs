using ControllerInput;
using HexStrategyGame.Artists;
using HexStrategyGame.Game_States.Gameplay.UnitSelected;
using HexStrategyGame.MapData;
using HexStrategyGame.ScenarioData;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexStrategyGame.Gameplay
{
  public class UnitSelectedState : IGameState
  {
    readonly GameStateMachine gameStateMachine;
    readonly UnitSelectedPatron patron;
    readonly Scenario scenario;
    bool Active;
    UnitRange MovementOptions;

    public UnitSelectedState(GameStateMachine gameStateMachine) {
      this.gameStateMachine = gameStateMachine;
      scenario = gameStateMachine.Scenario;
      patron = new UnitSelectedPatron();
      Active = false;
      MovementOptions = new UnitRange();
    }
     
    public void Update(Input input)
    {
      if (Active) {
        if (input.cancel.Pressed) {
            Active = false;
            gameStateMachine.Pop();
        }
      }
    }

    public void Draw(IArtist artist) {
      patron.Draw(artist);
    }

    public bool SelectUnit(Unit unit)
    {
      if (unit != null) {
        Active = true;
        MapTile mapTile = scenario.GetTileAtMapLocation(unit.Position);
        MovementOptions = SetMovementOptions(mapTile);
      }
      return Active;
    }

    UnitRange SetMovementOptions(MapTile mapTile)
    {
      UnitRange movementOptions = new UnitRange();
      PriorityQueue<MapTile, int> steps = new PriorityQueue<MapTile, int>();
      steps.Enqueue(mapTile, 0);
      do {
        MapTile current = steps.Dequeue();
        List<MapTile> neighbors = gameStateMachine.Scenario.map.GetNeighbors(current);
        if (!movementOptions.CostToMove.ContainsKey(current)) movementOptions.CostToMove[current] = 0; 
        foreach (MapTile step in neighbors) {
          int newCost = movementOptions.CostToMove[current] + step.Cost;
          if ((!movementOptions.CostToMove.ContainsKey(step) || newCost < movementOptions.CostToMove[step]) && newCost <= gameStateMachine.Scenario.GetUnitAtLocation(mapTile.Position).movement) {
            movementOptions.CostToMove[step] = newCost;
            int priority = newCost;
            steps.Enqueue(step, priority);
            movementOptions.PreviousStep[step] = current;
          }
        }
      } while (steps.Count > 0);
      return movementOptions;
    }
  }
}
