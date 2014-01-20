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
    public class Menu
    {
        public event EventHandler OnMenuChange;
        public string Axis;
        public string Effects;
        [XmlElement("Item")]
        public List<MenuItem> Items;
        int itemnumber;
        string id;

        public int ItemNumber
        {
            get { return itemnumber; }
        }

        public string ID
        { 
            get { return id; }
            set
            {
                id = value;
                OnMenuChange(this, null);
            }
        }

        public void Transition(float alpha)
        {
            foreach(MenuItem item in Items)
            {
                item.Image.IsActive = true;
                item.Image.Alpha = alpha;
                if (alpha == 0.0f)
                    item.Image.FadeEffect.Increase = true;
                else
                    item.Image.FadeEffect.Increase = false;
                
            }
        }

        void AlignMenuItems()
        {
            Vector2 dimentions = Vector2.Zero;
            foreach (MenuItem item in Items)
                dimentions += new Vector2(item.Image.SourceRect.Width, item.Image.SourceRect.Height);

            dimentions = new Vector2((ScreenManager.Instance.Dimentions.X - dimentions.X) / 2, (ScreenManager.Instance.Dimentions.Y - dimentions.Y) / 2);//start draw center
       
            foreach (MenuItem item in Items)
            {
                if (Axis == "X")
                    item.Image.Position = new Vector2(dimentions.X, (ScreenManager.Instance.Dimentions.Y - item.Image.SourceRect.Height) / 2);
                else if (Axis == "Y")
                    item.Image.Position = new Vector2((ScreenManager.Instance.Dimentions.X - item.Image.SourceRect.Width) / 2, dimentions.Y);
                dimentions += new Vector2(item.Image.SourceRect.Width, item.Image.SourceRect.Height);
            }
        
        }

        public Menu()
        {
            id = String.Empty;
            itemnumber = 0;
            Effects = String.Empty;
            Axis = "Y";
            Items = new List<MenuItem>();
        }

        public void LoadContent()
        {
            string[] split = Effects.Split(':');
            foreach(MenuItem item in Items)
            {
                item.Image.LoadContent();
                foreach (string s in split)
                    item.Image.ActivateEffect(s);
            }
            
            AlignMenuItems();
        }

        public void UnloadContent()
        {
            foreach (MenuItem item in Items)
                item.Image.UnloadContent();
        }

        public void Update(GameTime gameTime)//Menu Controls
        {
            if(Axis == "X")
            {
                if (InputManager.Instance.KeyPressed(Keys.Right))
                    itemnumber++;
                 if (InputManager.Instance.KeyPressed(Keys.Left))
                     itemnumber--;
                 
            }
            else if(Axis =="Y")
            {
                if (InputManager.Instance.KeyPressed(Keys.Down))
                    itemnumber++;
                if (InputManager.Instance.KeyPressed(Keys.Up))
                    itemnumber--;
            }
            if (itemnumber < 0)
                itemnumber = 0;
            else if (itemnumber > Items.Count - 1)
                itemnumber = Items.Count - 1;

            for(int i=0; i<Items.Count; i++)
            {
                if (i == itemnumber)
                    Items[i].Image.IsActive = true;
                else
                    Items[i].Image.IsActive = false;

                Items[i].Image.Update(gameTime);
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (MenuItem item in Items)
                item.Image.Draw(spriteBatch);
        }
    }
}
