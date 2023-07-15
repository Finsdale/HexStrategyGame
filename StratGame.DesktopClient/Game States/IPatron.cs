using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HexStrategyGame.Artists;
using Microsoft.Xna.Framework.Graphics;

namespace HexStrategyGame
{
  public interface IPatron
  {
    void Draw(IArtist artist);
  }
}
