using Jotunn.Entities;
using Jotunn.Managers;
using Jotunn.Utils;
using UnityEngine;

namespace DungeonFinder
{
    class SkeletonBelt : ItemGenerator
    {
        public override void GenerateItem()
        {
            var item = CloneItem();

            var itemDrop = CreateItem(item);

            CreateRecipe(itemDrop);
        }
        protected override CustomItem CloneItem()
        {
            CustomItem customItem = new CustomItem("SkeletonBelt", "BeltStrength");
            ItemManager.Instance.AddItem(customItem);

            return customItem;
        }

        protected override ItemDrop CreateItem(CustomItem customItem)
        {
            var itemDrop = customItem.ItemDrop;

            itemDrop.m_itemData.m_shared.m_name = "$item_skeletonbelt";
            itemDrop.m_itemData.m_shared.m_description = "$item_skeletonbelt_desc";

            DungeonFinder.logger.LogInfo("==========================================");
            DungeonFinder.logger.LogInfo("Vai carregar o efeito");
            itemDrop.m_itemData.m_shared.m_equipStatusEffect = CreateStatusEffect();
            DungeonFinder.logger.LogInfo($"Carregou o efeito?: {itemDrop.m_itemData.m_shared.m_equipStatusEffect != null}");
            DungeonFinder.logger.LogInfo($"Carregou o efeito?: {itemDrop.m_itemData.m_shared.m_equipStatusEffect}");
            DungeonFinder.logger.LogInfo($"Carregou o efeito?: {itemDrop.m_itemData.m_shared.m_equipStatusEffect.m_icon}");
            DungeonFinder.logger.LogInfo("==========================================");

            return itemDrop;
        }

        protected override void CreateRecipe(ItemDrop itemDrop)
        {
            Recipe recipe = ScriptableObject.CreateInstance<Recipe>();
            recipe.name = "Recipe_SkeletonBelt";
            recipe.m_item = itemDrop;
            recipe.m_craftingStation = PrefabManager.Cache.GetPrefab<CraftingStation>("piece_workbench");
            recipe.m_resources = new[]
            {
                new Piece.Requirement
                {
                    m_resItem = PrefabManager.Cache.GetPrefab<ItemDrop>("Copper"),
                    m_amount = 1
                },
                new Piece.Requirement
                {
                    m_resItem = PrefabManager.Cache.GetPrefab<ItemDrop>("TrophySkeleton"),
                    m_amount = 1
                }
            };

            var customRecipe = new CustomRecipe(recipe, fixReference: false, fixRequirementReferences: false);
            ItemManager.Instance.AddRecipe(customRecipe);
        }

        protected override StatusEffect CreateStatusEffect()
        {
            var effect = ScriptableObject.CreateInstance<StatusEffect>();
            effect.name = "SkeletonBeltEffect";
            effect.m_name = "$skeletonbelt_effectname";

            DungeonFinder.logger.LogInfo("==========================================");

            DungeonFinder.logger.LogInfo("Vai carregar o asset");

            effect.m_icon = AssetUtils.LoadSpriteFromFile("DungeonFinder/Assets/ree.png");

            DungeonFinder.logger.LogInfo($"Carregou o asset?: {effect.m_icon != null}");
            DungeonFinder.logger.LogInfo($"Carregou o asset?: {effect.m_icon.ToString()}");
            DungeonFinder.logger.LogInfo($"Carregou o asset?: {effect.m_icon.rect}");

            DungeonFinder.logger.LogInfo("==========================================");

            effect.m_startMessageType = MessageHud.MessageType.Center;
            effect.m_startMessage = "$skeletonbelt_effectstart";
            effect.m_stopMessageType = MessageHud.MessageType.Center;
            effect.m_stopMessage = "$skeletonbelt_effectstop";

            var skeletonNecklaceEffect = new CustomStatusEffect(effect, fixReference: false);
            ItemManager.Instance.AddStatusEffect(skeletonNecklaceEffect);

            return skeletonNecklaceEffect.StatusEffect;
        }
    }
}
