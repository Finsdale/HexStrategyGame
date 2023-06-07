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
    readonly int YTileOverlap = TileData.height - TileData.yStep;
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
      List<Point> tiles = map.TilePositionsDoubled();
      MinX = tiles.Min(pos => pos.X);
      MaxX = tiles.Max(pos => pos.X);
      MinY = tiles.Min(pos => pos.Y);
      MaxY = tiles.Max(pos => pos.Y);
      MinPos = new Point(MinX, MinY);
      MaxPos = new Point(MaxX, MaxY);
    }
    
    public void SetScreenValues(int width, int height)
    {
      int xOffset, yOffset;
      ScreenWidth = width;
      ScreenHeight = height;
      xOffset = ScreenWidth % TileData.xStep; //2
      int yStepRemainder = (ScreenHeight - YTileOverlap) % TileData.yStep;
      yOffset = (yStepRemainder / 2) + (yStepRemainder & 1); //9
      Offset = new Point(xOffset, yOffset);
      CenterSmallMap();
    }

    void CenterSmallMap()
    {
      int xDiff = 1 + MaxPos.X - MinPos.X; //56
      int yDiff = 1 + MaxPos.Y - MinPos.Y; //18
      int ScreenWidthInTiles = (ScreenWidth - TileData.xStep) / TileData.xStep;
      int ScreenHeightInTiles = (ScreenHeight - YTileOverlap) / TileData.yStep;
      if (xDiff <= ScreenWidthInTiles && yDiff <= ScreenHeightInTiles) {
        Locked = true;
      }
      if (Locked) {
        int xPos = ((ScreenWidth / TileData.xStep) - xDiff) / 2;
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

    public List<Point> VisibleTiles(Map map)
    {
      int minX, maxX, minY, maxY;
      minX = X - 2;
      maxX = ((ScreenWidth - TileData.xStep) / (TileData.xStep)) + X + 2;
      minY = Y - 1;
      maxY = ((ScreenHeight - YTileOverlap) / TileData.yStep) + Y + 1;
      List<Point> tiles = map.TilePositionsDoubled().FindAll(x => x.X >= minX && x.X <= maxX && x.Y >= minY && x.Y <= maxY).ToList();
      return tiles;
    }
  }
}
