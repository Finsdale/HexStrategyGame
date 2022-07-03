using ControllerInput;
using HexStrategyGame.MainMenu;
using HexStrategyGame.Gameplay;
using HexStrategyGame.GameSettings;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HexStrategyGame.ScenarioData;

namespace HexStrategyGame
{
  public class GameStateMachine : IGameState
  {
    public IGameState GameState { get; set; }
    public MainMenuState mainMenuState;
    public GameSettingsState gameSettingsState;
    public PlayStateMachine playStateMachine;
    public Scenario Scenario { get; set; }
    public bool Exit { get; set; } = false;

    public GameStateMachine()
    {
      Scenario = new Scenario();
      mainMenuState = new MainMenuState(this);
      gameSettingsState = new GameSettingsState(this);
      playStateMachine = new PlayStateMachine(this);
      GameState = mainMenuState;
    }

    public void Update(Input input)
    {
      GameState.Update(input);
    }

    public IArtist GetArtist()
    {
      return GameState.GetArtist();
    }
  }
}
