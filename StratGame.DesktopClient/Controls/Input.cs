using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexStrategyGame.Controls
{
  public class Input
  {
    public InputButton confirm, cancel, next, info, menu;
    public Direction direction, lastDirection;
    public float XValue { get; set; }
    public float YValue { get; set; }

    public Input() {
      confirm = new InputButton();
      cancel = new InputButton();
      next = new InputButton();
      info = new InputButton();
      menu = new InputButton();
      direction = Direction.None;
      lastDirection = Direction.None;
      XValue = 0.0f;
      YValue = 0.0f;
    }

    public bool DirectionHeld()
    {
      return direction == lastDirection;
    }

    public Direction Vertical()
    {
      return Vertical(direction);
    }

    private Direction Vertical(Direction direction)
    {
      {
        Direction result = Direction.None;
        switch (direction)
        {
          case Direction.Up:
          case Direction.UpLeft:
          case Direction.UpRight:
            result = Direction.Up;
            break;
          case Direction.Down:
          case Direction.DownLeft:
          case Direction.DownRight:
            result = Direction.Down;
            break;
        }
        return result;
      }
    }

    public bool VerticalMaintained()
    {
      return Vertical(direction) == Vertical(lastDirection);
    }
  }
}
