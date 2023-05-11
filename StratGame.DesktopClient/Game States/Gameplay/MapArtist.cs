using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using HexStrategyGame.MapData;
using HexStrategyGame.ScenarioData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HexStrategyGame.Game_States.Gameplay.Camera;

namespace HexStrategyGame.Gameplay
{
  public class MapArtist : IArtist
  {
    readonly TextureCollection TC;
    public string currentState;
    readonly Camera camera;
    readonly Cursor cursor;
    readonly Map map;
    public MapArtist(Scenario scenario)
    {
      TC = TextureCollection.Instance;
      camera = scenario.camera;
      cursor = scenario.cursor;
      map = scenario.map;
    }

    public string SetCurrentState(string currentState)
    {
      return this.currentState = currentState;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
      camera.SetScreenValues(spriteBatch.GraphicsDevice.Viewport.Width, spriteBatch.GraphicsDevice.Viewport.Height);
      for (int y = -1; y < camera.GetScreenTileHeight() + 1; y++)
      {
        for (int x = -2 + ((y + camera.Position.Y) & 1); x < camera.GetScreenTileWidth() + 1; x += 2) //camera is based on doubled coordinates, so each step right is 2
        {
          spriteBatch.Draw(
              TC.TerrainTiles,
              DestinationRectangle(x, y),
              SourceRectangle(x,y),
              Color.White);
        }
      }
      spriteBatch.DrawString(TC.GameFont, $"{(Terrain)map.GetTerrainAtLocation(cursor.Position)}", new Vector2(0, 120), Color.Black);
      spriteBatch.DrawString(TC.GameFont, $"CameraX: {camera.Position.X}", new Vector2(0, 150), Color.Black);
      spriteBatch.DrawString(TC.GameFont, $"CameraY: {camera.Position.Y}", new Vector2(0, 180), Color.Black);
    }



    static Rectangle DestinationRectangle(int x, int y)
    {
      return new Rectangle(XDestination(x), YDestination(y), TileData.width, TileData.height);
    }

    static int XDestination(int x)
    {
      int stepValue = (x * TileData.xHalfStep);
      return stepValue;
    }
    
    static int YDestination(int y)
    {
      return y * TileData.yStep;
    }

    //Currently, the source file is a single column of different terrain. So Y is always 0
    Rectangle SourceRectangle(int x, int y)
    {
      int yVal = y + camera.Y;
      int xVal = (camera.Position.X + x - yVal) / 2; //conversion for axial so we can find the terrain
      return new Rectangle(0, XSource(xVal, yVal), TileData.width, TileData.height);
    }

    int XSource(int x, int y)
    {
      return TileData.height * map.GetTerrainAtLocation(new Point(x, y));
    }
  }
}
