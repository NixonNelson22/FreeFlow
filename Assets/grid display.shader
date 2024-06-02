Shader "Unlit/grid display"
{
    Properties
    {
        [HDR]_GridColor ("Grid Color",Color) = (1,0,0,1)
        _Tiling ("Tiling",float) = 0.1
        _Offset ("offset",float) = 0.1
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

            float4 _GridColor;
            float _Tiling;
            float _Offset;
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
                o.uv = v.uv;
                return o;
            }

            float GridTest(float2 r){
                float result;
                _Tiling = max(0.1,_Tiling);
                for(float i=0.0; i<2.0 ;i+=_Tiling){
                    for(int j=0; j<2; j++){
                        result += 1.0-smoothstep(0.0,0.003,abs(r[j]-i));
                        
                    }
                }
                
                return result;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 gridColor=(_GridColor * GridTest(i.uv));
                return float4(gridColor);
                
            }
            ENDCG
        }
    }
}
