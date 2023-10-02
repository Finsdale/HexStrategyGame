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
  internal class UnitMovingPatron : IPatron
  {
    TextureCollection TC;
    Scenario scenario;
    public UnitMovingPatron(Scenario scenario)
    {
      TC = TextureCollection.Instance;
      this.scenario = scenario;
    }
    public void Draw(IArtist artist)
    {
      artist.DrawString(TC.GameFont, "Moving", new Vector2(120, 60), Color.Black);
    }
  }
}
