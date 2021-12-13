using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace HexStrategyGame
{
  public interface IArtist
  {
    void Draw(SpriteBatch spriteBatch, SpriteFont font);
    void Draw(SpriteBatch spriteBatch, SpriteFont font, Texture2D textures);
  }
}
