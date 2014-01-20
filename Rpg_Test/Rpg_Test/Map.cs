using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Rpg_Test
{
    public class Map
    {
        [XmlElement("Layer")]
        public List<Layer> Layer;
        public Vector2 TileDimentions;

        public Map()
        {
            Layer = new List<Layer>();
            TileDimentions = Vector2.Zero;
        }

        public void LoadContent()
        {
            foreach (Layer l in Layer)
                l.LoadContent(TileDimentions);
        }
        
        public void UnloadContent()
        {
            foreach (Layer l in Layer)
                l.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            foreach (Layer l in Layer)
                l.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Layer l in Layer)
                l.Draw(spriteBatch);
        }
    }
}
