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
using HexStrategyGame.Artists;
using HexStrategyGame.Game_States;

namespace HexStrategyGame.Gameplay
{
  class CursorPatron : IPatron
  {
    readonly TextureCollection TC;
    readonly Cursor Cursor;
    readonly Camera Camera;

    public CursorPatron(Cursor cursor, Camera camera)
    {
      Cursor = cursor;
      Camera = camera;
      TC = TextureCollection.Instance;
    }

    public void Draw(IArtist artist)
    {
      //spriteBatch.DrawString(TC.GameFont, $"X:{x}", new Vector2(0, 60), Color.Black);
      //spriteBatch.DrawString(TC.GameFont, $"Y:{y}", new Vector2(0, 90), Color.Black);
      artist.Draw(
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
      int result = PatronHelper.DestinationXPosition(Cursor.DoubledPosition, Camera);
      return result;
    }

    int YDestinationPosition()
    {
      int result = PatronHelper.DestinationYPosition(Cursor.Position, Camera);
      return result;
    }

    internal static Rectangle CursorSource()
    {
      Rectangle result = new Rectangle(0, 0, TileData.width, TileData.height);
      return result;
    }
  }
}
