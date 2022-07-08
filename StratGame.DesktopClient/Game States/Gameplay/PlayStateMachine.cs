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
  public class PlayStateMachine : IGameState
  {
    public GameStateMachine gameStateMachine;
    public IGameState PlayState { get; set; }
    public IGameState cursorState;
    public Scenario scenario;
    public PlayArtist artist;
    public Map map;

    public PlayStateMachine(GameStateMachine gameStateMachine)
    {
      this.gameStateMachine = gameStateMachine;
      scenario = gameStateMachine.Scenario;
      artist = new PlayArtist(scenario);
      cursorState = new CursorState(this);
      PlayState = cursorState;
    }

    public void Update(Input input)
    {
      PlayState.Update(input);
      // Debugging Info
      artist.SetCurrentState(PlayState.ToString());
    }

    public void Draw(SpriteBatch spriteBatch)
    {
      artist.Draw(spriteBatch);
    }
  }
}
