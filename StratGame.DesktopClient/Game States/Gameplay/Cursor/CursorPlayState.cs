using ControllerInput;
using HexStrategyGame.MapData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using HexStrategyGame.Game_States.Gameplay.Camera;
using HexStrategyGame.Artists;
using HexStrategyGame.ScenarioData.Players;

namespace HexStrategyGame.Gameplay
{
  public class CursorPlayState : IGameState
  {
        readonly GameStateMachine gameStateMachine;
        readonly Cursor cursor;
        readonly CursorArtist artist;
    readonly List<Player> players;
    readonly Camera camera;
    public float frameTimer = 0.0f;

    public CursorPlayState(GameStateMachine gameStateMachine)
    {
      this.gameStateMachine = gameStateMachine;
      cursor = gameStateMachine.Scenario.cursor;
      camera = gameStateMachine.Scenario.camera;
      artist = new CursorArtist(cursor, camera);
      players = gameStateMachine.Scenario.Players;
    }

    public void Update(Input input)
    {
      if (input.confirm.Pressed)
      {
        
        gameStateMachine.Push(new GameMenuState(gameStateMachine));
      }
      else if (input.cancel.Pressed)
      {

      }
      else
      {
        UpdateCursor(input);
      }
    }

    public void Draw(IArtist artist)
    {
      this.artist.Draw(artist);
    }

    private void UpdateCursor(Input input)
    {
      if (!input.DirectionHeld())
      {
        frameTimer = 0.0f;
        UpdateCursorPosition(input);
      }
      else if (input.direction != Direction.None)
      {
        if(frameTimer >= 2.5f)
        {
          frameTimer = 2.0f;
          UpdateCursorPosition(input);
        }
        else
        {
          frameTimer += 0.1f;
        }
      }
    }

    private void UpdateCursorPosition(Input input)
    {
      cursor.Step(input.direction);
    }
  }
}
