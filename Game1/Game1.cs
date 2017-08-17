using Game1.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System.Collections.Generic;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private List<Sprite> _sprites;
        private Texture2D _texture;
        private Vector2 _position;
        TouchCollection currentTouchState;
        public Bullet bullet;
        public Sprite parent;
        public bool IsRemoved;
        public float LifeSpam;
        public float _timer;
        public Bullet Bullet;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.IsFullScreen = true;
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 480;
            graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //_texture = Content.Load<Texture2D>("SpaceCraft01");
            //_position = new Vector2(200,200);
            // TODO: use this.Content to load your game content here
            var shipTexture = Content.Load<Texture2D>("SpaceCraft01");
            _sprites = new List<Sprite>()
            {
                new Ship(shipTexture)
                {
                    Position = new Vector2(100,100),
                    Bullet = new Bullet(Content.Load<Texture2D>("ball"))
                }
            };

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            //    Exit();

            // TODO: Add your update logic here
            currentTouchState = TouchPanel.GetState();

            foreach (var sprite in _sprites.ToArray())
                sprite.Update(gameTime, _sprites);

            PostUpdate();

            base.Update(gameTime);
        }

        protected void PostUpdate()
        {
            for (int i = 0; i < _sprites.Count; i++)
            {
                if (_sprites[i].IsRemoved)
                {
                    _sprites.RemoveAt(i);
                    i--;
                }
            }

        }
        protected void Timer(GameTime gameTime)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (_timer > LifeSpam)
                IsRemoved = true;
        }

        protected void AddBullet(List<Sprite> sprites)
        {
            var bullet = Bullet.Clone() as Bullet;
            bullet.Position = this._position;
            bullet.LifeSpam = 2f;
            bullet.Parent = this.parent;
            sprites.Add(bullet);
        }

        public void MoveNave(List<Sprite> sprites)
        {
            if (currentTouchState.Count > 0)
            {
                for (int i = 0; i < currentTouchState.Count; i++)
                {
                    _position = currentTouchState[i].Position;
                    AddBullet(sprites);
                }
            }

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //if (currentTouchState.Count > 0)
            //{
            //    for (int i = 0; i < currentTouchState.Count; i++)
            //    {                    
            //        _position = currentTouchState[i].Position;                      
            //    }
            //}  

            //// TODO: Add your drawing code here
            //spriteBatch.Begin();
            //spriteBatch.Draw(_texture, _position, Color.White);
            //spriteBatch.End();
            ////////////////////////////////////////////////////////       

            MoveNave(_sprites);

            spriteBatch.Begin();
            //foreach (var sprite in _sprites)            
            //sprite.Draw(spriteBatch);
            foreach (var sprite in _sprites)          
                spriteBatch.Draw(sprite.Texture, _position, Color.White);
            
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
