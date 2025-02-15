namespace Mochie.ShaderUpgrader
{
    public class CopyFloatPropertyValueAction : CopyPropertyValueActionBase
    {
        public CopyFloatPropertyValueAction(string sourcePropertyName, string targetPropertyName) : base(sourcePropertyName, targetPropertyName, SerializedMaterialPropertyType.Float) {}

        public override void RunAction(MaterialContext materialContext)
        {
            if(materialContext.TryGetFloat(SourcePropertyName, out float floatValue)) 
                materialContext.Material.SetFloat(TargetPropertyName, floatValue);
        }
    }
}