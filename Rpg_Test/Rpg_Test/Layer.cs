using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Rpg_Test
{
    public class Layer
    {
        public class TileMap
        {
            public List<string> Row;
            public TileMap()
            {
                Row = new List<string>();
            }
        }

       // public TileMap TileMap;
        List<Tile> tiles;

        public Layer()
        {

        }

        public void LoadContent(Vector2 tileDimentions)
        {

        }

        public void UnloadContent()
        {

        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }


    }
}
