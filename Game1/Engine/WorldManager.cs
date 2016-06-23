using System.Collections.Generic;

namespace Game.Engine
{
    public class WorldManager
    {
        private List<WorldLevel> loaded_Worlds;

        private WorldLevel current_World;

        public WorldLevel CurrentWorld
        {
            get
            {
                return current_World;
            }
        }

        public void PushWorld(WorldLevel child)
        {
            loaded_Worlds.Add(child);
            current_World = child;
        }

        protected WorldManager()
        {
            loaded_Worlds = new List<WorldLevel>();
        }

        protected static WorldManager instance;

        public static WorldManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WorldManager();
                }
                return instance;
            }
        }
    }
}
