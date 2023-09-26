using HexStrategyGame.Game_States;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexStrategyGame.ScenarioData
{
  public class Position
  {
    public Point DoubledPosition;
    public int X { get { return DoubledPosition.X; } }
    public int Y { get { return DoubledPosition.Y; } }
    public int Q { get { return (X - Y) / 2; } }
    public int R { get { return Y; } }
    public int S { get { return -((X - Y) / 2) - Y; } }
    
    public Position()
    {
      DoubledPosition = new Point();
    }

    public Position(Point point)
    {
      if((point.X + point.Y) % 2 != 0) {
        throw new ArgumentException("The sum of the axes of a doubled position - x,y - must always be even.");
      }
      DoubledPosition = point;
    }

    public Position(int x, int y)
    {
      if ((x + y) % 2 != 0) {
        throw new ArgumentException("The sum of the axes of a doubled position - x,y - must always be even.");
      }
      DoubledPosition = new Point(x, y);
    }

    public Position(int q, int r, int s)
    {
      if(q + r + s != 0) {
        throw new ArgumentException("The sum of the axes from a cubed position - q,r,s - must equal zero.");
      }
      DoubledPosition = new Point(2 * q + r, r);
    }

    public override bool Equals(object value)
    {
      if(value is null) {
        return false;
      }
      if(ReferenceEquals(this, value)) 
      {
        return true;
      }
      if(GetType() != GetType()) {
        return false;
      }
      return Equals((Position)value);
    }
    
    public bool Equals(Position other)
    {
      if(other is null) {
        return false;
      }

      if(ReferenceEquals(this, other)) {
        return true;
      }
      
      if(GetType() != other.GetType()) {
        return false;
      }

      return (X == other.X && Y == other.Y);
    }

    public override int GetHashCode()
    {
      unchecked 
      {
        const int HashingBase = (int)2166136261;
        const int HashingMultiplier = 16777619;

        int hash = HashingBase;
        hash = (hash * HashingMultiplier) + X.GetHashCode();
        hash = (hash * HashingMultiplier) + Y.GetHashCode();
        return hash;
      }
    }

    public static bool operator == (Position left, Position right)
    {
      if(ReferenceEquals(left, right)) {
        return true;
      }
      if(left is null) {
        return false;
      }
      return left.Equals(right);
    }

    public static bool operator != (Position left, Position right) => !(left == right);
  
    public static Position operator + (Position left, Position right)
    {
      if(ReferenceEquals(null, left)) {
        if (ReferenceEquals(null, right)) {
          return null;
        }
        return right;
      }
      return new Position(left.X + right.X, left.Y + right.Y);
    }
    
  }
}
