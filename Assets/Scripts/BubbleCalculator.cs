using UnityEngine;

public static class BubbleCalculator
{
    public static float GetDiameter(int size)
    {
        float sizeFloat = size;
        float volume = Mathf.Pow(2, 1 + sizeFloat / 2);
        float diameter = Mathf.Pow(3 * volume / 4 / Mathf.PI, 0.33f) * 2;
        return diameter;
    }

    public static float GetRadius(int size)
    {
        return GetDiameter(size) / 2;
    }

    public static float GetNumberAlpha(Color color)
    {
        return 1 - color.b / 2;
    }
}
