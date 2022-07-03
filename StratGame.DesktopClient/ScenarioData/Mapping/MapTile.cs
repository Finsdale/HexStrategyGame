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
        private bool HasUnit { get; set; }
        private bool HasBuilding { get; set; }
#pragma warning restore IDE0052 // Remove unread private members

    public MapTile()
    {
      TileTerrain = Terrain.Sea;
      HasUnit = false;
      HasBuilding = false;
    }

    public MapTile(int terrainType, bool hasUnit, bool hasBuilding)
    {
      TileTerrain = (Terrain)terrainType;
      HasUnit = hasUnit;
      HasBuilding = hasBuilding;
    }
  }
}
