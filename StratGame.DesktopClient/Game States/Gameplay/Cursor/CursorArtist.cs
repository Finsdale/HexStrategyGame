using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HexStrategyGame.ScenarioData;
using HexStrategyGame.MapData;

namespace HexStrategyGame.Gameplay
{
  class CursorArtist: IArtist
  {
    PlayArtist playArtist;
    private float frameTimerValue;

    public CursorArtist(PlayArtist playArtist)
    {
      this.playArtist = playArtist;
    }

    private Cursor Cursor()
    {
      return playArtist.Cursor();
    }

    public float FrameTimerValue(float frameTimerValue)
    {
      return this.frameTimerValue = frameTimerValue;
    }

    public void Draw(SpriteBatch spriteBatch, SpriteFont font)
    {
     // playArtist.Draw(spriteBatch, font);
      spriteBatch.DrawString(font, $"X:{Cursor().Position.X}", new Vector2(0, 60), Color.Black);
      spriteBatch.DrawString(font, $"Y:{Cursor().Position.Y}", new Vector2(0, 90), Color.Black);
      //spriteBatch.DrawString(font, $"Frame Timer:{frameTimerValue}", new Vector2(0, 120), Color.Black);
    }

    public void Draw(SpriteBatch spriteBatch, SpriteFont font, Texture2D texture)
    {
      playArtist.Draw(spriteBatch, font, texture);
            Draw(spriteBatch, font);
            spriteBatch.Draw(
                texture, 
                new Rectangle((Cursor().Position.X * TileData.xStep) + (Cursor().Position.Y % 2 * TileData.xHalfStep), Cursor().Position.Y * TileData.yStep, TileData.width, TileData.height), 
                new Rectangle(0,TileData.height * 2,TileData.width,TileData.height),
                Color.White);
    }
  }
}
