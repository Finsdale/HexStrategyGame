using ControllerInput;
using HexStrategyGame.MapData;
using HexStrategyGame.ScenarioData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using HexStrategyGame.Artists;

namespace HexStrategyGame.Gameplay
{
  public class MapPlayState : IGameState
  {
    public GameStateMachine gameStateMachine;
    public Scenario scenario;
    public MapPatron patron;

    public MapPlayState(GameStateMachine gameStateMachine)
    {
      this.gameStateMachine = gameStateMachine;
      scenario = gameStateMachine.Scenario;
      patron = new MapPatron(scenario);
    }

    public void Update(Input input)
    {
      gameStateMachine.Push(gameStateMachine.cursorPlayState);
    }

    public void Draw(IArtist artist)
    {
      patron.Draw(artist);
    }
  }
}
