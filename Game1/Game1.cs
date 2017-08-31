using Game1.Sprites;
//using Java.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System;
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
        private Texture2D _moonTexture;
        private SpriteFont _font;
        private float _timer;
        public bool IsRemoved;
        public static Random Random;
        public static int ScreenWidth;
        public static int ScreenHeight;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            Random = new Random();

     

            graphics.IsFullScreen = true;
            ScreenWidth = graphics.PreferredBackBufferWidth = 800;
            ScreenHeight = graphics.PreferredBackBufferHeight = 480;
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
                    Position = new Vector2(325,1000),
                    Bullet = new Bullet(Content.Load<Texture2D>("ball"))
                }
            };

            _font = Content.Load<SpriteFont>("Font");
            _moonTexture = Content.Load<Texture2D>("Moon");
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

            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            foreach (var sprite in _sprites.ToArray())
                sprite.Update(gameTime, _sprites);

            PostUpdate();
            SpawnMoon();

            base.Update(gameTime);
        }

        private void SpawnMoon()
        {
            if (_timer > 5)
            {
                _timer = 0;
                var XPos = Random.Next(0, ScreenWidth - _moonTexture.Width);
                var YPos = Random.Next(0, ScreenHeight - _moonTexture.Width);
                _sprites.Add(new Sprite(_moonTexture)
                {
                    Position = new Vector2(XPos, YPos)
                });
            }

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


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            foreach (var sprite in _sprites)
            {
                sprite.Draw(spriteBatch);
            }
            var fontY = 10;
            var i = 0;
            foreach (var sprite in _sprites)
            {
                if (sprite is Ship)

                    spriteBatch.DrawString(_font, "Puntuación: " + ((Ship)sprite).Score, new Vector2(10, fontY += 20), Color.Red);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
