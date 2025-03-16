using UnityEditor;
using UnityEngine;

namespace Mochie.ShaderUpgrader
{
    public class ApplyKeywordsAction : UpgradeActionBase
    {
        public override void RunAction(MaterialContext materialContext)
        {
            var editor = Editor.CreateEditor(materialContext.Material) as MaterialEditor;
            Shader shader = materialContext.Material.shader;
            editor.SetShader(shader, false);
        }
    }
}