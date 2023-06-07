using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HexStrategyGame.Game_States
{
  internal static class ArtistHelper
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
  }
}
