Shader "Custom/UnlitDissolve"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _NoiseTexture ("Noise texture", 2D) = "white" {}
        _DissolveFactor ("Dissolve factor", Range(0, 1)) = 0.2
        _DissolveSize ("Dissolve size", Range(0, 0.1)) = 0.02
        [HDR] _DissolveColor("Dissolve color", Color) = (0.27, 1, 0.26, 1)
    }
    SubShader
    {
        Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
        Blend SrcAlpha OneMinusSrcAlpha
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            sampler2D _NoiseTexture;
            float4 _MainTex_ST;
            half _DissolveFactor;
            half _DissolveSize;
            fixed4 _DissolveColor;

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

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                half4 main_texture_color = tex2D(_MainTex, i.uv);
                const half noise_texture_color = tex2D(_NoiseTexture, i.uv).r;

                if (noise_texture_color < _DissolveFactor + _DissolveSize)
                {
                    main_texture_color = _DissolveColor;
                }
                
                if (noise_texture_color < _DissolveFactor)
                {
                    main_texture_color.a = 0;
                }
                
                return main_texture_color;
            }
            ENDCG
        }
    }
}
