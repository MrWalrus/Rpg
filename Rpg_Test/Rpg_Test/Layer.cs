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
    public class Layer
    {
        public class TileMap
        {
            [XmlElement("Row")]
            public List<string> Row;
            public TileMap()
            {
                Row = new List<string>();
            }
        }

        [XmlElement("TileMap")]
        public TileMap Tile;
        List<Tile> tiles;
        public ImageHandler Image;

        public Layer()
        {
            Image = new ImageHandler();
            tiles = new List<Tile>();
        }

        public void LoadContent(Vector2 tileDimentions)
        {
            Image.LoadContent();
            Vector2 position = -tileDimentions;//crop sheet

            foreach (string row in Tile.Row)
            {
                string[] split = row.Split(']');
                position.X = -tileDimentions.X;
                position.Y += tileDimentions.Y;

                foreach(string s in split)
                {
                    position.X += tileDimentions.X;
                    if(s != String.Empty)
                    {                      
                        tiles.Add(new Tile());

                        string str = s.Replace("[", String.Empty);
                        int val_x = int.Parse(str.Substring(0, str.IndexOf(':')));
                        int val_y = int.Parse(str.Substring(str.IndexOf(':')+1));

                        tiles[tiles.Count - 1].LoadContent(position, new Rectangle(val_x * (int)tileDimentions.X, val_y * (int)tileDimentions.Y, (int)tileDimentions.X, (int)tileDimentions.Y));
                    }
                }
            }
        }

        public void UnloadContent()
        {
            Image.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
         //   Image.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(Tile tile in tiles)
            {
                Image.Position = tile.Position;
                Image.SourceRect = tile.SrcRect;
                Image.Draw(spriteBatch);
            }
        }


    }
}
