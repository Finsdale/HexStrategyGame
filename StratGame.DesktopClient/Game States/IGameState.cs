using ControllerInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using HexStrategyGame.Artists;

namespace HexStrategyGame
{
  public interface IGameState
  {
    void Update(Input input);

    void Draw(IArtist artist);
  }
}
