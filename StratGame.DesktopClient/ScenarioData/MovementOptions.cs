using HexStrategyGame.MapData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexStrategyGame.ScenarioData
{
  public class MovementOptions
  {
    public Dictionary<MapTile, int> CostToMove { get; set; }
    public Dictionary<MapTile, MapTile> PreviousStep { get; set; }
  }
}
