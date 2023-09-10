using HexStrategyGame.ScenarioData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexStrategyGame.MapData
{
  public class MapTile
  {
    public Terrain TileTerrain { get; set; }
#pragma warning disable IDE0052 // Remove unread private members
        public Unit Unit { get; set; }
        private bool HasBuilding { get; set; }
#pragma warning restore IDE0052 // Remove unread private members

    public MapTile()
    {
      TileTerrain = Terrain.Empty;
      Unit = null;
      HasBuilding = false;
    }

    public MapTile(int terrainType, Unit unit = null, bool hasBuilding = false)
    {
      TileTerrain = (Terrain)terrainType;
      Unit = unit;
      HasBuilding = hasBuilding;
    }
  }
}
