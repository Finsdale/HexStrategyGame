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
