using HexStrategyGame.ScenarioData;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexStrategyGame
{
  internal class HelperMethods
  {
    static public Point PixelPoint(Position position)
    {
      return new Point(position.X * TileData.xStep, position.Y * TileData.yStep);
    }

    static public Point PixelPoint(Point point)
    {
      return new Point(point.X * TileData.xStep, point.Y * TileData.yStep);
    }
  }
}
