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
using Microsoft.Xna.Framework.Input.Touch;

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
            CurrentTouchState = TouchPanel.GetState();

            if (CurrentTouchState.Count > 0)
            {               
                if (CurrentTouchState[CurrentTouchState.Count].Position.X > 0)
                {
                    Rotation -= MathHelper.ToRadians(RotationVelocity);
                }
                else if (CurrentTouchState[CurrentTouchState.Count].Position.X < 0)
                {
                    Rotation += MathHelper.ToRadians(RotationVelocity);
                }

                Direction = new Vector2((float)Math.Cos(Rotation), (float)Math.Sin(Rotation));

                for (int i = 0; i < CurrentTouchState.Count; i++)
                {
                    Position = CurrentTouchState[i].Position;
                    AddBullet(sprites);
                    break;
                }
            }

        }
        private void AddBullet(List<Sprite> sprites)
        {
            var bullet = Bullet.Clone() as Bullet;
            bullet.Position = this.Position;
            bullet.LifeSpam = 2f;
            bullet.LiearVelocity = this.LiearVelocity * 2;
            bullet.Parent = this.Parent;
            sprites.Add(bullet);
        }
    }
}