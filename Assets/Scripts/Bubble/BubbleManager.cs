using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BubbleManager : Singleton<BubbleManager>
{
    public Transform NPCTar;
    public int NUM=15;

    //组件
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        Init();

    }

    /// <summary>
    /// 初始化
    /// </summary>
    public void Init()
    {
        for (int i = 0; i < NUM; i++)
        {
            CreateMonster();
        }


    }
     
    public void CreateMonster()
    {
        Enemy tempEnemy = Instantiate(Resources.Load<Enemy>("Perfabs\\TestMonster"));
        tempEnemy.transform.SetParent(NPCTar);
        tempEnemy.transform.position = new Vector3(Random.Range(-30, 30), Random.Range(-20, 20), 0);

        tempEnemy.Init();
    }







    /// <summary>
    /// 进入新的泡泡内部
    /// </summary>
    public void EnterNewBubble(Enemy enemy)
    {
        switch (enemy.bubbleColorType)
        {
            case BubbleColorType.Red:
                SceneManager.LoadScene("RedScene");//加载目标场景
                break;
            case BubbleColorType.Green:
                SceneManager.LoadScene("GreenScene");//加载目标场景
                break;
            case BubbleColorType.Blue:
                SceneManager.LoadScene("BlueScene");//加载目标场景
                break;
            case BubbleColorType.Yellow:
                SceneManager.LoadScene("YellowScene");//加载目标场景
                break;
        }
    }
    public void ExitCurrentBubble()
    {

        ////加载原始场景
        //string sceneName = ChangeScene.Instance.SwitchSceneByBubbleColorType(originalBubbleColorType);
        //ChangeScene.Instance.LoadNewScene(sceneName);//加载目标场景

        ////添加退出场景的物件
        //AddNewItem(currentBubbleColorType);

        //BubbleColorType temp;
        //temp = originalBubbleColorType;
        //originalBubbleColorType = currentBubbleColorType;
        //currentBubbleColorType = temp;
    }

    
}
