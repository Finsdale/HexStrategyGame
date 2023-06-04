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
using HexStrategyGame.Game_States;

namespace HexStrategyGame.Gameplay
{
  public class MapArtist : IArtist
  {
    readonly TextureCollection TC;
    public string CurrentState;
    readonly Camera Camera;
    readonly Cursor Cursor;
    readonly Map Map;
    public MapArtist(Scenario scenario)
    {
      TC = TextureCollection.Instance;
      Camera = scenario.camera;
      Cursor = scenario.cursor;
      Map = scenario.map;
    }

    public string SetCurrentState(string currentState)
    {
      return this.CurrentState = currentState;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
      Camera.SetScreenValues(spriteBatch.GraphicsDevice.Viewport.Width, spriteBatch.GraphicsDevice.Viewport.Height);
      for (int y = -1; y < Camera.GetScreenHeightInTiles() + 1; y++)
      {
        //camera is based on doubled coordinates, so each step right is 2
        for (int x = -2 + ((y + Camera.Y) & 1); x < Camera.GetScreenWidthInTiles() + 1; x += 2) 
        {
          spriteBatch.Draw(
              TC.TerrainTiles,
              DestinationRectangle(x, y),
              SourceRectangle(x,y),
              Color.White);
        }
      }
      spriteBatch.DrawString(TC.GameFont, $"{(Terrain)Map.GetTerrainAtLocation(Cursor.Position)}", new Vector2(0, 120), Color.Black);
      spriteBatch.DrawString(TC.GameFont, $"CameraX: {Camera.X}", new Vector2(0, 150), Color.Black);
      spriteBatch.DrawString(TC.GameFont, $"CameraY: {Camera.Y}", new Vector2(0, 180), Color.Black);
    }



    Rectangle DestinationRectangle(int x, int y)
    {
      return new Rectangle(XDestination(x), YDestination(y), TileData.width, TileData.height);
    }

    int XDestination(int x)
    {
      int stepValue = (x * TileData.xStep);
      return stepValue + Camera.Offset.X;
    }
    
    int YDestination(int y)
    {
      int stepValue = y * TileData.yStep;
      return stepValue + Camera.Offset.Y;
    }

    //Currently, the source file is a single column of different terrain. So Y is always 0
    Rectangle SourceRectangle(int x, int y)
    {
      Point convertedCamera = ArtistHelper.DoubledToAxial(Camera.X, Camera.Y);
      Point convertedPosition = ArtistHelper.DoubledToAxial(x, y);
      Point screenPosition = convertedPosition + convertedCamera;
      return new Rectangle(0, TerrainXPosition(screenPosition), TileData.width, TileData.height);
    }

    int TerrainXPosition(Point point)
    {
      return TileData.height * Map.GetTerrainAtLocation(point);
    }
    int TerrainXPosition(int x, int y)
    {
      return TileData.height * Map.GetTerrainAtLocation(new Point(x, y));
    }
  }
}
