using System;
using UnityEditor;
using UnityEngine;

namespace Mochie.ShaderUpgrader
{
    public class CopyPropertyValueAction : PropertyActionBase
    {
        public CopyPropertyValueAction(string sourcePropertyName, string targetPropertyName, SerializedMaterialPropertyType propertyType) : base(sourcePropertyName, targetPropertyName, propertyType) {}

        public override void RunAction(MaterialContext materialContext)
        {
            switch(PropertyType)
            {
                case SerializedMaterialPropertyType.Float:
                    if(materialContext.TryGetFloat(SourcePropertyName, out float floatValue)) 
                        materialContext.Material.SetFloat(TargetPropertyName, floatValue);
                    break;
                case SerializedMaterialPropertyType.Int:
                    if(materialContext.TryGetInt(SourcePropertyName, out int intValue)) 
                        materialContext.Material.SetInt(TargetPropertyName, intValue);
                    break;
                case SerializedMaterialPropertyType.Texture:
                    if(materialContext.TryGetTexture(SourcePropertyName, out TextureContainer textureContainerValue))
                    {
                        materialContext.Material.SetTexture(TargetPropertyName, textureContainerValue.texture);
                        materialContext.Material.SetTextureOffset(TargetPropertyName, textureContainerValue.offset);
                        materialContext.Material.SetTextureScale(TargetPropertyName, textureContainerValue.scale);
                    }
                    break;
                case SerializedMaterialPropertyType.Vector:
                    if(materialContext.TryGetColorOrVector(SourcePropertyName, out Color vectorValue)) 
                        materialContext.Material.SetVector(TargetPropertyName, vectorValue);
                    break;
                default:
                    throw new ArgumentException($"Unsupported property type {PropertyType}");
            }
        }
    }
}