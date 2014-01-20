using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Rpg_Test
{
    public class SpriteSheetEffect : ImageEffect
    {
        public int FrameCounter;
        public int SwitchFrame;
        public Vector2 CurrentFrame;
        public Vector2 AmountOfFrames;

        public int FrameWidth
        {
            get
            {
                if (Image.texture != null)
                    return Image.texture.Width / (int)AmountOfFrames.X;
                return 0;
            }
        }

        public int FrameHeight
        {
            get
            {
                if (Image.texture != null)
                    return Image.texture.Height / (int)AmountOfFrames.Y;
                return 0;
            }
        }

        public SpriteSheetEffect()
        {
            AmountOfFrames = new Vector2(3, 4);//width x hight
            CurrentFrame = new Vector2(1, 0);//position of standing frame
            SwitchFrame = 100;//speed
            FrameCounter = 0;
        }

        public override void LoadContent(ref ImageHandler Image)
        {
            base.LoadContent(ref Image);
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (Image.IsActive)
            {
                FrameCounter += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (FrameCounter >= SwitchFrame)
                {
                    FrameCounter = 0;
                    CurrentFrame.X++;

                    if (CurrentFrame.X * FrameWidth >= Image.texture.Width)
                        CurrentFrame.X = 0;
                }
            }
            else
                CurrentFrame.X = 1;

            Image.SourceRect = new Rectangle((int)CurrentFrame.X * FrameWidth, (int)CurrentFrame.Y * FrameHeight, FrameWidth, FrameHeight);
        }

    }
}
