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
using HexStrategyGame.Artists;

namespace HexStrategyGame.Gameplay
{
  public class MapPatron : IPatron
  {
    readonly TextureCollection TC;
    public string CurrentState;
    readonly Scenario Scenario;
    readonly Map Map;
    public MapPatron(Scenario scenario)
    {
      TC = TextureCollection.Instance;
      Scenario = scenario;
      Map = scenario.map;
    }

    public string SetCurrentState(string currentState)
    {
      return CurrentState = currentState;
    }

    public void Draw(IArtist artist)
    {
      Scenario.DefineCameraValues(artist.ScreenWidth(), artist.ScreenHeight());

      //Something important to note: The Camera Position is 
      foreach(Point tile in Scenario.VisibleTilePositions()) {
        artist.Draw(TC.TerrainTiles,
          DestinationRectangle(tile),
          SourceRectangle(tile),
          Color.White);
        if(Scenario.GetTileAtMapLocation(PatronHelper.DoubledToAxial(tile)).Unit != null) {
          artist.Draw(TC.UnitSprites, DestinationRectangle(tile), new Rectangle(0,0,TileData.width,TileData.height), Color.White);
        }
      }
      //artist.DrawString(TC.GameFont, $"{(Map.GetTileAtLocation(Cursor.Position).Unit == null ? "false" : Map.GetTileAtLocation(Cursor.Position).Unit.Player)}", new Vector2(0, 120), Color.Black);
      //spriteBatch.DrawString(TC.GameFont, $"CameraX: {Camera.X}", new Vector2(0, 150), Color.Black);
      //spriteBatch.DrawString(TC.GameFont, $"CameraY: {Camera.Y}", new Vector2(0, 180), Color.Black);
    }



    internal Rectangle DestinationRectangle(Point tile)
    {
      Rectangle result = new Rectangle(DestinationXPosition(tile, Scenario.camera), DestinationYPosition(tile, Scenario.camera), TileData.width, TileData.height);
      return result;
    }

    int DestinationXPosition(Point tile, Camera camera)
    {
      int result = ((tile.X - camera.X) * TileData.xStep) + camera.Offset.X;
      return result;
    }

    int DestinationYPosition(Point tile, Camera camera)
    {
      int result = ((tile.Y - camera.Y) * TileData.yStep) + camera.Offset.Y;
      return result;
    }

    internal Rectangle SourceRectangle(Point tile)
    {
      Rectangle result = new Rectangle(0, TerrainXPosition(tile), TileData.width, TileData.height);
      return result;
    }
    
    int TerrainXPosition(Point point)
    {
      Point mapPosition = PatronHelper.DoubledToAxial(point);
      int result = TileData.height * Map.GetTerrainAtLocation(mapPosition);
      return result;
    }
    int TerrainXPosition(int x, int y)
    {
      int result = TileData.height * Map.GetTerrainAtLocation(new Point(x, y));
      return result;
    }
  }
}
