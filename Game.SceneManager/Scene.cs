

namespace Game.ScreenManager
{
    public class Scene
    {
        private string scene_name;

        private string tile_map_file;
        
        public string SceneName
        {
            get
            {
                return scene_name;
            }
        }

        public string TileMapFile
        {
            get
            {
                return tile_map_file;
            }
        }

        public Scene(string scene_name, string tile_map_file)
        {
            this.scene_name = scene_name;
            this.tile_map_file = tile_map_file;
        }

        public void Update()
        {

        }
    }
}
