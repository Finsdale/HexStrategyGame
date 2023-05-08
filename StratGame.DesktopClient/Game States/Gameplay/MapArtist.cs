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
    public Scenario scenario;
    public string currentState;
    readonly TextureCollection TC;
    const int SOURCE_WIDTH = 27;
    const int SOURCE_HEIGHT = 33;

    public MapArtist(Scenario scenario)
    {
      this.scenario = scenario;
      TC = TextureCollection.Instance;
    }

    public Cursor Cursor()
    {
      return scenario.cursor;
    }

    public Camera camera()
    {
      return scenario.camera;
    }

    public string SetCurrentState(string currentState)
    {
      return this.currentState = currentState;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
      camera().SetScreenValues(spriteBatch.GraphicsDevice.Viewport.Width, spriteBatch.GraphicsDevice.Viewport.Height);
      for (int y = -1; y < camera().GetScreenTileHeight() + 1; y++)
      {
        for (int x = - 1 - (y/2); x < camera().ScreenWidth/TileData.xStep - (y/2) + 1; x++)
        {
          spriteBatch.Draw(
              TC.TerrainTiles,
              DestinationRectangle(x, y),
              SourceRectangle(x,y),
              Color.White);
        }
      }
      spriteBatch.DrawString(TC.GameFont, $"{(Terrain)scenario.map.GetTerrainAtLocation(scenario.cursor.Position)}", new Vector2(0, 120), Color.Black);
      spriteBatch.DrawString(TC.GameFont, $"CameraX: {camera().Position.X}", new Vector2(0, 150), Color.Black);
      spriteBatch.DrawString(TC.GameFont, $"CameraY: {camera().Position.Y}", new Vector2(0, 180), Color.Black);
    }

    Rectangle DestinationRectangle(int x, int y)
    {
      return new Rectangle(XDestination(x,y), YDestination(y), TileData.width, TileData.height);
    }

    int XDestination(int x, int y)
    {
      int stepValue = (x * TileData.xStep);
      int offsetValue = (y * TileData.xHalfStep);
      int cameraOffset = (camera().Position.Y & 1) * TileData.xHalfStep;
      return stepValue + offsetValue + cameraOffset;
    }
    
    int YDestination(int y)
    {
      return y * TileData.yStep;
    }

    //Currently, the source file is a single column of different terrain. So Y is always 0
    Rectangle SourceRectangle(int x, int y)
    {
      int cameraX = (camera().Position.X - camera().Position.Y) / 2;
      return new Rectangle(0, XSource(x + cameraX, y + camera().Position.Y), SOURCE_WIDTH, SOURCE_HEIGHT);
    }

    int XSource(int x, int y)
    {
      return TileData.height * scenario.map.GetTerrainAtLocation(new Point(x, y));
    }
  }
}
