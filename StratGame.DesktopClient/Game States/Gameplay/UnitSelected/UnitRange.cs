using HexStrategyGame.MapData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexStrategyGame.Game_States.Gameplay.UnitSelected
{
    internal class UnitRange
    {
      public Dictionary<MapTile, int> CostToMove {get; set;}
      public Dictionary<MapTile, MapTile> PreviousStep { get; set;}

      public UnitRange() {
        CostToMove = new Dictionary<MapTile, int>();
        PreviousStep = new Dictionary<MapTile, MapTile>();
      }
    }
}
