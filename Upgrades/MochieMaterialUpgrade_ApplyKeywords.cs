using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Mochie.ShaderUpgrader
{
    public class MochieMaterialUpgrade_ApplyKeywords : MochieMaterialUpgradeBase
    {
        public override List<UpgradeActionBase> AddUpgradeActions()
        {
            return new List<UpgradeActionBase> { new ApplyKeywordsAction() };
        }
    }
}