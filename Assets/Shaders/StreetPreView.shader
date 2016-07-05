Shader "StreetViewConverter/StreetPreView" {
	Properties {
		_ColorTint("ColorTint", Color) = (1,1,1,1)
		_MainTex ("dudu", 2D) = "white" {}
	}
	SubShader {
		Tags { "Queue"="Transparent" "RenderType" = "Opaque" }
		LOD 200
		Cull Front
		Pass {
			CGPROGRAM

				#pragma vertex vert
				#pragma fragment frag
				#include "UnityCG.cginc"
				struct v2f {
					float4 pos : SV_POSITION;
					float2 uv_MainTex : TEXCOORD0;
				};
				float4 _MainTex_ST;
				float4 _ColorTint;
				v2f vert(appdata_base v) {
					v2f o;
					o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
					o.uv_MainTex = TRANSFORM_TEX(v.texcoord, _MainTex);

					return o;
				}
				sampler2D _MainTex;
				float4 frag(v2f IN) : COLOR {
					half4 c = tex2D (_MainTex, IN.uv_MainTex);

					return c;
				}
			ENDCG
		}
	}
	FallBack "Diffuse"
}
