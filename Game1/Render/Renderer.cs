using MonoGame.Extended.ViewportAdapters;
using MonoGame.Extended;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using System;
using Game.Engine;
using MonoGame.Extended.BitmapFonts;
using Microsoft.Xna.Framework;
using Game.Controllers;

namespace Game.Render
{
    /// <summary>
    /// Renderer for game, TODO add configuration changes for different options
    /// </summary>
    public class Renderer
    {
        private Camera2D camera;
        private RenderWorld cached_scene;
        private ContentManager content;
        private FramesPerSecondCounter fps_counter;
        private BitmapFont bitmapFont;
        public Renderer(WorldLevel first_world, BoxingViewportAdapter viewport_adapter, ContentManager content)
        {
            this.content = content;
            cached_scene = new RenderWorld(first_world, content);
            bitmapFont = Loader.LoadFont(content, "montserrat-32");
            fps_counter = new FramesPerSecondCounter();
            camera = new Camera2D(viewport_adapter);
        }

        public void Update(GameTime game_time)
        {
            fps_counter.Update(game_time);
            Update(WorldManager.Instance.CurrentWorld);
            UpdateCamera(game_time);
        }

        public void UpdateCamera(GameTime game_time)
        {
            var deltaSeconds = (float)game_time.ElapsedGameTime.TotalSeconds;
            const float cameraSpeed = 200f;
            const float zoomSpeed = 0.2f;

            if (ControllerSingleton.Instance.Up)
            {
                camera.Move(new Vector2(0, -cameraSpeed) * deltaSeconds);
            }

            if (ControllerSingleton.Instance.Left)
            {
                camera.Move(new Vector2(-cameraSpeed, 0) * deltaSeconds);
            }

            if (ControllerSingleton.Instance.Down)
            {
                camera.Move(new Vector2(0, cameraSpeed) * deltaSeconds);
            }

            if (ControllerSingleton.Instance.Right)
            {
                camera.Move(new Vector2(cameraSpeed, 0) * deltaSeconds);
            }

            if (ControllerSingleton.Instance.A)
            {
                camera.ZoomIn(zoomSpeed * deltaSeconds);
            }

            if (ControllerSingleton.Instance.B)
            {
                camera.ZoomOut(zoomSpeed * deltaSeconds);
            }
        }

        public void Draw(SpriteBatch sprite_batch)
        {
            sprite_batch.Begin(transformMatrix: camera.GetViewMatrix());
            cached_scene.Draw(sprite_batch);
            sprite_batch.End();
            sprite_batch.Begin();
            sprite_batch.DrawString(bitmapFont, $"FPS: {fps_counter.AverageFramesPerSecond:0}", Vector2.One, Color.AliceBlue);
            sprite_batch.End();
        }

        public void Update(WorldLevel world)
        {
            // Ordinal is the fastest way to compare two strings.
            bool correct_world_cached = world.Name.Equals(cached_scene.Name, StringComparison.Ordinal);
            if (correct_world_cached)
            {
                cached_scene.Update();
            }
            else
            {
                cached_scene = new RenderWorld(world, content);
            }
        }
    }
}
