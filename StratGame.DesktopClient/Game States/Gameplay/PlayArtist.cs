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
  public class PlayArtist: IArtist
  {
    public Scenario scenario;
    public string currentState;
        private SpriteFont font;
        private Texture2D texture;

    public PlayArtist(Scenario scenario)
    {
      this.scenario = scenario;
            TextureCollection TC = TextureCollection.Instance;
            font = TC.GameFont;
            texture = TC.TerrainTiles;
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
            spriteBatch.DrawString(font, $"Current State: {currentState}", new Vector2(0, 30), Color.Black);
            for (int y = 0; y <= scenario.map.MapHeight(); y++)
            {
                for (int x = 0; x <= scenario.map.MapLength(); x++)
                {
                    spriteBatch.Draw(
                        texture, 
                        new Rectangle((x * TileData.xStep) + (y % 2 * TileData.xHalfStep), y * TileData.yStep, TileData.width, TileData.height), 
                        new Rectangle(0, TileData.height * scenario.map.TileTerrain(x, y), 27, 33), 
                        Color.White);
                }
            }
    }
  }
}
