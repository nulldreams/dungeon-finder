using Jotunn.Entities;
using Jotunn.Managers;
using System.Collections.Generic;

namespace DungeonFinder.Languages
{
    class English : Localization
    {
        public override void AddLocalization(CustomLocalization localization)
        {
            localization.AddTranslation("English", new Dictionary<string, string>
            {
                {"item_skeletonbelt", "Skeleton Belt"},
                {"item_skeletonbelt_desc", "A belt made from the skulls of ancient soldiers cursed by the dungeons of the Black Forest."},
                {"skeletonbelt_effectname", "Perception"},
                {"skeletonbelt_effectstart", "You feel the dungeons"},
                {"skeletonbelt_effectstop", "You no longer feel the dungeons"}
            });
        }
    }
}
