using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HexStrategyGame
{
  public sealed class TextureCollection
  {
    private static readonly TextureCollection collection = new TextureCollection();
    public SpriteFont GameFont { get; set; }
    public SpriteFont DebugFont { get; set; }
    public Texture2D TerrainTiles { get; set; }
    public Texture2D UnitSprites { get; set; }
    public Texture2D Cursor { get; set; }

    private TextureCollection() { }
    public static TextureCollection Instance
    {
      get
      {
        return collection;
      }
    }

    public void LoadContent(Microsoft.Xna.Framework.Content.ContentManager content)
    {
      GameFont = content.Load<SpriteFont>("GameFont");
      DebugFont = content.Load<SpriteFont>("DebugFont");
      Cursor = content.Load<Texture2D>("cursor");
      TerrainTiles = content.Load<Texture2D>("test_tiles");
      UnitSprites = content.Load<Texture2D>("Unit");
    }
  }
}
