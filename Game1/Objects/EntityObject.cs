using Game.Controllers;
using Microsoft.Xna.Framework;
using SmallGame.GameObjects;
using System.Diagnostics;

namespace Game.Objects
{
    public class EntityObject : GameObject
    {
        public string FileName;

        public float Rotation;

        public float Scale;

        public Vector2 Position;

        Controller cached_controller;

        public EntityObject()
        {
            cached_controller = new Controller();
        }

        public bool Update(GameTime game_time)
        {
            return false;
        }

        public bool Update(GameTime game_time, Controller controller)
        {
            if (controller.Equals(cached_controller))
            {
                cached_controller.DeepCopy(controller);
                Move(game_time, controller);
                return true;
            }
            else
            {
                Move(game_time, controller);
                return false;
            }
        }

        public bool Move(GameTime game_time, Controller controller)
        {
            var deltaSeconds = (float)game_time.ElapsedGameTime.TotalSeconds;
            float movement_speed = 200f;
            if (controller.A)
            {
            }

            if (controller.B)
            {
                movement_speed += movement_speed;
            }

            if (controller.Up)
            {
                Position.Y += -movement_speed* deltaSeconds;
            }

            if (controller.Left)
            {
                Position.X += -movement_speed* deltaSeconds;
            }

            if (controller.Down)
            {
                Position.Y += movement_speed* deltaSeconds;
            }

            if (controller.Right)
            {
                Position.X += movement_speed* deltaSeconds;
            }
            return true;
        }
    }
}
