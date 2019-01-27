Shader "Magic/transitionShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_TransitionTex("Transition texture", 2D) = "White" {}
		_Cutoff("Cutoff", Range(0, 1.5)) = 0
		
		_Color_1("Color 1", Color) = (1,1,1,1)
		// _Color_2("Color 2", Color) = (1,1,1,1)
		// _Color_3("Color 3", Color) = (1,1,1,1)
		// _Color_4("Color 4", Color) = (1,1,1,1)

		// _Limit_1("limit_1", Range(1, 3)) = 1
		// _Limit_2("limit_2", Range(1, 3)) = 1
		// _Limit_3("limit_3", Range(1, 3)) = 1
	}

	SubShader
	{
		// No culling or depth
		//Cull Off ZWrite Off ZTest Always

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
			
			sampler2D _MainTex;
			sampler2D _TransitionTex; 
			float _Cutoff;

			// float _Limit_1;
			// float _Limit_2;
			// float _Limit_3;
			
			float4 _Color_1;
			// float4 _Color_2;
			// float4 _Color_3;
			// float4 _Color_4;

			fixed4 frag(v2f i) : SV_Target
			{
				fixed4 transit = tex2D(_TransitionTex, i.uv); 

			if (transit.r < _Cutoff)
				return _Color_1;

			return tex2D(_MainTex, i.uv);
			}
			ENDCG
		}
	}
}
