using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game1.Sprites
{
    public class Bullet: Sprite
    {
        private float _timer;

        public Bullet(Texture2D texture )
        : base(texture){

        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (_timer > LifeSpam)
                IsRemoved = true;

            Position += Direction * LienarVelocity;
        }
    }
}