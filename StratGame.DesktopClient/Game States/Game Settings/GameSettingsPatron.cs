using HexStrategyGame.Artists;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexStrategyGame.GameSettings
{
    class GameSettingsPatron : IPatron
    {
        readonly TextureCollection TC;
        public GameSettingsPatron()
        {
            TC = TextureCollection.Instance;
        }
    public void Draw(IArtist artist)
    {
      artist.DrawString(TC.GameFont, "Game Settings", new Vector2(0, 30), Color.Black);
    }
  }
}
