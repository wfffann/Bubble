using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������ɫ--��Ӧ��ͬ�ĳ���
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
