using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HexStrategyGame.ScenarioData;
using HexStrategyGame.MapData;

namespace HexStrategyGame.Gameplay
{
  class CursorArtist: IArtist
  {
        readonly TextureCollection TC;
        readonly Cursor Cursor;

        public CursorArtist(Cursor cursor)
    {
            Cursor = cursor;
        TC = TextureCollection.Instance;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
      int x = Cursor.Position.X;
      int y = Cursor.Position.Y;
            spriteBatch.DrawString(TC.GameFont, $"X:{x}", new Vector2(0, 60), Color.Black);
            spriteBatch.DrawString(TC.GameFont, $"Y:{y}", new Vector2(0, 90), Color.Black);
            spriteBatch.Draw(
                TC.Cursor,
                CursorDestination(x, y), 
                CursorSource(),
                Color.White);
    }
    Rectangle CursorDestination(int x, int y)
    {
      return new Rectangle(
        XDestinationPosition(x,y), 
        YDestinationPosition(y), 
        TileData.width, 
        TileData.height);
    }

    int XDestinationPosition(int x, int y)
    {
      int stepValue = x * TileData.xStep;
      int offsetValue = y * TileData.xHalfStep;
      return stepValue + offsetValue;
    }

    int YDestinationPosition(int y)
    {
      return y*TileData.yStep;
    }

    Rectangle CursorSource()
    {
      return new Rectangle(0, 0, TileData.width, TileData.height);
    }
  }
}
