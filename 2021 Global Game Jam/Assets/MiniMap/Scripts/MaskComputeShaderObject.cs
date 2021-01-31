using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace minimap
{

    public class MaskComputeShaderObject : MonoBehaviour
    {
        [Header("Shader")]
        public ComputeShader computeShader;

        [Header("Textures")]
        public RenderTexture renderTexture;
        public List<Texture2D> textures = new List<Texture2D>();

        [Header("Public References")]
        public Image maskImage;

        [Header("Zone unlock flags")]
        public bool zone1Flag = false;
        public bool zone2Flag = false;
        public bool zone3Flag = false;
        public bool zone4Flag = false;

        void Start()
        {
            renderTexture = new RenderTexture(textures[0].width, textures[0].height, 25);
            renderTexture.enableRandomWrite = true;
            renderTexture.Create();

            CreateNewTexture();
        }

        public void CreateNewTexture()
        {
            computeShader.SetTexture(0, "Result", renderTexture);

            computeShader.SetTexture(0, "BaseTexture", textures[0]);
            computeShader.SetTexture(0, "zone1Texture", textures[1]);
            computeShader.SetTexture(0, "zone2Texture", textures[2]);
            computeShader.SetTexture(0, "zone3Texture", textures[3]);
            computeShader.SetTexture(0, "zone4Texture", textures[4]);

            computeShader.SetBool("zone1Flag", zone1Flag);
            computeShader.SetBool("zone2Flag", zone2Flag);
            computeShader.SetBool("zone3Flag", zone3Flag);
            computeShader.SetBool("zone4Flag", zone4Flag);

            computeShader.Dispatch(0, renderTexture.width / 8, renderTexture.height / 8, 1);

            Sprite textureSprite = Sprite.Create(toTexture2D(renderTexture), new Rect(0, 0, renderTexture.width, renderTexture.height), new Vector2(0, 0));

            maskImage.sprite = textureSprite;
        }

        private Texture2D toTexture2D(RenderTexture rTex)
        {
            Texture2D dest = new Texture2D(rTex.width, rTex.height, TextureFormat.RGBA32, false);
            dest.Apply(false);
            Graphics.CopyTexture(rTex, dest);
            return dest;
        }
    }
}
