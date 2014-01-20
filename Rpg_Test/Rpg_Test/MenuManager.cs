using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace Rpg_Test
{
    public class MenuManager
    {
        Menu menu;
        bool isTransitioning;
        
        void Transition(GameTime gameTime)
        {
            if(isTransitioning)
            {
                int oldMenuCount = menu.Items.Count;
                for (int i = 0; i < oldMenuCount; i++)
                //for(int i=0;i<menu.Items.Count;i++)
                {
                    menu.Items[i].Image.Update(gameTime);
                     float first = menu.Items[0].Image.Alpha;
                     float last = menu.Items[menu.Items.Count - 1].Image.Alpha;

                     if (first == 0 && last == 0)
                         menu.ID = menu.Items[menu.ItemNumber].LinkID;

                     else if (first == 1.0f && last == 1.0f)
                         isTransitioning = false;
                }
            }
        }

        public MenuManager()
        {
            menu = new Menu();
            menu.OnMenuChange += menu_OnMenuChange;
           // isTransistioning = false;
        }

        void menu_OnMenuChange(object sender, EventArgs e)
        {
            XmlManager<Menu> xmlMenuManager = new XmlManager<Menu>();
            menu.UnloadContent();
            menu = xmlMenuManager.Load(menu.ID);
            menu.LoadContent();
            menu.OnMenuChange += menu_OnMenuChange;
            menu.Transition(0.0f);
        }

        public void LoadContent(string menuPath)
        {
            if (menuPath != String.Empty)
                menu.ID = menuPath;

        }

        public void UnloadContent()
        {
            menu.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            if(!isTransitioning)
            menu.Update(gameTime);
            if(InputManager.Instance.KeyPressed(Keys.Enter) && !isTransitioning)
            {
                if (menu.Items[menu.ItemNumber].LinkType == "Screen")
                {
                    ScreenManager.Instance.ChangeScreen(menu.Items[menu.ItemNumber].LinkID);
                }
                if (menu.Items[menu.ItemNumber].LinkType == "Menu")
                {
                    isTransitioning = true;
                    menu.Transition(1.0f);
                }
            }
            Transition(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            menu.Draw(spriteBatch);
           
        }
    }
}
