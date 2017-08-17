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
    public class Ship : Sprite
    {
        public Bullet Bullet;

        public Ship(Texture2D texture)
        : base(texture)
        {

        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            if (CurrentTouchState.Count > 0)
            {
                for (int i = 0; i < CurrentTouchState.Count; i++)
                {
                    Position = CurrentTouchState[i].Position;
                    AddBullet(sprites);
                }
            }
            
        }
        private void AddBullet(List<Sprite> sprites)
        {
            var bullet = Bullet.Clone() as Bullet;
            bullet.Position = this.Position;
            bullet.LifeSpam = 2f;
            bullet.Parent = this.Parent;
            sprites.Add(bullet);
        }
    }
}