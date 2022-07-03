using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexStrategyGame.MapData
{
  public static class MovementAdapter
  {
    public static int ConvertFromOmniToHexMovement(int yPos, int yMove, int xMove)
    {
      int xMoveResult;
      if(xMove == 0 || xMove > 1 || xMove < -1 || yMove > 1 || yMove < -1)
      {
        throw new ArgumentException("Cannot check for X movement if no X movement given.");
      }
      else
      {
        bool hasNoYMovement = Math.Abs(yMove) == 0;
        bool currentRowIsOdd = yPos % 2 == 1;
        if (hasNoYMovement)
        {
          xMoveResult = xMove;
        }
        else if(currentRowIsOdd)
        {
          xMoveResult = (xMove + 1) / 2;
        }
        else //current row is even
        {
          xMoveResult = (xMove - 1) / 2;
        }
      }
      return xMoveResult;
    }
  }
}
