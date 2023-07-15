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

namespace HexStrategyGame.Gameplay
{
  class CursorArtist : IPatron
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
      int result = (Cursor.DoubledXPosition - Camera.X) * TileData.xStep + Camera.Offset.X;
      return result;
    }

    int YDestinationPosition()
    {
      int result = ((Cursor.Y - Camera.Y) * TileData.yStep) + Camera.Offset.Y;
      return result;
    }

    internal static Rectangle CursorSource()
    {
      Rectangle result = new Rectangle(0, 0, TileData.width, TileData.height);
      return result;
    }
  }
}
