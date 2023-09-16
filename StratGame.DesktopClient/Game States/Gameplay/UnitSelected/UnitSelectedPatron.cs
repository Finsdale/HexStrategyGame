using HexStrategyGame.Artists;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexStrategyGame.Game_States.Gameplay.UnitSelected
{
  internal class UnitSelectedPatron : IPatron
  {
    readonly TextureCollection TC;
    public UnitSelectedPatron() {
      TC = TextureCollection.Instance;
    }

    public void Draw(IArtist artist) { }
  }
}
