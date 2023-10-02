using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexStrategyGame.ScenarioData
{
  public class UnitList
  {
    Dictionary<Position, Unit> Units;
    public UnitList()
    {
      Units = new Dictionary<Position, Unit>();
    }

    public void AddUnit(Unit unit)
    {
      Units.Add(unit.Position, unit);
    }

    public Unit RemoveUnit(Position position)
    {
      Units.Remove(position, out Unit removedUnit);
      return removedUnit;
    }

    public Unit GetUnitAtLocation(Position position)
    {
      return Units.TryGetValue(position, out Unit unit) ? unit : null;
    }
  }
}
