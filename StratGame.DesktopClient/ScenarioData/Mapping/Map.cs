using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexStrategyGame.MapData
{
  public class Map
  {
    Dictionary<Point, MapTile> TileCollection;

    //This constructor makes a basic rectangular map grid. Odd-numbered rows are shifted right.
    public Map(int height, int length)
    {
      TileCollection = new Dictionary<Point, MapTile>();
      for (int y = 0; y < height; y++)
      {
        for (int x = 0; x < length; x++)
        {
          //axial coordinates make our x value smaller as the y value increases
          TileCollection.Add(new Point(x - (y / 2), y), new MapTile(1));
        }
      }
    }

    public MapTile GetTileAtLocation(Point location)
    {
      TileCollection.TryGetValue(location, out MapTile tile);
      tile ??= new MapTile();
      return tile;
    }

    public int GetTerrainAtLocation(Point location)
    {
      MapTile tile = GetTileAtLocation(location);
      return (int)tile.TileTerrain;
    }
  }
}
