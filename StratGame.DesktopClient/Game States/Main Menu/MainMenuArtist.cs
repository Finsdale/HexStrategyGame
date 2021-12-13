using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexStrategyGame.MainMenu
{
  class MainMenuArtist: IArtist
  {
        MainMenuData data;

    public MainMenuArtist(MainMenuData data)
    {
      this.data = data;
    }
    public void Draw(SpriteBatch spriteBatch, SpriteFont font)
    {
      spriteBatch.DrawString(font, $"{data.CurrentSelection}", new Vector2(0, 30), Color.Black);
    }

    public void Draw(SpriteBatch spriteBatch, SpriteFont font, Texture2D texture)
    {
      Draw(spriteBatch, font);
    }
  }
}
