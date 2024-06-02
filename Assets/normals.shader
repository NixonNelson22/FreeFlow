Shader "Unlit/NewUnlitShader"
{
    Properties
    {
        _Color ("Color", color) = (1,1,1,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normals : NORMAL;
                float2 uv0 : TEXCOORD0;
            };

            struct Interpolators
            {
                float2 uv : TEXCOORD1;
                float3 normal : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            // sampler2D _MainTex;
            float4 _Color;
            // float4 _MainTex_ST;

            Interpolators vert (appdata v)
            {
                Interpolators o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.normal = UnityObjectToWorldNormal(v.normals);
                o.uv = v.uv0;
                return o;
            }

            fixed4 frag (Interpolators i) : SV_Target
            {
                return float4(i.uv,1,1);
            }
            ENDCG
        }
    }
}
