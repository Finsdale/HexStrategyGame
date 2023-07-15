using HexStrategyGame.Artists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace HexStrategyGame.Gameplay
{
  internal class GameMenuArtist : IPatron
  {
    readonly TextureCollection TC;
    public GameMenuArtist()
    {
      TC = TextureCollection.Instance;
    }

    public void Draw(IArtist artist)
    {
      artist.DrawString(TC.GameFont, "Menu Stuffs", new Vector2(120, 60), Color.Black);
    }
  }
}
