using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexStrategyGame.MapData
{
  public class MapTile
  {
    Terrain TileTerrain { get; set; }
    bool HasUnit { get; set; }
    bool HasBuilding { get; set; }

    public MapTile()
    {
      TileTerrain = 0;
      HasUnit = false;
      HasBuilding = false;
    }

    public MapTile(int terrainType, bool hasUnit, bool hasBuilding)
    {
      TileTerrain = Terrain.Sea;
      HasUnit = hasUnit;
      HasBuilding = hasBuilding;
    }
  }
}
