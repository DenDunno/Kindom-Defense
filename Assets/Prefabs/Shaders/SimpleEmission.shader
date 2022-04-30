Shader "Unlit/SimpleEmission"
{
    Properties
    {
        [HDR] _EmissionColor("Emission color", Color) = (0.27, 1, 0.26, 1)
        _Value("Value", float) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100
        
        Pass
        {
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
                float4 vertex : SV_POSITION;
            };

            fixed4 _EmissionColor;
            float _Value;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                return _EmissionColor * _Value;
            }
            ENDCG
        }
    }
}
