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

    public PlayArtist(Scenario scenario)
    {
      this.scenario = scenario;
    }

    public Cursor Cursor()
    {
      return scenario.cursor;
    }

    public string SetCurrentState(string currentState)
    {
      return this.currentState = currentState;
    }

    public void Draw(SpriteBatch spriteBatch, SpriteFont font)
    {
      spriteBatch.DrawString(font, $"Current State: {currentState}", new Vector2(0, 30), Color.Black);
    }

    public void Draw(SpriteBatch spriteBatch, SpriteFont font, Texture2D texture)
    {
      spriteBatch.Draw(texture, new Rectangle(0, 0, 27, 33), new Rectangle(0, 33, 27, 33), Color.White);
      spriteBatch.Draw(texture, new Rectangle(27, 0, 27, 33), new Rectangle(0, 66, 27, 33), Color.White);
      spriteBatch.Draw(texture, new Rectangle(54, 0, 27, 33), new Rectangle(0, 99, 27, 33), Color.White);
    }
  }
}
