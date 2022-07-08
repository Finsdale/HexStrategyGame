using ControllerInput;
using HexStrategyGame.MapData;
using HexStrategyGame.ScenarioData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace HexStrategyGame.Gameplay
{
  public class MapPlayState : IGameState
  {
    public GameStateMachine gameStateMachine;
    public Scenario scenario;
    public MapArtist artist;
    public Map map;

    public MapPlayState(GameStateMachine gameStateMachine)
    {
      this.gameStateMachine = gameStateMachine;
      scenario = gameStateMachine.Scenario;
      artist = new MapArtist(scenario);
    }

    public void Update(Input input)
    {
        //Nothing happens
    }

    public void Draw(SpriteBatch spriteBatch)
    {
      artist.Draw(spriteBatch);
    }
  }
}
