using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexStrategyGame.Controls
{
  public class InputAdapter
  {
    public GamePadState GS { get; set; }
    public Input CurrentInput { get; set; }
    public Input LastInput { get; set; }

    public InputAdapter()
    {
      CurrentInput = new Input();
      LastInput = new Input();
    }

    public Input GetInput()
    {
      LastInput = CurrentInput;
      CurrentInput = new Input();
      GS = GamePad.GetState(PlayerIndex.One);
      if (GS.Buttons.A == ButtonState.Pressed)
        ButtonPressed(CurrentInput.confirm, LastInput.confirm);
      if (GS.Buttons.B == ButtonState.Pressed)
        ButtonPressed(CurrentInput.cancel, LastInput.cancel);
      if (GS.Buttons.LeftShoulder == ButtonState.Pressed)
        ButtonPressed(CurrentInput.next, LastInput.next);
      if (GS.Buttons.RightShoulder == ButtonState.Pressed)
        ButtonPressed(CurrentInput.info, LastInput.info);
      if (GS.Buttons.Start == ButtonState.Pressed)
        ButtonPressed(CurrentInput.menu,LastInput.menu);

      CurrentInput.direction = GetDirection();
      CurrentInput.lastDirection = LastInput.direction;

      return CurrentInput;
    }

    private void ButtonPressed(InputButton button, InputButton prevButton)
    {
      button.Held = (prevButton.Pressed || prevButton.Held);
      button.Pressed = button.Held ? false : true; 
    }

    private Direction GetDirection()
    {
      Direction direction = Direction.None;
       double xValue = GS.ThumbSticks.Left.X;
       double yValue = GS.ThumbSticks.Left.Y;
      if (xValue > 0.25)
      {
        if (yValue > 0.25)
          direction = Direction.UpRight;
        else if (yValue < -0.25)
          direction = Direction.DownRight;
        else
          direction = Direction.Right;
      }
      else if (xValue < -0.25)
      {
        if (yValue > 0.25)
          direction = Direction.UpLeft;
        else if (yValue < -0.25)
          direction = Direction.DownLeft;
        else
          direction = Direction.Left;
      }
      else
      {
        if (yValue > 0.25)
          direction = Direction.Up;
        else if (yValue < -0.25)
          direction = Direction.Down;
      }
      return direction;
    }
  }
}
