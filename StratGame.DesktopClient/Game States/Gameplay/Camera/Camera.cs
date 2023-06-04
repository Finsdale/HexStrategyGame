using HexStrategyGame.MapData;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexStrategyGame.Game_States.Gameplay.Camera
{
  public class Camera
  {
    public Point Position { get; set; }
    public int X { get => Position.X; }
    public int Y { get => Position.Y; }
    public int ScreenWidth, ScreenHeight;
    public Point Offset, MinPos, MaxPos;
    bool Locked = false;

    public Camera(Map map)
    {
      Position = Point.Zero;
      SetCameraLimits(map);
    }
    public Camera(Map map, Point position)
    {
      Position = position;
      SetCameraLimits(map);
    }

    public void SetCameraLimits(Map map)
    {
      int MaxX, MaxY, MinX, MinY;
      List<Point> tiles = map.TilePositions();
      List<Point> points = new List<Point>();
      foreach (Point position in tiles) {
        points.Add(new Point(2 * position.X + position.Y, position.Y));
      }
      MinX = points.Min(pos => pos.X);
      MaxX = points.Max(pos => pos.X);
      MinY = points.Min(pos => pos.Y);
      MaxY = points.Max(pos => pos.Y);
      MinPos = new Point(MinX, MinY);
      MaxPos = new Point(MaxX, MaxY);
    }
    
    public void SetScreenValues(int width, int height)
    {
      int xOffset, yOffset;
      ScreenWidth = width;
      ScreenHeight = height;
      xOffset = ScreenWidth % TileData.xStep;
      yOffset = (ScreenHeight % TileData.yStep / 2) - ((TileData.height - TileData.yStep) /2);
      Offset = new Point(xOffset, yOffset);
      CenterSmallMap();
    }

    void CenterSmallMap()
    {
      int xDiff = MaxPos.X - MinPos.X;
      int yDiff = MaxPos.Y - MinPos.Y;
      if (xDiff < ScreenWidth / TileData.xStep && yDiff < ScreenHeight / TileData.yStep) {
        Locked = true;
      }
      if (Locked) {
        int xPos = (ScreenWidth / TileData.xStep - xDiff) / 2;
        int yPos = (ScreenHeight / TileData.yStep - yDiff) / 2;
        Position = new Point(MinPos.X - xPos,MinPos.Y - yPos);
      }
    }

    public int GetScreenWidthInTiles()
    {
      return ScreenWidth/TileData.xStep;
    }

    public int GetScreenHeightInTiles()
    {
      return ScreenHeight/TileData.yStep;
    }

    public void ClampLocationToPoint(Point location)
    {
      if (!Locked) {
        int xResult = X, yResult = Y;
        int C = 2 * location.X + location.Y; //This is the doubled position of the location we are clamping to.
        if (C < X + 4) {
          xResult -= 2;
        }
        else if (C > X + GetScreenWidthInTiles() - 6) {
          xResult += 2;
        }
        if (location.Y < Y + 2) {
          yResult -= 1;
        }
        else if (location.Y > Y + GetScreenHeightInTiles() - 3) {
          yResult += 1;
        }
        Position = new Point(xResult, yResult);
      }
    }
  }
}
