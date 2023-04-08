using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using ControllerInput;

namespace HexStrategyGame.MapData
{
  public class Cursor
  {
    public Point Position { get; set; }
    Map Map { get; set; }
    bool lastRight = true;
    public Cursor()
    {
      Position = Point.Zero;
    }

    public Cursor(Map map)
    {
      Position = Point.Zero;
      this.Map = map;
    }

    public void Move(Direction direction)
    {
      bool moved;
      switch (direction)
      {
        case Direction.Up:
          if (lastRight)
          {
            moved = MoveBy(new Point(1, -1));
            if (moved) lastRight = false;
          }
          else
          {
            moved = MoveBy(new Point(0, -1));
            if (moved) lastRight = true;
          }
          break;
        case Direction.Down:
          if (lastRight)
          {
            moved = MoveBy(new Point(0, 1));
            if (moved) lastRight = false;
          }
          else
          {
            moved = MoveBy(new Point(-1, 1));
            if (moved) lastRight = true;
          }
          break;
        case Direction.UpLeft:
          moved = MoveBy(new Point(0, -1));
          if(!moved) MoveBy(new Point(-1, 0));
          lastRight = false;
          break;
        case Direction.UpRight:
          moved = MoveBy(new Point(1, -1));
          if (!moved) MoveBy(new Point(1, 0));
          lastRight = true;
          break;
        case Direction.DownLeft:
          moved = MoveBy(new Point(-1, 1));
          if(!moved) MoveBy(new Point(-1, 0));
          lastRight = false;
          break;
        case Direction.DownRight:
          moved = MoveBy(new Point(0, 1));
          if(!moved) MoveBy(new Point(1, 0));
          lastRight = true;
          break;
        case Direction.Left:
          MoveBy(new Point(-1, 0));
          lastRight = false;
          break;
        case Direction.Right:
          MoveBy(new Point(1, 0));
          lastRight = true;
          break;
      }
    }

    public bool MoveBy(Point movement)
    {
      bool result = false;
      Point newPos = Position + movement;
      MapTile mapTile = Map.GetTileAtLocation(newPos);
      if (mapTile.TileTerrain != Terrain.Empty)
      {
        Position = newPos;
        result = true;
      }
      return result;
    }
  }
}
