using Game.Engine;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Maps.Tiled;
using MonoGame.Extended.Sprites;
using Game.Objects;
using System.Linq;

namespace Game.Render
{
    class RenderWorld
    {
        public TiledMap tiled_map;
        private WorldLevel base_world;
        private ContentManager content;
        private List<RenderEntity> entity_sprites;
        private int cached_state;
        public string Name
        {
            get
            {
                return base_world.Name;
            }
        }
        public RenderWorld(WorldLevel base_world, ContentManager content)
        {
            cached_state = base_world.state;
            this.content = content;
            this.base_world = base_world;
            tiled_map = Loader.LoadMap(content, base_world.TileMap.FileName);
            entity_sprites = new List<RenderEntity>();
            foreach (EntityObject e in base_world.Entities)
            {
                entity_sprites.Add(new RenderEntity(e, content));
            }
        }

        public void Draw(SpriteBatch sprite_batch)
        {
            sprite_batch.Draw(tiled_map);
            foreach(RenderEntity s in entity_sprites)
            {
                s.Draw(sprite_batch);
            }
        }

        public void Update()
        {
            if (cached_state != base_world.state)
            {
                entity_sprites.RemoveAll(entity => entity.IsRemoved == true);
                entity_sprites = entity_sprites.OrderBy(x => x.Position.Y).ThenBy(x => x.Position.X).ToList();
                cached_state = base_world.state;
            }
        }
    }
}
