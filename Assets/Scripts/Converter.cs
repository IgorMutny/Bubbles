using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Converter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Texture2D texture = GetComponent<SpriteRenderer>().sprite.texture;

        Texture2D newTex = new Texture2D(texture.width, texture.height);

        for (int x = 0; x < texture.width; x++)
            for (int y = 0; y < texture.height; y++)
            {
                Color color = texture.GetPixel(x, y);
                color.a *= Mathf.Sqrt(color.a);
                newTex.SetPixel(x, y, color);
            }

        newTex.Apply();

        byte[] bytes = newTex.EncodeToPNG();
        File.WriteAllBytes(Application.dataPath + "bubble.png", bytes);
    }
}
