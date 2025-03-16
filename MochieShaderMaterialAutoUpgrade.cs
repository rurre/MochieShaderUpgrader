using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

namespace Mochie.ShaderUpgrader
{
    public static class MochieShaderMaterialAutoUpgrade
    {
        static readonly ShaderUpgradeInfo[] ShaderUpgrades =
        {
            new ChangeShaderUpgradeInfo("Mochie/Standard", "cddaa3a02eb956746b502b80b76e92bc", "61dfaeeda7ef44742b40324ecd77f87c", new MochieMaterialUpgrade_V0_To_V1()),
            new ChangeShaderUpgradeInfo("Mochie/Standard Lite", "f927f4173320600459911ac97d99d0a2", "cc6f91d2b31e3e4408db75c7c6a5f034",new MochieMaterialUpgrade_V0_To_V1()),
            
            new ShaderUpgradeInfo("Mochie/Standard", new MochieMaterialUpgrade_ApplyKeywords()),
            new ShaderUpgradeInfo("Mochie/Standard Lite", new MochieMaterialUpgrade_ApplyKeywords()),
        };
        
        public static void AutoUpgradeAllMaterials()
        {
            var allMaterials = AssetDatabase.FindAssets("t:Material")
                .Select(guid => AssetDatabase.LoadAssetAtPath<Material>(AssetDatabase.GUIDToAssetPath(guid)))
                .ToArray();
            
            UpgradeMaterials(allMaterials);
        }

        public static void UpgradeMaterials(IEnumerable<Material> materials)
        {
            foreach(var material in materials)
            {
                if(material.parent != null)
                {
                    #if MOCHIE_DEV
                    Debug.Log($"Skipping upgrade of material <b>{material.name}</b> because it's a variant of <b>{material.parent.name}</b>");
                    #endif
                    continue;
                }
                
                AssetDatabase.SaveAssetIfDirty(material);

                foreach(var upgrade in ShaderUpgrades)
                    upgrade.RunUpgrade(material);
            }
        }
    }
}
