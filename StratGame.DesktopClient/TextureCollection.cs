using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HexStrategyGame
{
    public sealed class TextureCollection
    {
        private static TextureCollection collection = null;
        private static readonly object padlock = new object();
        public SpriteFont GameFont { get; set; } 
        public SpriteFont DebugFont{ get; set; }
        public Texture2D TerrainTiles { get; set; }
        public Texture2D Cursor { get; set; }

        private TextureCollection() { }
        public static TextureCollection Instance
        {
            get
            {
                lock (padlock)
                {
                    if (collection == null)
                    {
                        collection = new TextureCollection();
                    }
                    return collection;
                }
            }
        }

        public void LoadContent(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            GameFont = content.Load<SpriteFont>("GameFont");
            DebugFont = content.Load<SpriteFont>("DebugFont");
            Cursor = content.Load<Texture2D>("cursor");
            TerrainTiles = content.Load<Texture2D>("test_tiles");
        }
    }
}
