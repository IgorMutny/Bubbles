using UnityEngine;
using UnityEngine.Rendering.Universal;

public abstract class BubbleAbstract : MonoBehaviour
{
    protected void DefineView(int size, GameConfig gameConfig, SpriteRenderer spriteRenderer,  BubbleNumber number, Light2D light)
    {
        float diameter = BubbleCalculator.GetDiameter(size);
        transform.localScale = new Vector3(diameter, diameter, diameter);

        Color color = gameConfig.BubbleColors[size];
        spriteRenderer.color = color;

        Color lightColor = new Color(color.r, color.g, color.b, color.a * gameConfig.BubbleLightAlpha);
        light.color = lightColor;
        light.pointLightOuterRadius = diameter / 2 * gameConfig.BubbleLightRelativeRadius;

        number.Initialize(size, color);
    }
}
