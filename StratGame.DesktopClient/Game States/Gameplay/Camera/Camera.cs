using HexStrategyGame.MapData;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HexStrategyGame.Game_States.Gameplay.Camera
{
  public class Camera
  {
    public Point Position { get; set; }
    public int X { get => Position.X; }
    public int Y { get => Position.Y; }
    Map Map;
    int MinY, MaxY, ScreenWidth, ScreenHeight;
    Point MinX, MaxX;

    public Camera(Map map)
    {
      Position = Point.Zero;
      Map = map;
    }
    public Camera(Map map, Point position)
    {
      Position = position;
      Map = map;
    }
    
    public void SetScreenValues(int width, int height)
    {
      ScreenWidth = width;
      ScreenHeight = height;
    }

    public int GetScreenTileWidth()
    {
      return ScreenWidth/TileData.xStep;
    }

    public int GetScreenTileHeight()
    {
      return ScreenHeight/TileData.yStep;
    }

    public void ClampLocationToPoint(Point location)
    {
      int xResult = X, yResult = Y;
      int screenwidth = GetScreenTileWidth(), screenheight = GetScreenTileHeight();
      if(location.Y < Y + 2) {
        yResult = location.Y - 2;
        xResult += (yResult & 1);
      } else if(location.Y > Y + GetScreenTileHeight() - 2) {
        yResult = location.Y + 2 - GetScreenTileHeight();
        xResult -= (yResult & 1);
      }
      if(location.X < X - ((location.Y - Y) / 2)  + 2) {
        xResult = location.X + ((location.Y - Y) / 2) - 2;
      } else if(location.X > X + GetScreenTileWidth() - ((location.Y - Y) / 2) - 2) {
        xResult = location.X - (GetScreenTileWidth() - ((location.Y - Y) / 2)) + 2;
      }
      Position = new Point(xResult, yResult);
    }


    /* We'll come back to this eventually, I think...
    void SetMaxY()
    {
      MaxY = Map.TilePositions().Max(tilePosition => tilePosition.Y);
    }
    void SetMinY()
    {
      MinY = Map.TilePositions().Min(tilePosition => tilePosition.Y);
    }
    void SetMaxX()
    {
      MaxX = Map.TilePositions().MaxBy(tilePosition => (tilePosition.X * 2) + tilePosition.Y);
    }
    void SetMinX()
    {
      MinX = Map.TilePositions().MinBy(tilePosition => (tilePosition.X * 2) + tilePosition.Y);
    }
    */
  }
}
