using HexStrategyGame.ScenarioData;
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
    readonly Dictionary<Point, MapTile> TileCollection;
    readonly List<Point> directions = new List<Point> { new Point(1, -1), new Point(1, 0), new Point(0, 1), new Point(-1, 1), new Point(-1, 0), new Point(0, -1) };

    //This constructor makes a basic rectangular map grid. Odd-numbered rows are shifted right.
    public Map(int length, int height)
    {
      TileCollection = new Dictionary<Point, MapTile>();
      for (int y = 0; y < height; y++)
      {
        for (int x = 0 - (y / 2); x < length - (y / 2); x++)
        {
          //axial coordinates make our x value smaller as the y value increases
          if(x == 2 && y == 5) {
            TileCollection.Add(new Point(x,y), new MapTile(2, new Point(x,y), new Unit(new Point(x, y), "Player1")));
          }
          else { TileCollection.Add(new Point(x, y), new MapTile(1, new Point(x,y))); }
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

    public List<Point> TilePositions()
    {
      return TileCollection.Keys.ToList();
    }

    public List<Point> TilePositionsDoubled()
    {
      List<Point> tiles = TileCollection.Keys.ToList();
      List<Point> doubledTiles = new List<Point>();
      foreach (Point position in tiles) {
        doubledTiles.Add(new Point(2 * position.X + position.Y, position.Y));
      }    
      return doubledTiles;
    }

    public List<MapTile> GetNeighbors(Point tilePosition)
    {
      return GetNeighbors(GetTileAtLocation(tilePosition));
    }

    public List<MapTile> GetNeighbors(MapTile tile)
    {
      List<MapTile> neighbors = new List<MapTile>();
      foreach (Point direction in directions) {
        MapTile neighbor = GetTileAtLocation(tile.Position + direction);
        if (neighbor.TileTerrain != Terrain.Empty) neighbors.Add(neighbor);
      }
      return neighbors;
    }
  }
}
