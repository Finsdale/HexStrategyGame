using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace HexStrategyGame.MapData
{
  public enum Terrain
  {
    Empty,
    Sea,
    Desert,
    Hill,
    Forest,
    Field
  };

  public static class MapConst
  {
    public readonly static Point NE = new Point(1, -1);
    public readonly static Point E = new Point(1, 0);
    public readonly static Point SE = new Point(0, 1);
    public readonly static Point SW = new Point(-1,1);
    public readonly static Point W = new Point(-1, 0);
    public readonly static Point NW = new Point(0, -1);
  }
}