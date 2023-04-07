using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using HexStrategyGame.MapData;
using HexStrategyGame.ScenarioData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public string SetCurrentState(string currentState)
    {
      return this.currentState = currentState;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
      for (int y = 0; y < 10; y++)
      {
        for (int x = 0 - (y/2); x < 10 - (y/2); x++)
        {
          spriteBatch.Draw(
              TC.TerrainTiles,
              DestinationRectangle(x, y),
              SourceRectangle(x,y),
              Color.White);
        }
      }
    }

    Rectangle DestinationRectangle(int x, int y)
    {
      return new Rectangle(XDestination(x,y), YDestination(y), TileData.width, TileData.height);
    }

    int XDestination(int x, int y)
    {
      int stepValue = (x * TileData.xStep);
      int offsetValue = (y * TileData.xHalfStep);
      return stepValue + offsetValue;
    }
    
    int YDestination(int y)
    {
      return y * TileData.yStep;
    }

    //Currently, the source file is a single column of different terrain. So Y is always 0
    Rectangle SourceRectangle(int x, int y)
    {
      return new Rectangle(0, XSource(x,y), SOURCE_WIDTH, SOURCE_HEIGHT);
    }

    int XSource(int x, int y)
    {
      return TileData.height * scenario.map.GetTerrainAtLocation(new Point(x, y));
    }
  }
}
