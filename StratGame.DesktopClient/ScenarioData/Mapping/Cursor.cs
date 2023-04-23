using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using ControllerInput;
using HexStrategyGame.Game_States.Gameplay.Camera;

namespace HexStrategyGame.MapData
{
  public class Cursor
  {
    public Point Position { get; set; }
    readonly Map Map;
    readonly Camera Camera;

    bool lastRight = true;
    public int X { get => Position.X; }
    public int Y { get => Position.Y; }

    public Cursor(Map map, Camera camera)
    {
      Position = Point.Zero;
      Map = map;
      Camera = camera;
    }

    public void Step(Direction direction)
    {
      bool moved;
      switch (direction) {
        case Direction.Up:
          if (lastRight) {
            moved = MoveBy(MapConst.NE);
            if (!moved) MoveBy(MapConst.NW);
            else lastRight = false;
          }
          else {
            moved = MoveBy(MapConst.NW);
            if (!moved) MoveBy(MapConst.NE);
            else lastRight = true;
          }
          break;

        case Direction.Down:
          if (lastRight) {
            moved = MoveBy(MapConst.SE);
            if (!moved) MoveBy(MapConst.SW);
            else lastRight = false;
          }
          else {
            moved = MoveBy(MapConst.SW);
            if (!moved) MoveBy(MapConst.SE);
            else lastRight = true;
          }
          break;

        case Direction.UpLeft:
          moved = MoveBy(MapConst.NW);
          if (!moved) {
            moved = MoveBy(MapConst.W);
            if (!moved) MoveBy(MapConst.NE);
          }
          lastRight = false;
          break;

        case Direction.UpRight:
          moved = MoveBy(MapConst.NE);
          if (!moved) {
            moved = MoveBy(MapConst.E);
            if (!moved) MoveBy(MapConst.NW);
          }
          lastRight = true;
          break;

        case Direction.DownLeft:
          moved = MoveBy(MapConst.SW);
          if (!moved) {
            moved = MoveBy(MapConst.W);
            if (!moved) MoveBy(MapConst.SE);
          }
          lastRight = false;
          break;

        case Direction.DownRight:
          moved = MoveBy(MapConst.SE);
          if (!moved) {
            moved = MoveBy(MapConst.E);
            if (!moved) MoveBy(MapConst.SW);
          }
          lastRight = true;
          break;

        case Direction.Left:
          MoveBy(MapConst.W);
          lastRight = false;
          break;

        case Direction.Right:
          MoveBy(MapConst.E);
          lastRight = true;
          break;
      }
      Camera.ClampLocationToPoint(Position);
    }

    public bool MoveBy(Point movement)
    {
      bool result = false;
      Point newPos = Position + movement;
      MapTile mapTile = Map.GetTileAtLocation(newPos);
      if (mapTile.TileTerrain != Terrain.Empty) {
        Position = newPos;
        result = true;
      }
      return result;
    }
  }
}
