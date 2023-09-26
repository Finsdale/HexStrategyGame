using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HexStrategyGame.ScenarioData;
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
    public readonly static Position NE = new Position(1, -1, 0);
    public readonly static Position E = new Position(1, 0, -1);
    public readonly static Position SE = new Position(0, 1, -1);
    public readonly static Position SW = new Position(-1, 1, 0);
    public readonly static Position W = new Position(-1, 0, 1);
    public readonly static Position NW = new Position(0, -1, 1);
  }
}