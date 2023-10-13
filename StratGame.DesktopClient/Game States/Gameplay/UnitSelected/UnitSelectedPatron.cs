using HexStrategyGame.Artists;
using HexStrategyGame.ScenarioData;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexStrategyGame.Gameplay
{
  internal class UnitSelectedPatron : IPatron
  {
    readonly TextureCollection TC;
    Scenario scenario;
    public UnitSelectedPatron(Scenario scenario) {
      TC = TextureCollection.Instance;
      this.scenario = scenario;
    }

    public void Draw(IArtist artist)
    {
      artist.Draw(
        TC.UnitSprites,
        scenario.DestinationRectangleForPosition(scenario.GetActiveUnitPosition()),
        new Rectangle(0,0, TileData.width, TileData.height),
        Color.White);
    }
  }
}
