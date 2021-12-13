using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexStrategyGame.MapData
{
  public class Map
  {
    List<MapRow> MapRows { get; set; }

    public Map(int height, int length)
    {
      MapRows = new List<MapRow>();
      MapRow mapRow = new MapRow(length);
      for(int i = 0; i < height; i++)
      {
        MapRows.Add(mapRow);
      }
    }

    public int MapHeight()
    {
      return MapRows.Count() - 1;
    }

    public int MapLength()
    {
      return MapRows[0].Length() - 1;
    }
  }
}
