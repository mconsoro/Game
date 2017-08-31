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
        public int Score;
        public Sprite tmpTxBall;
        public Sprite tmpTxMoon;
        public Ship(Texture2D texture)
        : base(texture)
        {

        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            CurrentTouchState = TouchPanel.GetState();
            var tmpPosition = Position;

            if (CurrentTouchState.Count > 0)
            {

                for (int i = 0; i < CurrentTouchState.Count; i++)
                {
                    //if (CurrentTouchState[i].Position.X < tmpPosition.X)
                    //{
                    //    Rotation -= MathHelper.ToRadians(RotationVelocity);
                    //}
                    //else if (CurrentTouchState[i].Position.X > tmpPosition.X)
                    //{
                    //    Rotation += MathHelper.ToRadians(RotationVelocity);
                    //}
                    Direction = new Vector2((float)Math.Cos(4.7), (float)Math.Sin(-1));
                    //if (CurrentTouchState[i].Position.X == tmpPosition.X && (CurrentTouchState[i].Position.Y != tmpPosition.Y))
                    //{
                    Position = CurrentTouchState[i].Position;
                    //}
                    AddBullet(sprites);

                    tmpPosition = CurrentTouchState[i].Position;
                    //break;
                }
               
                foreach (var sprite in sprites)
                {
                    if (sprite.Texture.Name == "ball")
                    {
                        tmpTxBall = sprite;
                    }
                    if (sprite.Texture.Name == "Moon")
                    {
                        tmpTxMoon = sprite;
                    }
                    if(tmpTxBall != null)
                    {
                        if (sprite.Texture.Name != "SpaceCraft01" && sprite.Texture.Name != "ball")
                        {
                            if (sprite.Rectangle.Intersects(tmpTxBall.Rectangle))
                            {
                                                         
                                Score++;
                                sprite.IsRemoved = true;
                            }
                        }
                    }
                }
            }

        }
        private void AddBullet(List<Sprite> sprites)
        {
            var bullet = Bullet.Clone() as Bullet;
            bullet.Direction = this.Direction;
            bullet.Position = this.Position;
            bullet.LifeSpam = 1f;
            bullet.LienarVelocity = this.LienarVelocity * 4;
            bullet.Parent = this.Parent;
            sprites.Add(bullet);
        }
    }
}