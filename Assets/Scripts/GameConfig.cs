using System.Collections.Generic;
using UnityEngine;

public class GameConfig : MonoBehaviour
{
    [Header("Bubble View")]
    [SerializeField] private List<Color> _bubbleColors;
    [SerializeField] private float _bubbleLightAlpha;
    [SerializeField] private float _bubbleLightRelativeRadius;
    [SerializeField] private float _nextBubbleBlinkFrequency;

    [Header("Bubble physics")]
    [SerializeField] private float _bubbleInertionTime;

    [Header("Cannon")]
    [SerializeField] private float _coolDown;
    [SerializeField] private int _minSize;
    [SerializeField] private int _maxSize;

    [Header("Borders")]
    [SerializeField] private float _borderWidth;
    [SerializeField] private float _lowerBorderHeight;
    [SerializeField] private float _maximalWidthToHeightRatio;
    [SerializeField] private float _timeToGameOver;

    [Header("Advertisement")]
    [SerializeField] private float _adTimeCounter;
    [SerializeField] private float _adWarningLifeTime;


    public List<Color> BubbleColors { get { return _bubbleColors; } }
    public float BubbleLightAlpha { get { return _bubbleLightAlpha; } }
    public float BubbleLightRelativeRadius { get { return _bubbleLightRelativeRadius; } }
    public float BubbleInertionTime { get { return _bubbleInertionTime; } }
    public float CoolDown { get { return _coolDown; } }
    public int MinSize { get { return _minSize; } }
    public int MaxSize { get { return _maxSize; } }
    public float AdTimeCounter { get { return _adTimeCounter; } }
    public float AdWarningLifeTime { get { return _adWarningLifeTime; } }
    public float NextBubbleBlinkFrequency { get { return _nextBubbleBlinkFrequency; } }
    public float BorderWidth { get { return _borderWidth; } }
    public float LowerBorderHeight { get { return _lowerBorderHeight; } }
    public float MaximalWidthToHeightRatio { get { return _maximalWidthToHeightRatio; } }
    public float TimeToGameOver { get { return _timeToGameOver; } }
}
