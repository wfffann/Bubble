using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 泡泡颜色--对应不同的场景
/// </summary>
public enum BubbleColorType
{
    Red,
    Green, 
    Blue,
    Yellow,
    Purple,
    transparent
}

public class Bubble : MonoBehaviour
{
    public BubbleColorType bubbleColorType;
}
