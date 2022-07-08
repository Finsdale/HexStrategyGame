using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using HexStrategyGame.MapData;
using HexStrategyGame.ScenarioData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexStrategyGame.Gameplay
{
  public class MapArtist: IArtist
  {
    public Scenario scenario;
    public string currentState;
        readonly TextureCollection TC;

    public MapArtist(Scenario scenario)
    {
      this.scenario = scenario;
      TC = TextureCollection.Instance;
    }

    public Cursor Cursor()
    {
      return scenario.cursor;
    }

    public string SetCurrentState(string currentState)
    {
      return this.currentState = currentState;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
            for (int y = 0; y <= scenario.map.MapHeight(); y++)
            {
                for (int x = 0; x <= scenario.map.MapLength(); x++)
                {
                    spriteBatch.Draw(
                        TC.TerrainTiles, 
                        new Rectangle((x * TileData.xStep) + (y % 2 * TileData.xHalfStep), y * TileData.yStep, TileData.width, TileData.height), 
                        new Rectangle(0, TileData.height * scenario.map.TileTerrain(x, y), 27, 33), 
                        Color.White);
                }
            }
        }
    }
}
