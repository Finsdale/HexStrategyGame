using ControllerInput;
using HexStrategyGame.MapData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace HexStrategyGame.Gameplay
{
  public class CursorPlayState : IGameState
  {
#pragma warning disable IDE0052 // Remove unread private members
        readonly GameStateMachine gameStateMachine;
#pragma warning restore IDE0052 // Remove unread private members
        readonly Cursor cursor;
        readonly CursorArtist artist;
    public float frameTimer = 0.0f;

    public CursorPlayState(GameStateMachine gameStateMachine)
    {
      this.gameStateMachine = gameStateMachine;
      cursor = gameStateMachine.Scenario.cursor;
      artist = new CursorArtist(cursor);
    }

    public void Update(Input input)
    {
      if (input.confirm.Pressed)
      {

      }
      else if (input.cancel.Pressed)
      {

      }
      else
      {
        UpdateCursor(input);
      }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
      artist.Draw(spriteBatch);
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
      cursor.Move(input.direction);
    }
  }
}
