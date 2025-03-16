using UnityEditor;
using UnityEngine;

namespace Mochie.ShaderUpgrader
{
    public class ApplyKeywordsAction : UpgradeActionBase
    {
        public override void RunAction(MaterialContext materialContext)
        {            
            #if MOCHIE_DEV
            Debug.Log("Running ApplyKeywordsAction");
            #endif
            
            var editor = Editor.CreateEditor(materialContext.Material) as MaterialEditor;
            Shader shader = materialContext.Material.shader;
            editor.SetShader(shader, false);
        }
    }
}