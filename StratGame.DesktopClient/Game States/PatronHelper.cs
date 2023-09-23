using HexStrategyGame.Game_States.Gameplay.Camera;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HexStrategyGame.Game_States
{
  internal static class PatronHelper
  {
    static public Point AxialToDoubled(Point point)
    {
      return AxialToDoubled(point.X, point.Y);
    }
    static public Point AxialToDoubled(int x, int y)
    {
      return new Point(2 * x + y, y);
    }

    static public Point DoubledToAxial(Point point)
    {
      return DoubledToAxial(point.X, point.Y);
    }

    static public Point DoubledToAxial(int x, int y)
    {
      return new Point((x - y) / 2, y);
    }

    static public int DestinationXPosition(Point tile, Camera camera)
    {
      int result = ((tile.X - camera.X) * TileData.xStep) + camera.Offset.X;
      return result;
    }

    static public int DestinationYPosition(Point tile, Camera camera)
    {
      int result = ((tile.Y - camera.Y) * TileData.yStep) + camera.Offset.Y;
      return result;
    }
  }
}
