using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Generic;

namespace Game1.Sprites
{
    public class Sprite : ICloneable
    {
        protected TouchCollection CurrentTouchState;
        protected GestureSample gestureSample;
        public Texture2D Texture;
        public Vector2 Position;
        public Vector2 Direction;
        public Vector2 Origin;
        public Vector2 Velocity;
        public Sprite Parent;
        public float LifeSpam = 0f;
        public float LienarVelocity = 8f;
        public float Rotation;
        public float RotationVelocity = 3f;
        public bool IsRemoved;

        public Sprite(Texture2D texture)
        {
            Texture = texture;
            Origin = new Vector2(Texture.Width / 2, Texture.Height / 2);
        }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
            }
        }
        public virtual void Update(GameTime getTime, List<Sprite> sprites)
        {

        }
        protected bool IsCollision(Sprite sprite)
        {
            return this.Rectangle.Bottom + this.Velocity.X > sprite.Rectangle.Top &&
                   this.Rectangle.Top < sprite.Rectangle.Top &&
                   this.Rectangle.Right > sprite.Rectangle.Left &&
                   this.Rectangle.Left < sprite.Rectangle.Right;
        }

        public virtual void Draw(SpriteBatch spriteBeath)
        {
            spriteBeath.Draw(Texture, Position, null, Color.White, Rotation, Origin, 1, SpriteEffects.None, 0);
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}