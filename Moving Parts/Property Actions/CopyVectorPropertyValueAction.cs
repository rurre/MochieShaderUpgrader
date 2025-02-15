using UnityEngine;

namespace Mochie.ShaderUpgrader
{
    public class CopyVectorPropertyValueAction : CopyPropertyValueActionBase
    {
        public CopyVectorPropertyValueAction(string sourcePropertyName, string targetPropertyName) : base(sourcePropertyName, targetPropertyName, SerializedMaterialPropertyType.Vector) {}

        public override void RunAction(MaterialContext materialContext)
        {
            if(materialContext.TryGetColorOrVector(SourcePropertyName, out Color vectorValue)) 
                materialContext.Material.SetVector(TargetPropertyName, vectorValue);
        }
    }
}