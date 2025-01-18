using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleManager : Singleton<BubbleManager>
{
    //变量
    public BubbleColorType currentBubbleColorType;
    public BubbleColorType originalBubbleColorType;

    public GameObject currentItem;
    public GameObject targetItem;

    //组件

    private void Start()
    {
        Init();
    }

    /// <summary>
    /// 初始化
    /// </summary>
    public void Init()
    {
        currentItem.gameObject.SetActive(false);
        currentBubbleColorType = BubbleColorType.transparent;
    }

    /// <summary>
    /// 进入新的泡泡内部
    /// </summary>
    public void EnterNewBubble(BubbleColorType bubbleColorType)
    {
        originalBubbleColorType = currentBubbleColorType;//记录原始场景
      
        string sceneName = ChangeScene.Instance.SwitchSceneByBubbleColorType(bubbleColorType);
        ChangeScene.Instance.LoadNewScene(sceneName);//加载目标场景

        currentBubbleColorType = bubbleColorType;
    }

    /// <summary>
    /// 退出当前的泡泡
    /// </summary>
    public void ExitCurrentBubble()
    {

        //加载原始场景
        string sceneName = ChangeScene.Instance.SwitchSceneByBubbleColorType(originalBubbleColorType);
        ChangeScene.Instance.LoadNewScene(sceneName);//加载目标场景

        //添加退出场景的物件
        AddNewItem(currentBubbleColorType);

        BubbleColorType temp;
        temp = originalBubbleColorType;
        originalBubbleColorType = currentBubbleColorType;
        currentBubbleColorType = temp;
    }

    /// <summary>
    /// 在泡泡内添加新的物件
    /// </summary>
    public void AddNewItem(BubbleColorType bubbleColorType)
    {
        switch (bubbleColorType)
        {
            case BubbleColorType.Red:
                //替换currentItem
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
