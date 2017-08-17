using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Generic;

namespace Game1.Sprites
{
    public  class Sprite: ICloneable
    {
        public TouchCollection CurrentTouchState;
        public SpriteBatch SpriteBatch;
        public Texture2D Texture;
        public Vector2 Position;
        public Sprite Parent;
        public float LifeSpam;
        public bool IsRemoved;

        public Sprite(Texture2D texture)
        {
            Texture = texture;
        }
        public virtual void Update(GameTime getTime, List<Sprite> sprites)
        {
           
        }

        public virtual void Draw(SpriteBatch spriteBeath)
        {
            spriteBeath.Draw(Texture, Position, Color.White);
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}