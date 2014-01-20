using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Rpg_Test
{
    public class Player
    {
        public ImageHandler Image;
        public Vector2 Velocity;
        public float MoveSpeed;

        public Player()
        {
            Velocity = Vector2.Zero;
        }

        public void LoadContent()
        {
            Image.LoadContent();
        }

        public void UnloadContent()
        {
            Image.UnloadContent();
        }

        public void  Update(GameTime gameTime)
        {
           // if (Velocity.X == 0)no diag
            //{
            Image.IsActive = true;
            if (InputManager.Instance.KeyDown(Keys.S) || InputManager.Instance.KeyDown(Keys.Down))
            {
                Velocity.Y = MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                Image.SpriteSheetEffect.CurrentFrame.Y = 0;
            }
            else if (InputManager.Instance.KeyDown(Keys.W) || InputManager.Instance.KeyDown(Keys.Up))
            {
                Velocity.Y = -MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                Image.SpriteSheetEffect.CurrentFrame.Y = 3;
            }
            else
                Velocity.Y = 0;
           // }
           

          //  if (Velocity.Y == 0)no diag
          //  {
                if (InputManager.Instance.KeyDown(Keys.A) || InputManager.Instance.KeyDown(Keys.Left))
                {
                    Velocity.X = -MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    Image.SpriteSheetEffect.CurrentFrame.Y = 1;
                }
                else if (InputManager.Instance.KeyDown(Keys.D) || InputManager.Instance.KeyDown(Keys.Right))
                {
                    Velocity.X = MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    Image.SpriteSheetEffect.CurrentFrame.Y = 2;
                }
                else
                    Velocity.X = 0;
            
          //  }       

                if (Velocity.X == 0 && Velocity.Y == 0)
                    Image.IsActive = false;

                Image.Update(gameTime);
            Image.Position += Velocity;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Image.Draw(spriteBatch);
        }
    }
}
