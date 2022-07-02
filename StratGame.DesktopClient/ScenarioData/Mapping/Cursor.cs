using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using HexStrategyGame.Controls;

namespace HexStrategyGame.MapData
{
  public class Cursor
  {
    public Point Position { get; set; }
    Point MaxPosition { get; set; }
    bool lastRight = true;
    public Cursor()
    {
      Position = Point.Zero;
      MaxPosition = Point.Zero;
    }

    public Cursor(Map map)
    {
      Position = Point.Zero;
      MaxPosition = new Point(map.MapLength(), map.MapHeight());
    }



    public void Move(int xMove, int yMove)
    {
      Position = new Point(ClampX(Position.X + xMove), ClampY(Position.Y + yMove));
    }

    public void Move(Direction direction)
    {
            /*
      switch (direction)
      {
        case Direction.Up:
          if(0 < Position.Y)
          {
            if (lastRight)
            {
              Move(Position.Y % 2, -1);
            }
            else
            {
              Move(-(Position.Y + 1) % 2, -1);
            }
            lastRight = !lastRight;
          }
          break;
        case Direction.Down:
          if(MaxPosition.Y > Position.Y)
          {
            if (lastRight)
            {
              Move(Position.Y % 2, 1);
            }
            else
            {
              Move(-(Position.Y + 1) % 2, 1);
            }
            lastRight = !lastRight;
          }
          break;
        case Direction.UpLeft:
          Move(-(Position.Y + 1) % 2, -1);
          lastRight = false;
          break;
        case Direction.UpRight:
          Move(Position.Y % 2, -1);
          lastRight = true;
          break;
        case Direction.DownLeft:
          Move(-(Position.Y + 1) % 2, 1);
          lastRight = false;
          break;
        case Direction.DownRight:
          Move(Position.Y % 2, 1);
          lastRight = true;
          break;
        case Direction.Left:
          Move(-1, 0);
          lastRight = false;
          break;
        case Direction.Right:
          Move(1, 0);
          lastRight = true;
          break;
      }*/

    switch (direction)
    {
        case Direction.Up:
            if (0 < Position.Y)
            {
                Move(0, -1);
            }
            break;
        case Direction.Down:
            if (MaxPosition.Y > Position.Y)
            {
                Move(0, 1);
            }
            break;
        case Direction.UpLeft:
            Move(-1, -1);
            break;
        case Direction.UpRight:
            Move(1, -1);
            break;
        case Direction.DownLeft:
            Move(-1, 1);
            break;
        case Direction.DownRight:
            Move(1, 1);
            break;
        case Direction.Left:
            Move(-1, 0);
            break;
        case Direction.Right:
            Move(1, 0);
            break;
    }
        }

    //public void Move(Point location)
    //{
    //  position.ChangeLocation(ClampX(location.X), ClampY(location.Y));
    //}

    private int ClampX(int xPos)
    {
      return MathHelper.Clamp(xPos, 0, MaxPosition.X);
    }

    private int ClampY(int yPos)
    {
      return MathHelper.Clamp(yPos, 0, MaxPosition.Y);
    }
  }
}
