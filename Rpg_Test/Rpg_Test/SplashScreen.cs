using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
namespace Rpg_Test
{

    public class SplashScreen : GameScreen
    {

        public ImageHandler Image;
        public bool test = false;
       // Texture2D image;
       // [XmlElement("Path")]
      //  public List<string> path;


        public override void LoadContent()
        {
            base.LoadContent();
           // image = content.Load<Texture2D>(path[0]);
            Image.LoadContent();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            Image.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
              

              //if (Keyboard.GetState().IsKeyDown(Keys.Enter) && !ScreenManager.Instance.IsTransitioning)
            if (InputManager.Instance.KeyPressed(Keys.Enter, Keys.Space))
            {
                ScreenManager.Instance.ChangeScreen("TitleScreen");
                test = true;
            }
                //Debug.WriteLine("Test");
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            //spriteBatch.Draw(image, Vector2.Zero, Color.White);
            Image.Draw(spriteBatch);
        }


    }
}
