using Jotunn.Entities;
using Jotunn.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonFinder.Languages
{
    class Brazilian : Localization
    {
        public override void AddLocalization(CustomLocalization localization)
        {
            localization.AddTranslation("Brazilian", new Dictionary<string, string>
            {
                {"item_skeletonbelt", "Cinto de Esqueleto"},
                {"item_skeletonbelt_desc", "Um cinto feito de crânios de antigos soldados amaldiçoados pelas masmorras da Floresta Negra."},
                {"skeletonbelt_effectname", "Percepção"},
                {"skeletonbelt_effectstart", "Você sente as masmorras"},
                {"skeletonbelt_effectstop", "Você não sente mais as masmorras"}
            });
        }
    }
}
