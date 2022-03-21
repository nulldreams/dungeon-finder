using Jotunn.Entities;

namespace DungeonFinder
{
    abstract class ItemGenerator
    {
        public abstract void GenerateItem();
        protected abstract CustomItem CloneItem();
        protected abstract ItemDrop CreateItem(CustomItem customItem);
        protected abstract void CreateRecipe(ItemDrop itemDrop);
        protected abstract StatusEffect CreateStatusEffect();
    }
}
