using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexStrategyGame.MapData
{
  public class MapRow
  {
    List<MapTile> MapTiles { get; set; }

    public MapRow(int length)
    {
      MapTiles = new List<MapTile>();
      MapTile mapTile = new MapTile();
      for(int i = 0; i < length; i++)
      {
        MapTiles.Add(mapTile);
      }
    }

    public int Length()
    {
      return MapTiles.Count();
    }

        public MapTile MapTile(int xIndex)
        {
            return MapTiles[xIndex];
        }
  }
}
