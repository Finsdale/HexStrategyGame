using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexStrategyGame.Artists
{
    internal class TestArtist : IArtist
    {
        public void Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle sourceRectangle, Color color) { }

    public void DrawString(SpriteFont font, string text, Vector2 position, Color color) { }
    public int ScreenWidth()
    {
      return 0;
    }  

    public int ScreenHeight()
    {
      return 0;
    }
  }
}
