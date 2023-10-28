using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexStrategyGame.ScenarioData
{
  public class UnitList
  {
    List<Unit> Units;
    public UnitList()
    {
      Units = new List<Unit>();
    }

    public void AddUnit(Unit unit)
    {
      Units.Add(unit);
    }

    public Unit RemoveUnit(Position position)
    {
      Unit removedUnit = GetUnitAtLocation(position);
      if (removedUnit is not null) Units.Remove(removedUnit);
      return removedUnit;
    }

    public Unit GetUnitAtLocation(Position position)
    {
      return Units.Find(unit => unit.Position == position);
    }

    public List<Unit> GetActiveUnits()
    {
      return Units.FindAll(unit => unit.Active == true);
    }
  }
}
