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
    readonly Dictionary<Position, MapTile> TileCollection;
    readonly List<Position> directions = new List<Position> { new Position(1, -1, 0), new Position(1, 0, -1), new Position(0, 1, -1), new Position(-1, 1, 0), new Position(-1, 0, 1), new Position(0, -1, 1) };

    //This constructor makes a basic rectangular map grid. Odd-numbered rows are shifted right.
    public Map(int length, int height)
    {
      TileCollection = new Dictionary<Position, MapTile>();
      for (int r = 0; r < height; r++)
      {
        for (int q = 0 - (r / 2); q < length - (r / 2); q++)
        {
          //axial coordinates make our x value smaller as the y value increases
          if(q == 2 && r == 5) {
            TileCollection.Add(new Position(q, r, -q-r), new MapTile(2, new Position(q,r, -q-r), new Unit(new Position(q, r, -q-r), "Player1")));
          }
          else { TileCollection.Add(new Position(q, r, -q-r), new MapTile(1, new Position(q,r, -q-r))); }
        }
      }
    }

    public MapTile GetTileAtLocation(Position position)
    {
      TileCollection.TryGetValue(position, out MapTile tile);
      tile ??= new MapTile();
      return tile;
    }

    public int GetTerrainAtLocation(Position location)
    {
      MapTile tile = GetTileAtLocation(location);
      return (int)tile.TileTerrain;
    }

    public List<Position> TilePositions()
    {
      return TileCollection.Keys.ToList();
    }

    public List<MapTile> GetNeighbors(Position tilePosition)
    {
      return GetNeighbors(GetTileAtLocation(tilePosition));
    }

    public List<MapTile> GetNeighbors(MapTile tile)
    {
      List<MapTile> neighbors = new List<MapTile>();
      foreach (Position direction in directions) {
        MapTile neighbor = GetTileAtLocation(tile.Position + direction);
        if (neighbor.TileTerrain != Terrain.Empty) neighbors.Add(neighbor);
      }
      return neighbors;
    }
  }
}
