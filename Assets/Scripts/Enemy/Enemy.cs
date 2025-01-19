using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int demage;
    public BubbleColorType bubbleColorType;
    SpriteRenderer spRender;

    public void Init()
    {
        spRender = GetComponent<SpriteRenderer>();
        bubbleColorType = ((BubbleColorType)Random.Range(0, 9));
        DealColor();
    }


    /// <summary>
    /// ������ ��������ɫ
    /// </summary>
    private void DealColor()
    {
        switch (bubbleColorType)
        {
            case BubbleColorType.Red:
            case BubbleColorType.Green:
            case BubbleColorType.Blue:
            case BubbleColorType.Yellow:
            case BubbleColorType.Purple:
            case BubbleColorType.Transparent:
                spRender.color = Color.yellow;
                break;
            case BubbleColorType.stationary:
                spRender.color = Color.red;
                break;
            case BubbleColorType.bouncing:
                spRender.color = Color.white;
                break;
            case BubbleColorType.chased:
                spRender.color = Color.cyan;
                break;
        }
    }

      
    /// <summary>
    /// ����˺�
    /// </summary>
    public void TakeDamage(PlayerController player)
    {
        player.HP -= demage;
    }

    /// <summary>
    /// ������ת
    /// </summary>
    public void ChangeScene()
    {
        BubbleManager.Instance.EnterNewBubble(this);
    }
}
