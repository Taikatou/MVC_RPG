using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Engine
{
    public enum TileStates { free, occupied };

    public class WorldArea
    {
        private string name;
        private List<Entity> entities;
        private Dictionary<int, TileStates> tile_states;

        public TileStates CheckTile(int tile)
        {
            return tile_states[tile];
        }
        public String Name
        {
            get;
        } 

        public WorldArea(string name)
        {
            this.name = name;
        }
    }
}
