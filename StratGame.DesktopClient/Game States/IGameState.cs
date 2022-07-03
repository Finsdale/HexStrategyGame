using ControllerInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexStrategyGame
{
  public interface IGameState
  {
    void Update(Input input);

    IArtist GetArtist();
  }
}
