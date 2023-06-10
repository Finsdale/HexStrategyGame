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
  public class MapArtist : IPatron
  {
    readonly TextureCollection TC;
    public string CurrentState;
    readonly Camera Camera;
    //readonly Cursor Cursor;
    readonly Map Map;
    public MapArtist(Scenario scenario)
    {
      TC = TextureCollection.Instance;
      Camera = scenario.camera;
      //Cursor = scenario.cursor;
      Map = scenario.map;
    }

    public string SetCurrentState(string currentState)
    {
      return this.CurrentState = currentState;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
      Camera.SetScreenValues(spriteBatch.GraphicsDevice.Viewport.Width, spriteBatch.GraphicsDevice.Viewport.Height);

      foreach(Point tile in Camera.VisibleTiles(Map)) {
        spriteBatch.Draw(TC.TerrainTiles,
          DestinationRectangle(tile),
          SourceRectangle(tile),
          Color.White);
      }
      //spriteBatch.DrawString(TC.GameFont, $"{(Terrain)Map.GetTerrainAtLocation(Cursor.Position)}", new Vector2(0, 120), Color.Black);
      //spriteBatch.DrawString(TC.GameFont, $"CameraX: {Camera.X}", new Vector2(0, 150), Color.Black);
      //spriteBatch.DrawString(TC.GameFont, $"CameraY: {Camera.Y}", new Vector2(0, 180), Color.Black);
    }

    internal Rectangle DestinationRectangle(Point tile)
    {
      Rectangle result = new Rectangle(DestinationXPosition(tile), DestinationYPosition(tile), TileData.width, TileData.height);
      return result;
    }

    int DestinationXPosition(Point tile)
    {
      int result = ((tile.X - Camera.X) * TileData.xStep) + Camera.Offset.X;
      return result;
    }

    int DestinationYPosition(Point tile)
    {
      int result = ((tile.Y - Camera.Y) * TileData.yStep) + Camera.Offset.Y;
      return result;
    }

    internal Rectangle SourceRectangle(Point tile)
    {
      Rectangle result = new Rectangle(0, TerrainXPosition(PatronHelper.DoubledToAxial(tile)), TileData.width, TileData.height);
      return result;
    }
    
    int TerrainXPosition(Point point)
    {
      int result = TileData.height * Map.GetTerrainAtLocation(point);
      return result;
    }
    int TerrainXPosition(int x, int y)
    {
      int result = TileData.height * Map.GetTerrainAtLocation(new Point(x, y));
      return result;
    }
  }
}
