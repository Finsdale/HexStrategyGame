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
    public class GameStateMachine
    {
        public List<IGameState> GameStack = new List<IGameState>();
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
            Push(mainMenuState);
        }

        public void Clear()
        {
            GameStack.Clear();
        }

        public void Push(IGameState gameState)
        {
            GameStack.Add(gameState);
        }

        public void Pop()
        {
            GameStack.RemoveAt(GameStack.Count - 1);
        }

        public void Update(Input input)
        {
                GameStack[^1].Update(input);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for(int i = GameStack.Count -1; i >= 0; i--)
            {
                GameStack[i].Draw(spriteBatch);
            }
        }
  }
}
