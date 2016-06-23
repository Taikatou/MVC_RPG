using System.Collections.Generic;

namespace Game.ScreenManager
{
    public class SceneManager
    {
        private List<Scene> loaded_scenes;

        private Scene current_scene;

        public Scene CurrentScene
        {
            get
            {
                return current_scene; 
            }
        }

        public void PushScene(Scene child)
        {
            loaded_scenes.Add(child);
            current_scene = child;
        }

        protected SceneManager()
        {
            loaded_scenes = new List<Scene>();
        }

        protected static SceneManager instance;

        public static SceneManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SceneManager();
                }
                return instance;
            }
        }
    }
}
