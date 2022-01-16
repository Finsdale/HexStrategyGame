using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexStrategyGame.GameSettings
{
    class GameSettingsArtist : IArtist
    {
        SpriteFont font;
        public GameSettingsArtist()
        {
            font = TextureCollection.Instance.GameFont;
        }
    public void Draw(SpriteBatch spriteBatch)
    {
      spriteBatch.DrawString(font, "Game Settings", new Vector2(0, 30), Color.Black);
    }
  }
}
