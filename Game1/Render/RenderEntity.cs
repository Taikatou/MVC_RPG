using Game.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Render
{
    class RenderEntity
    {
        private Texture2D entity_texture;

        private EntityObject base_entity;

        public Vector2 Position
        {
            get
            {
                return base_entity.Position;
            }
        }

        public bool IsRemoved
        {
            get
            {
                return base_entity == null;
            }
        }

        private ContentManager content;

        public RenderEntity(EntityObject base_entity, ContentManager content)
        {
            this.base_entity = base_entity;
            this.content = content;
            entity_texture = Loader.LoadSprite(content, base_entity.FileName);
        }

        public void Draw(SpriteBatch sprite_batch)
        {
            sprite_batch.Draw(entity_texture, base_entity.Position, null, Color.White, base_entity.Rotation, new Vector2(0, 0), base_entity.Scale, SpriteEffects.None, 0);
        }
    }
}
