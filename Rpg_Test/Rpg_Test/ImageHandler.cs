﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Rpg_Test
{
    public class ImageHandler
    {
        Menu menu;
        public float Alpha;
        public string Text, FontName, Path;
        public Vector2 Position, Scale;
        public Rectangle SourceRect;
        ContentManager content;
        RenderTarget2D renderTarget;
        SpriteFont font;

        // [XmlIgnore]
        public Texture2D texture;
        Vector2 orgin;
        Dictionary<string, ImageEffect> effectList;
        public string Effects;
        public bool IsActive;

        public FadeEffect FadeEffect;


        void SetEffect<T>(ref T effect)
        {
            if (effect == null)
                effect = (T)Activator.CreateInstance(typeof(T));
            else
            {
                (effect as ImageEffect).IsActive = true;
                var obj = this;
                (effect as ImageEffect).LoadContent(ref obj);            
            }

            effectList.Add(effect.GetType().ToString().Replace("Rpg_Test.", ""), (effect as ImageEffect));

        }

        public void ActivateEffect(string effect)
        {
            if (effectList.ContainsKey(effect))
            {
                effectList[effect].IsActive = true;
                var obj = this;
                effectList[effect].LoadContent(ref obj);
            }
        }

        public void DeactivateEffect(string effect)
        {
            if (effectList.ContainsKey(effect))
            {
                effectList[effect].IsActive = false;
                effectList[effect].UnloadContent();
            }
        }



        public ImageHandler()
        {
            Path = Text = Effects = String.Empty;
            FontName = "Fonts/Test";
            Position = Vector2.Zero;
            Scale = Vector2.One;
            SourceRect = Rectangle.Empty;
            Alpha = 1.0f;
            effectList = new Dictionary<string, ImageEffect>();

        }

        public void LoadContent()
        {
            content = new ContentManager(ScreenManager.Instance.Content.ServiceProvider, "Content");

            if (Path != String.Empty)
                texture = content.Load<Texture2D>(Path);

            font = content.Load<SpriteFont>(FontName);

            Vector2 dimentions = Vector2.Zero;        

            if (texture != null)
             //    {
                dimentions.X += texture.Width;
            dimentions.X += font.MeasureString(Text).X;
           // }

            if (texture != null)
                dimentions.Y = Math.Max(texture.Height, font.MeasureString(Text).Y);
            else
                dimentions.Y = font.MeasureString(Text).Y;

            if (SourceRect == Rectangle.Empty)
                SourceRect = new Rectangle(0, 0, (int)dimentions.X, (int)dimentions.Y);



            renderTarget = new RenderTarget2D(ScreenManager.Instance.GraphicsDevice, (int)dimentions.X, (int)dimentions.Y);
            ScreenManager.Instance.GraphicsDevice.SetRenderTarget(renderTarget);
            ScreenManager.Instance.GraphicsDevice.Clear(Color.Transparent);
            ScreenManager.Instance.SpriteBatch.Begin();
            if (texture != null)
                ScreenManager.Instance.SpriteBatch.Draw(texture, Vector2.Zero, Color.White);
            ScreenManager.Instance.SpriteBatch.DrawString(font, Text, Vector2.Zero, Color.White);
            ScreenManager.Instance.SpriteBatch.End();

            texture = renderTarget;

            ScreenManager.Instance.GraphicsDevice.SetRenderTarget(null);

            SetEffect<FadeEffect>(ref FadeEffect);

            if (Effects != String.Empty)
            {
                string[] split = Effects.Split(';');
                foreach (string item in split)
                    ActivateEffect(item);

            }
        }

        public void UnloadContent()
        {
            content.Unload();
            foreach (var effect in effectList)            
                DeactivateEffect(effect.Key);

            
        }

        public void Update(GameTime gameTime)
        {
            foreach (var effect in effectList)
            {
                if(effect.Value.IsActive)
                effect.Value.Update(gameTime);
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            orgin = new Vector2(SourceRect.Width / 2, SourceRect.Height / 2);
            spriteBatch.Draw(texture, Position + orgin, SourceRect, Color.White * Alpha, 0.0f, orgin, Scale, SpriteEffects.None, 0.0f);
        }

    }
}
