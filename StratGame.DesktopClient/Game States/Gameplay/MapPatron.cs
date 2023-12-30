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
    readonly Scenario Scenario;
    public MapPatron(Scenario scenario)
    {
      TC = TextureCollection.Instance;
      Scenario = scenario;
    }

    public void Draw(IArtist artist)
    {
      Scenario.DefineCameraValues(artist.ScreenWidth(), artist.ScreenHeight());

      foreach(Position position in Scenario.VisibleTilePositions()) {
        artist.Draw(TC.TerrainTiles,
          DestinationRectangle(position),
          SourceRectangle(position),
          Scenario.PositionIsWithinActiveUnitRange(position) ? Color.Tan : Color.White);
      }

      foreach(Unit unit in Scenario.Units) {
          artist.Draw(TC.UnitSprites,
            new Rectangle(
              unit.GetPixelDisplayPoint().X - Scenario.camera.DisplayPoint.X,
              unit.GetPixelDisplayPoint().Y - Scenario.camera.DisplayPoint.Y,
              TileData.width,
              TileData.height),
            new Rectangle(
              0, 0, TileData.width, TileData.height),
            Color.White);
      }
    }



    internal Rectangle DestinationRectangle(Position position)
    {
      return Scenario.DestinationRectangleForPosition(position);
    }

    internal Rectangle SourceRectangle(Position position)
    {
      Rectangle result = new Rectangle(
        0, 
        TerrainXPosition(position), 
        TileData.width, 
        TileData.height);
      return result;
    }
    
    int TerrainXPosition(Position position)
    {
      int result = TileData.height * (int)Scenario.GetTileAtMapLocation(position).TileTerrain;
      return result;
    }
    /*
    int TerrainXPosition(int x, int y)
    {
      int result = TerrainXPosition(new Position(x, y));
      return result;
    }
    */
  }
}
