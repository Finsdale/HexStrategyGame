using HexStrategyGame.Controls;
using HexStrategyGame.MapData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexStrategyGame.Gameplay
{
  public class CursorState : IGameState
  {
    PlayStateMachine playStateMachine;
    Cursor cursor;
    CursorArtist artist;
    public float frameTimer = 0.0f;

    public CursorState(PlayStateMachine playStateMachine)
    {
      this.playStateMachine = playStateMachine;
      artist = new CursorArtist(playStateMachine.artist);
      cursor = playStateMachine.scenario.cursor;
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
      //Get rid of this later
      artist.FrameTimerValue(frameTimer);
    }

    public IArtist GetArtist()
    {
      return artist;
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
          frameTimer = 1.7f;
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
