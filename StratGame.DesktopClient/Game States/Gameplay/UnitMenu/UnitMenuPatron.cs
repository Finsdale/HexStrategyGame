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
  internal class UnitMenuPatron : IPatron
  {
    TextureCollection TC;
    Scenario scenario;
    public UnitMenuPatron(Scenario scenario) 
    {
      TC = TextureCollection.Instance;
      this.scenario = scenario;
    }
    public void Draw(IArtist artist)
    {
      artist.DrawString(TC.GameFont, "Menu Stuffs", new Vector2(120, 60), Color.Black);
    }
  }
}
