using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Mochie.ShaderUpgrader
{
    public class MochieMaterialUpgrade_V0_To_V1 : MochieMaterialUpgradeBase
    {
        public override bool CanUpgradeMaterial(Material material)
        {
            // Skip if material doesn't use our any of our shaders
            if(MochieShaderMaterialAutoUpgrade.ShaderNames.All(name => name != material.shader.name))
                return false;
            return true;
        }

        public override List<PropertyActionBase> AddPropertyActions()
        {
            return new List<PropertyActionBase>
            {  
                new CopyPropertyValueAction("_Workflow", "_PrimaryWorkflow", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_SamplingMode","_PrimarySampleMode", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_DetailSamplingMode", "_DetailSampleMode", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_TriplanarSpace", "_TriplanarCoordSpace", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_UseSmoothness", "_SmoothnessToggle", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_UseHeight", "_PackedHeight", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_UseAlphaMask", "_AlphaSource", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_SpecGlossMap", "_RoughnessMap", SerializedMaterialPropertyType.Texture),
                new CopyPropertyValueAction("_MetallicGlossMap", "_MetallicMap", SerializedMaterialPropertyType.Texture),
                new CopyPropertyValueAction("_Metallic", "_MetallicStrength",SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_Glossiness", "_RoughnessStrength", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_BumpMap", "_NormalMap", SerializedMaterialPropertyType.Texture),
                new CopyPropertyValueAction("_BumpScale", "_NormalStrength", SerializedMaterialPropertyType.Texture),
                new CopyPropertyValueAction("_Parallax", "_HeightStrength", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_ParllaxMask", "_HeightMask", SerializedMaterialPropertyType.Texture),
                new CopyPropertyValueAction("_ParallaxOffset", "_HeightOffset", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_ParallaxSteps", "_HeightSteps", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_ParallaxMap", "_HeightMap", SerializedMaterialPropertyType.Texture),
                new CopyPropertyValueAction("_RoughnessMult", "_RoughnessMultiplier", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_MetallicMult", "_MetallicMultiplier", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_OcclusionMult", "_OcclusionMultiplier", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_HeightMult", "_HeightMultiplier", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_EmissionFloatensity", "_EmissionStrength", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_EmissPulseStrength", "_EmissionPulseStrength", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_EmissPulseSpeed", "_EmissionPulseSpeed", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_EmissPulseWave", "_EmissionPulseWave", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_DetailAlbedoMap", "_DetailMaFloatex", SerializedMaterialPropertyType.Texture),
                new CopyPropertyValueAction("_DetailAlbedoBlend", "_DetailMaFloatexBlend", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_DetailAOMap", "_DetailOcclusionMap", SerializedMaterialPropertyType.Texture),
                new CopyPropertyValueAction("_DetailAOBlend", "_DetailOcclusionBlend", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_DetailNormalMapScale", "_DetailNormalStrength", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_DetailRoughBlend", "_DetailRoughnessBlend", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_UseFresnel", "_FresnelToggle", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_GlossyReflections", "_ReflectionsToggle", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_SpecularHighlights", "_SpecularHighlightsToggle", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_SpecularStrength", "_SpecularHighlightStrength", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_ReflShadows", "_SpecularOcclusionToggle", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_ReflShadowStrength","_SpecularOcclusionStrength", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_ContrastReflShad", "_SpecularOcclusionContrast", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_BrightnessReflShad", "_SpecularOcclusionBrightness", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_HDRReflShad", "_SpecularOcclusionHDR", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_TFloatReflShad", "_SpecularOcclusionTFloat", SerializedMaterialPropertyType.Vector),
                new CopyPropertyValueAction("_ReflShadowsAreaLit", "_AreaLitSpecularOcclusion", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_AreaLitRoughnessMult", "_AreaLitRoughnessMultiplier", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_GSAA", "_GSAAToggle", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_BicubicLightmap", "_BicubicSampling", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_UVPri", "_UVMainSet", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_UV0Rotate", "_UVMainRotation", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_UV0Scroll", "_UVMainScroll", SerializedMaterialPropertyType.Vector),
                new CopyPropertyValueAction("_UVPriSwizzle", "_UVMainSwizzle", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_UVSec", "_UVDetailSet", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_UV1Rotate", "_UVDetailRotation", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_UV1Scroll", "_UVDetailScroll", SerializedMaterialPropertyType.Vector),
                new CopyPropertyValueAction("_UVSecSwizzle", "_UVDetailSwizzle", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_UVHeightMask", "_UVHeightMaskSet", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_UV2Rotate", "_UVHeightMaskRotation", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_UV2Scroll", "_UVHeightMaskScroll", SerializedMaterialPropertyType.Vector),
                new CopyPropertyValueAction("_UVEmissMask", "_UVEmissionMaskSet", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_UVEmissMaskSwizzle", "_UVEmissionMaskSwizzle", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_UV3Rotate", "_UVEmissionMaskRotation", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_UV3Scroll", "_UVEmissionMaskScroll", SerializedMaterialPropertyType.Vector),
                new CopyPropertyValueAction("_UVAlphaMask", "_UVAlphaMaskSet", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_UV4Rotate", "_UVAlphaMaskRotation", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_UV4Scroll", "_UVAlphaMaskScroll", SerializedMaterialPropertyType.Vector),
                new CopyPropertyValueAction("_UVRainMask", "_UVRainMaskSet", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_UV5Rotate", "_UVRainMaskRotation", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_UV5Scroll", "_UVRainMaskScroll", SerializedMaterialPropertyType.Vector),
                new CopyPropertyValueAction("_UVDetailMask", "_UVDetailMaskSet", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_DetailRotate", "_UVDetailMaskRotation", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_DetailScroll", "_UVDetailMaskScroll", SerializedMaterialPropertyType.Vector),
                new CopyPropertyValueAction("_UVRain", "_UVRainSet", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_UVRainRotate", "_UVRainRotation", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_OcclusionUVSet", "_AreaLitOcclusionUVSet", SerializedMaterialPropertyType.Float),
                new CopyPropertyValueAction("_Cull", "_Culling", SerializedMaterialPropertyType.Float),
                
                new SetPropertyValueAction("_RainSheet", true, new GUID("df89a63673a32f4438fba4fb13f0f640")),
                new SetPropertyValueAction("_DropletMask", true, new GUID("76ae1285472e6ce48a2f01ef7905b8fd")),
                new SetPropertyValueAction("_DFG", true, new GUID("f8ddbd1e1d2a4415a10b4d48daeba743")),
                new SetPropertyValueAction("_DefaultSampler", true, new GUID("b5f34bbf55503c942821a982c6756e38"))
            };
        }
    }
}