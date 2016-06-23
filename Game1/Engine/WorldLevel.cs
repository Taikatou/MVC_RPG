using Game.Controllers;
using Game.Objects;
using Microsoft.Xna.Framework;
using SmallGame;
using System.Collections.Generic;
using System.Linq;

namespace Game.Engine
{
    public class WorldLevel : GameLevel
    {
        public int state;
        protected List<Controller> controllers;
        protected Dictionary<int, int> entity_controllers;

        public WorldLevel()
        {
            state = 0;
            controllers = new List<Controller>();
            entity_controllers = new Dictionary<int, int>();

            controllers.Add(ControllerSingleton.Instance);
            entity_controllers.Add(ControllerSingleton.Instance.Id, 0);
        }
        public TileMapObject TileMap
        {
            get
            {
                List<TileMapObject> tile_maps = Objects.GetObjects<TileMapObject>();
                return tile_maps[0];
            }
        }
        public List<EntityObject> Entities
        {
            get
            {
                return Objects.GetObjects<EntityObject>();
            }
            set
            {
                Entities = value;
            }
        }

        public void Update(GameTime game_time)
        {
            foreach (EntityObject e in Entities)
            {
                if (e.Update(game_time))
                {
                    state++;
                }
            }

            foreach (Controller c in controllers)
            {
                int index = entity_controllers[c.Id];
                if (Entities[index].Update(game_time, c))
                {
                    state++;
                }
                List<EntityObject> entity_copy = Entities;
            }
        }
    }
}
