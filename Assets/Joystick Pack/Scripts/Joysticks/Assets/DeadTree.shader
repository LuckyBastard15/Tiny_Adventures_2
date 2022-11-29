Shader "Custom/DeadTree"
{
    Properties
    {
        //_Color ("Color", Color) = (1,1,1,1)
        _MainTex("Albedo (RGB)", 2D) = "white" {}
    //_Glossiness ("Smoothness", Range(0,1)) = 0.5
    _Range("Metallic", Range(0,1)) = 1
    }
        SubShader
    {
        Pass
        {
            ZWrite Off
            ColorMask 0
        }
        Tags { "RenderType" = "Opaque" }
        //LOD 200
        CGPROGRAM
        #pragma surface surf Lambert alpha
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        //half _Glossiness;
        half _Range;
        //fixed4 _Color;


        void surf(Input IN, inout SurfaceOutput o)
        {

            fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;
            //o.Metallic = _Metallic;
            //o.Smoothness = _Glossiness;
            o.Alpha = c.a;

        }
        ENDCG
    }
        FallBack "Diffuse"
}


