using TMPro;
using UnityEngine;

public class BubbleNumber : MonoBehaviour
{
    public void Initialize(int size, Color color)
    {    
        int number = (int)Mathf.Pow(2, size - 1);

        int digits = 0;
        int numberCopy = number;
        while (numberCopy > 0)
        {
            numberCopy /= 10;
            digits++;
        }

        float a = BubbleCalculator.GetNumberAlpha(color);
        color = new Color((color.r + 1) / 2, (color.g + 1) / 2, (color.b + 1) / 2, a);

        TextMeshPro text = GetComponent<TextMeshPro>();

        text.text = number.ToString();
        text.fontSize = 7 - digits;
        text.color = color;
    }
}
