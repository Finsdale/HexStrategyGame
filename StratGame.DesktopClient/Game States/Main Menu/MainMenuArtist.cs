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
        TextureCollection TC;
        SpriteFont font;

    public MainMenuArtist(MainMenuData data)
    {
      this.data = data;
            TC = TextureCollection.Instance;
      font = TC.GameFont;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.DrawString(font, $"{data.CurrentSelection}", new Vector2(0, 30), Color.Black);
    }
  }
}
