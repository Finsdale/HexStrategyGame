using HexStrategyGame.MapData;
using HexStrategyGame.ScenarioData;
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

    public Camera(Scenario scenario)
    {
      Position = Point.Zero;
      SetCameraLimits(scenario.map);
    }
    public Camera(Scenario scenario, Point position)
    {
      Position = position;
      SetCameraLimits(scenario.map);
    }

    public void SetCameraLimits(Map map)
    {
      int MaxX, MaxY, MinX, MinY;
      List<Position> tiles = map.TilePositions();
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
      xOffset = ScreenWidth % TileData.xStep;
      int yStepRemainder = (ScreenHeight - YTileOverlap) % TileData.yStep;
      yOffset = (yStepRemainder / 2) + (yStepRemainder & 1);
      Offset = new Point(xOffset, yOffset);
      CenterSmallMap();
    }

    void CenterSmallMap()
    {
      int xDiff = 1 + MaxPos.X - MinPos.X;
      int yDiff = 1 + MaxPos.Y - MinPos.Y;
      int ScreenWidthInTiles = (ScreenWidth - TileData.xStep) / TileData.xStep;
      int ScreenHeightInTiles = (ScreenHeight - YTileOverlap) / TileData.yStep;
      if (xDiff <= ScreenWidthInTiles && yDiff <= ScreenHeightInTiles) {
        Locked = true;
      }
      if (Locked) {
        int xPos = ((ScreenWidth / TileData.xStep) - xDiff) / 2;
        int yPos = (ScreenHeight / TileData.yStep - yDiff) / 2;
        Position = new Point(MinPos.X - xPos, MinPos.Y - yPos);
      }
    }

    public int GetScreenWidthInTiles()
    {
      return ScreenWidth / TileData.xStep;
    }

    public int GetScreenHeightInTiles()
    {
      return ScreenHeight / TileData.yStep;
    }

    public void ClampToPosition(Position position)
    {
      if (!Locked) {
        int xResult = X, yResult = Y;
        int C = 2 * position.X + position.Y; //This is the doubled position of the location we are clamping to.
        if (C < X + 4) {
          xResult -= 2;
        }
        else if (C > X + GetScreenWidthInTiles() - 6) {
          xResult += 2;
        }
        if (position.Y < Y + 2) {
          yResult -= 1;
        }
        else if (position.Y > Y + GetScreenHeightInTiles() - 3) {
          yResult += 1;
        }
        Position = new Point(xResult, yResult);
      }
    }

    public List<Position> VisibleTiles(Map map)
    {
      int minX, maxX, minY, maxY;
      minX = X - 2;
      maxX = ((ScreenWidth - TileData.xStep) / (TileData.xStep)) + X + 2;
      minY = Y - 1;
      maxY = ((ScreenHeight - YTileOverlap) / TileData.yStep) + Y + 1;
      List<Position> tiles = map.TilePositions().FindAll(x => x.X >= minX && x.X <= maxX && x.Y >= minY && x.Y <= maxY).ToList();
      return tiles;
    }

    public Rectangle DestinationRectangleForPosition(Position position)
    {
      return new Rectangle(
        ((position.X - X) * TileData.xStep) + Offset.X,
        ((position.Y - Y) * TileData.yStep) + Offset.Y,
        TileData.width,
        TileData.height);
    }
  }
}
