using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleManager : Singleton<BubbleManager>
{
    //����
    public BubbleColorType currentBubbleColorType;
    public BubbleColorType originalBubbleColorType;

    public GameObject currentItem;
    public GameObject targetItem;

    //���

    private void Start()
    {
        Init();
    }

    /// <summary>
    /// ��ʼ��
    /// </summary>
    public void Init()
    {
        currentItem.gameObject.SetActive(false);
        currentBubbleColorType = BubbleColorType.transparent;
    }

    /// <summary>
    /// �����µ������ڲ�
    /// </summary>
    public void EnterNewBubble(BubbleColorType bubbleColorType)
    {
        originalBubbleColorType = currentBubbleColorType;//��¼ԭʼ����
      
        string sceneName = ChangeScene.Instance.SwitchSceneByBubbleColorType(bubbleColorType);
        ChangeScene.Instance.LoadNewScene(sceneName);//����Ŀ�곡��

        currentBubbleColorType = bubbleColorType;
    }

    /// <summary>
    /// �˳���ǰ������
    /// </summary>
    public void ExitCurrentBubble()
    {

        //����ԭʼ����
        string sceneName = ChangeScene.Instance.SwitchSceneByBubbleColorType(originalBubbleColorType);
        ChangeScene.Instance.LoadNewScene(sceneName);//����Ŀ�곡��

        //����˳����������
        AddNewItem(currentBubbleColorType);

        BubbleColorType temp;
        temp = originalBubbleColorType;
        originalBubbleColorType = currentBubbleColorType;
        currentBubbleColorType = temp;
    }

    /// <summary>
    /// ������������µ����
    /// </summary>
    public void AddNewItem(BubbleColorType bubbleColorType)
    {
        switch (bubbleColorType)
        {
            case BubbleColorType.Red:
                //�滻currentItem
                break;
            case BubbleColorType.Green:
                break;
            case BubbleColorType.Blue:
                break;
            case BubbleColorType.Yellow:
                break;
            case BubbleColorType.Purple:
                break;
            case BubbleColorType.transparent:
                break;
            default:
                break;
        }
    }
}
