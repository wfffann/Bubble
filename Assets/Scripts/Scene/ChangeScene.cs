using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : Singleton<ChangeScene>
{

    /// <summary>
    /// �������ݵ���ɫ�仯��ͬ�ĳ���
    /// </summary>
    public string SwitchSceneByBubbleColorType(BubbleColorType bubbleColorType)
    {
        string sceneName = null ;

        switch (bubbleColorType)
        {
            case BubbleColorType.Red:
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

        return sceneName;
    }

    /// <summary>
    /// �����³���
    /// </summary>
    public void LoadNewScene(string sceneName)
    {
        if(sceneName != null)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
