using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Rpg_Test
{
    public class Tile
    {
        Vector2 position;
        Rectangle srcRect;

        public Rectangle SrcRect
        {
            get { return srcRect; }
        }

         public Vector2 Position
        {
            get { return position; }
        }

        public void LoadContent(Vector2 position, Rectangle srcRect)
        {
            this.position = position;
            this.srcRect = srcRect;
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
