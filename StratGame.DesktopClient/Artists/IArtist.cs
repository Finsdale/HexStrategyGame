using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexStrategyGame.Artists
{
    public interface IArtist
    {
        void Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle sourceRectangle, Color color);
    }
}
