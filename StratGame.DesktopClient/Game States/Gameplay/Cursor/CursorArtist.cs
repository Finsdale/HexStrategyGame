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
            spriteBatch.DrawString(TC.GameFont, $"X:{Cursor.Position.X}", new Vector2(0, 60), Color.Black);
            spriteBatch.DrawString(TC.GameFont, $"Y:{Cursor.Position.Y}", new Vector2(0, 90), Color.Black);
            spriteBatch.Draw(
                TC.Cursor, 
                new Rectangle((Cursor.Position.X * TileData.xStep) + (Cursor.Position.Y % 2 * TileData.xHalfStep), Cursor.Position.Y * TileData.yStep, TileData.width, TileData.height), 
                new Rectangle(0,0,TileData.width,TileData.height),
                Color.White);
    }
  }
}
