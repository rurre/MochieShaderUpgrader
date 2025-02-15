using System;
using UnityEditor;
using UnityEngine;

namespace Mochie.ShaderUpgrader
{
    /// <summary>
    /// Sets a material's property value based on TargetPropertyName
    /// </summary>
    public class SetPropertyValueAction : PropertyActionBase
    {
        bool SkipIfNonDefault { get; set; }
        float FloatValue { get; set; }
        int IntValue { get; set; }
        Vector4 VectorValue { get; set; }
        GUID GuidValue { get; set; }

        /// <summary>
        /// Sets a material's Float property value based on TargetPropertyName 
        /// </summary>
        /// <param name="targetPropertyName">Target property name</param>
        /// <param name="skipIfNonDefault">Skip this action if value of <paramref name="targetPropertyName"/> is not default.</param>
        /// <param name="floatValue">Float value to set</param>
        public SetPropertyValueAction(string targetPropertyName, bool skipIfNonDefault, float floatValue) : base(null, targetPropertyName, SerializedMaterialPropertyType.Float)
        {
            SkipIfNonDefault = skipIfNonDefault;
            FloatValue = floatValue;
        }
        
        /// <summary>
        /// Sets a material's Int property value based on TargetPropertyName 
        /// </summary>
        /// <param name="targetPropertyName">Target property name</param>
        /// <param name="skipIfNonDefault">Skip this action if value of <paramref name="targetPropertyName"/> is not default.</param>
        /// <param name="intValue">Int value to set</param>
        public SetPropertyValueAction(string targetPropertyName, bool skipIfNonDefault, int intValue) : base(null, targetPropertyName, SerializedMaterialPropertyType.Int)
        {
            SkipIfNonDefault = skipIfNonDefault;
            IntValue = intValue;
        }
        
        /// <summary>
        /// Sets a material's Texture based on TargetPropertyName. Guid is used to load the texture from the AssetDatabase. 
        /// </summary>
        /// <param name="targetPropertyName">Target property name</param>
        /// <param name="skipIfNonDefault">Skip this action if value of <paramref name="targetPropertyName"/> is not default.</param>
        /// <param name="guidValue">Guid value to load texture from</param>
        public SetPropertyValueAction(string targetPropertyName, bool skipIfNonDefault, GUID guidValue) : base(null, targetPropertyName, SerializedMaterialPropertyType.Texture)
        {
            SkipIfNonDefault = skipIfNonDefault;
            GuidValue = guidValue;
        }
        
        /// <summary>
        /// Sets a material's Vector or Color property value based on TargetPropertyName 
        /// </summary>
        /// <param name="targetPropertyName">Target property name</param>
        /// <param name="skipIfNonDefault">Skip this action if value of <paramref name="targetPropertyName"/> is not default.</param>
        /// <param name="vectorValue">Vector value to set. Can be Vector2, Vector3, Vector4 or Color</param>
        public SetPropertyValueAction(string targetPropertyName, bool skipIfNonDefault, Vector4 vectorValue) : base(null, targetPropertyName, SerializedMaterialPropertyType.Vector)
        {
            SkipIfNonDefault = skipIfNonDefault;
            VectorValue = vectorValue;
        }

        public override void RunAction(MaterialContext materialContext)
        {
            switch(PropertyType)
            {
                case SerializedMaterialPropertyType.Float:
                    if(!SkipIfNonDefault && materialContext.TryGetFloat(TargetPropertyName, out float currentFloatValue))
                    {
                        if(Mathf.Approximately(currentFloatValue, default))
                            materialContext.Material.SetFloat(TargetPropertyName, FloatValue);
                    }
                    else
                        materialContext.Material.SetFloat(TargetPropertyName, FloatValue);
                    break;
                case SerializedMaterialPropertyType.Int:
                    if(!SkipIfNonDefault && materialContext.TryGetInt(TargetPropertyName, out int currentIntValue))
                    {
                        if(currentIntValue == default)
                            materialContext.Material.SetInt(TargetPropertyName, IntValue);
                    }
                    else
                    {
                        materialContext.Material.SetInt(TargetPropertyName, IntValue);
                    }
                    break;
                case SerializedMaterialPropertyType.Vector:
                    if(!SkipIfNonDefault && materialContext.TryGetColorOrVector(TargetPropertyName, out Color currentVectorValue))
                    {
                        if(currentVectorValue == default)
                            materialContext.Material.SetColor(TargetPropertyName, VectorValue);
                    }
                    else
                    {
                        materialContext.Material.SetColor(TargetPropertyName, VectorValue);
                    }
                    break;
                case SerializedMaterialPropertyType.Texture:
                    if(GuidValue.Empty())
                    {
                        Debug.LogError("Texture GUID is empty.");
                        break;
                    }

                    string assetPath = AssetDatabase.GUIDToAssetPath(GuidValue);
                    if(string.IsNullOrWhiteSpace(assetPath))
                    {
                        Debug.LogError($"Couldn't get asset path of GUID {GuidValue}. Asset might not exist in your project.");
                        break;
                    }

                    Texture newTexture = AssetDatabase.LoadAssetAtPath<Texture>(assetPath);
                    if(newTexture == null)
                    {
                        Debug.LogError($"Couldn't load texture with guid {GuidValue}. It's probably not a texture.");
                        break;
                    }

                    if(!SkipIfNonDefault && materialContext.TryGetTexture(TargetPropertyName, out TextureContainer currentTextureContainerValue))
                    {
                        if(currentTextureContainerValue.texture == null)
                            materialContext.Material.SetTexture(TargetPropertyName, newTexture);
                    }
                    else
                    {
                        materialContext.Material.SetTexture(TargetPropertyName, newTexture);
                    }
                    break;
                default:
                    throw new ArgumentException($"Unsupported property type {PropertyType}");
            }
        }
    }
}