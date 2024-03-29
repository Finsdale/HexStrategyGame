﻿using HexStrategyGame.ScenarioData;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexStrategyGame.MapData
{
  public class MapTile
  {
    public Terrain TileTerrain { get; set; }
#pragma warning disable IDE0052 // Remove unread private members
        public Unit Unit { get; set; }
        private bool HasBuilding { get; set; }
        public Position Position { get; }
        public int Cost { get; set; }
#pragma warning restore IDE0052 // Remove unread private members

    public MapTile()
    {
      TileTerrain = Terrain.Empty;
      Position = new Position();
      Unit = null;
      HasBuilding = false;
    }

    public MapTile(int terrainType, Position position, Unit unit = null, bool hasBuilding = false)
    {
      TileTerrain = (Terrain)terrainType;
      Position = position;
      Unit = unit;
      HasBuilding = hasBuilding;
    }
  }
}
