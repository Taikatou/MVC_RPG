using Game.Controllers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.BitmapFonts;
using MonoGame.Extended.InputListeners;
using MonoGame.Extended.Maps.Tiled;
using System.Diagnostics;

namespace Game
{
    public class Loader
    {
        public static TiledMap LoadMap(ContentManager content, string file_name)
        {
            file_name = string.Format("TileMaps/{0}", file_name);
            TiledMap tiled_map = content.Load<TiledMap>(file_name);
            return tiled_map;
        }

        public static Texture2D LoadSprite(ContentManager content, string file_name)
        {
            file_name = string.Format("Images/{0}", file_name);
            Texture2D texture = content.Load<Texture2D>(file_name);
            return texture;
        }

        public static BitmapFont LoadFont(ContentManager content, string file_name)
        {
            file_name = string.Format("Fonts/{0}", file_name);
            BitmapFont font = content.Load<BitmapFont>(file_name);
            return font;
        }

        public static InputListenerManager LoadInputManager()
        {
            InputListenerManager input_manager = new InputListenerManager();
            // var mouse_listener = input_manager.AddListener(new MouseListenerSettings());
            var keyboard_listener = input_manager.AddListener(new KeyboardListenerSettings());
            keyboard_listener.KeyPressed += (sender, args) =>
            {
                KeyAction(args.Key, true);
            };
            keyboard_listener.KeyReleased += (sender, args) =>
            {
                KeyAction(args.Key, false);
            };
            var game_pad_settings = new GamePadListenerSettings(PlayerIndex.One);
            var game_pad_listener = input_manager.AddListener(game_pad_settings);
            game_pad_listener.ButtonDown += (sender, args) =>
            {
                GamePadButton(args.Button, true);
            };
            game_pad_listener.ButtonDown += (sender, args) =>
            {
                GamePadButton(args.Button, false);
            };

            return input_manager;
        }

        public static void KeyAction(Keys key, bool down)
        {
            switch (key)
            {
                case Keys.Left:
                    ControllerSingleton.Instance.Left = down;
                    break;
                case Keys.Right:
                    ControllerSingleton.Instance.Right = down;
                    break;
                case Keys.Up:
                    ControllerSingleton.Instance.Up = down;
                    break;
                case Keys.Down:
                    ControllerSingleton.Instance.Down = down;
                    break;
                case Keys.A:
                    ControllerSingleton.Instance.A = down;
                    break;
                case Keys.B:
                    ControllerSingleton.Instance.B = down;
                    break;
            }
            Debug.WriteLine(string.Format("{0}: {1}", key.ToString(), down));
        }

        public static void GamePadButton(Buttons button, bool down)
        {
            switch (button)
            {
                case Buttons.DPadLeft:
                    ControllerSingleton.Instance.Left = down;
                    break;
                case Buttons.DPadRight:
                    ControllerSingleton.Instance.Right = down;
                    break;
                case Buttons.DPadUp:
                    ControllerSingleton.Instance.Up = down;
                    break;
                case Buttons.DPadDown:
                    ControllerSingleton.Instance.Down = down;
                    break;
                case Buttons.A:
                    ControllerSingleton.Instance.A = down;
                    break;
                case Buttons.B:
                    ControllerSingleton.Instance.B = down;
                    break;
            }
            Debug.WriteLine(string.Format("{0}: {1}", button.ToString(), down));
        }
    }
}
