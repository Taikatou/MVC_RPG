using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game.Render;

using SmallGame;
using Game.Objects;
using Game.Engine;

using MonoGame.Extended.InputListeners;
using MonoGame.Extended.ViewportAdapters;
using Game.Controllers;

namespace Game
{
    public class Game : CoreGame
    {
        private Renderer renderer;
        private InputListenerManager input_manager;
        private SpriteBatch _spriteBatch;
        private ViewportAdapter _viewportAdapter;

        public Game()
        {
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.AllowUserResizing = true;
            Window.Position = Point.Zero;
            IsFixedTimeStep = false;
        }

        protected override void Initialize()
        {
            base.Initialize();
            DataLoader.RegisterParser(
                new StandardGameObjectParser<TileMapObject>(),
                new StandardGameObjectParser<EntityObject>()
            );
            _viewportAdapter = new BoxingViewportAdapter(Window, GraphicsDevice, 800, 480);

            _spriteBatch = new SpriteBatch(GraphicsDevice);
            WorldLevel first_level = null;
            DataLoader.LoadAndWatch<WorldLevel>("level01.json", (level) => first_level = SetLevel(level));
            WorldManager.Instance.PushWorld(first_level);

            BoxingViewportAdapter viewport_adapter = new BoxingViewportAdapter(Window, GraphicsDevice, 800, 480);
            renderer = new Renderer(WorldManager.Instance.CurrentWorld, viewport_adapter, Content);
            input_manager = Loader.LoadInputManager();
        }

        protected override void Update(GameTime game_time)
        {
            base.Update(game_time);
            WorldManager.Instance.CurrentWorld.Update(game_time);
            renderer.Update(game_time);
            input_manager.Update(game_time);
        }

        protected override void Draw(GameTime game_time)
        {
            GraphicsDevice.Clear(Color.Black);
            base.Draw(game_time);
            renderer.Draw(_spriteBatch);
        }
    }
}
