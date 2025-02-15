namespace Mochie.ShaderUpgrader
{
    public class CopyIntPropertyValueAction : CopyPropertyValueActionBase
    {
        public CopyIntPropertyValueAction(string sourcePropertyName, string targetPropertyName) : base(sourcePropertyName, targetPropertyName, SerializedMaterialPropertyType.Int) {}


        public override void RunAction(MaterialContext materialContext)
        {
            if(materialContext.TryGetInt(SourcePropertyName, out int intValue)) 
                materialContext.Material.SetInt(TargetPropertyName, intValue);
        }
    }
}