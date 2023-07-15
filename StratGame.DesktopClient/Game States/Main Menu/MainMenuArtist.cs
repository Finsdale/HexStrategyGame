using HexStrategyGame.Artists;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexStrategyGame.MainMenu
{
  class MainMenuArtist: IPatron
  {
        readonly MainMenuData data;
        readonly TextureCollection TC;

    public MainMenuArtist(MainMenuData data)
    {
      this.data = data;
      TC = TextureCollection.Instance;
    }

    public void Draw(IArtist artist)
    {
        artist.DrawString(TC.GameFont, $"{data.CurrentSelection}", new Vector2(0, 30), Color.Black);
    }
  }
}
