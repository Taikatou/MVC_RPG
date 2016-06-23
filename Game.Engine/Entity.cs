namespace Game.Engine
{
    public class Entity
    {
        private string name;

        public string Name
        {
            get
            {
                return name;
            }
        }

        public Entity(string name)
        {
            this.name = name;
        }
    }
}
