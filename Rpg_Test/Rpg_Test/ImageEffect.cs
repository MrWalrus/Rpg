using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Rpg_Test
{
    public class ImageEffect
    {
        public ImageHandler Image;
        public bool IsActive;

        public ImageEffect()
        {
        }

        public virtual void LoadContent(ref ImageHandler Image)
        {
            this.Image = Image;
        }

        public virtual void UnloadContent()
        {
        }

        public virtual void Update(GameTime gameTime)
        {
        }

    
    }
}
