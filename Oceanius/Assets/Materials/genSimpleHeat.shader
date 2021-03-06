// Per pixel bumped refraction.
// Uses a normal map to distort the image behind, and
// an additional texture to tint the color.

Shader "CustomGen/genSimpleHeat" {
Properties {
	_Color ("Tint Color", Color) = (0,0,0,0)
	_AddColor ("Add Color", Color) = (0,0,0,0)
	_BumpAmt  ("Distortion Strength", range (0,128)) = 10
	_EffectCutoff ("Effect Cutoff", range (0.0, 0.9)) = 0.15
	_MainTex ("Key (RGB)", 2D) = "white" {}
	_BumpMap ("Normalmap", 2D) = "bump" {}
}

Category {

	// We must be transparent, so other objects are drawn before this one.
	Tags { "Queue"="Transparent+1000" "RenderType"="Opaque" }


	SubShader {

		// This pass grabs the screen behind the object into a texture.
		// We can access the result in the next pass as _GrabTexture
		GrabPass {							
			Name "BASE"
			Tags { "LightMode" = "Always" }
 		}
 		
 		// Main pass: Take the texture grabbed above and use the bumpmap to perturb it
 		// on to the screen
		Pass {
			Name "BASE"
			Tags { "LightMode" = "Always" }
			Cull Off
			
CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#pragma fragmentoption ARB_precision_hint_fastest
#include "UnityCG.cginc"

struct appdata_t {
	float4 vertex : POSITION;
	float2 texcoord: TEXCOORD0;
};

struct v2f {
	float4 vertex : POSITION;
	float4 uvgrab : TEXCOORD0;
	float2 uvbump : TEXCOORD1;
	float2 uvmain : TEXCOORD2;
};

uniform float4 _Color;
uniform float4 _AddColor;
uniform float _EffectCutoff;
uniform float _BumpAmt;
float4 _BumpMap_ST;
float4 _MainTex_ST;

v2f vert (appdata_t v)
{
	v2f o;
	o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
	#if UNITY_UV_STARTS_AT_TOP
	float scale = -1.0;
	#else
	float scale = 1.0;
	#endif
	o.uvgrab.xy = (float2(o.vertex.x, o.vertex.y*scale) + o.vertex.w) * 0.5;
	o.uvgrab.zw = o.vertex.zw;
	o.uvbump = TRANSFORM_TEX( v.texcoord, _BumpMap );
	o.uvmain = TRANSFORM_TEX( v.texcoord, _MainTex );
	return o;
}

sampler2D _GrabTexture;
float4 _GrabTexture_TexelSize;
sampler2D _BumpMap;
sampler2D _MainTex;

half4 frag( v2f i ) : COLOR
{
	half4 key = tex2D( _MainTex, i.uvmain );
	half effect = saturate ((key.r - _EffectCutoff) / (1.0 - _EffectCutoff));
	effect *= effect;
	
	// calculate perturbed coordinates
	half2 bump = UnpackNormal(tex2D( _BumpMap, i.uvbump )).rg; // we could optimize this by just reading the x & y without reconstructing the Z
	float2 offset = bump * effect * _BumpAmt * _GrabTexture_TexelSize.xy;
	i.uvgrab.xy = offset * i.uvgrab.z + i.uvgrab.xy;
	
	half4 col = tex2Dproj( _GrabTexture, UNITY_PROJ_COORD(i.uvgrab));
		// Tint the distorted image
	col = lerp(col, col * _Color, effect * _Color.a);
		// Add some emissive color (similar to Particles/Additive)
	col += _AddColor * _AddColor.a * effect;
	return (col);
}
ENDCG
		}
	}

	// ------------------------------------------------------------------
	// Fallback for older cards and Unity non-Pro
	
	SubShader {
		Blend DstColor Zero
		Pass {
			Name "BASE"
			SetTexture [_MainTex] {	combine texture }
		}
	}
}

}
