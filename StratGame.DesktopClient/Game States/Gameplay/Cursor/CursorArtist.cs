using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HexStrategyGame.ScenarioData;
using HexStrategyGame.MapData;
using HexStrategyGame.Game_States.Gameplay.Camera;

namespace HexStrategyGame.Gameplay
{
  class CursorArtist : IArtist
  {
    readonly TextureCollection TC;
    readonly Cursor Cursor;
    readonly Camera Camera;

    public CursorArtist(Cursor cursor, Camera camera)
    {
      Cursor = cursor;
      Camera = camera;
      TC = TextureCollection.Instance;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
      int x = Cursor.X;
      int y = Cursor.Y;
      spriteBatch.DrawString(TC.GameFont, $"X:{x}", new Vector2(0, 60), Color.Black);
      spriteBatch.DrawString(TC.GameFont, $"Y:{y}", new Vector2(0, 90), Color.Black);
      spriteBatch.Draw(
          TC.Cursor,
          CursorDestination(),
          CursorSource(),
          Color.White);
    }
    Rectangle CursorDestination()
    {
      return new Rectangle(
        XDestinationPosition(),
        YDestinationPosition(),
        TileData.width,
        TileData.height);
    }

    int XDestinationPosition()
    {
      int halfStepsRight = Cursor.DoubledXPosition - Camera.X;
      int stepValue = halfStepsRight * TileData.xStep;
      return stepValue + Camera.Offset.X;
    }

    int YDestinationPosition()
    {
      int stepsDown = Cursor.Y - Camera.Y;
      int stepValue = stepsDown * TileData.yStep;
      return stepValue + Camera.Offset.Y;
    }

    static Rectangle CursorSource()
    {
      return new Rectangle(0, 0, TileData.width, TileData.height);
    }
  }
}
