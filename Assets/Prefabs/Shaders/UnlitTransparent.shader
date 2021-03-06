Shader "Unlit/UnlitTransparent"
{
	Properties
	{
		[HDR] _Color ("Color", Color) = (1, 1, 1, 1)
	}
	SubShader
	{
		Tags { "Queue"="Transparent" "RenderType"="Transparent" }
		LOD 100

		Pass
		{
			Blend SrcAlpha OneMinusSrcAlpha
			Lighting Off
        	Fog { Mode Off }

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			fixed4 _Color;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);

				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				float x = i.uv.x;
				float y = i.uv.y;
				
				float dis = sqrt(pow((0.5 - x), 2) + pow((0.5 - y), 2));
				
                if (dis > 0.5) 
                    discard;
				
				return _Color;
			}
			ENDCG
		}
	}
}