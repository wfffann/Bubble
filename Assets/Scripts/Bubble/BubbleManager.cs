using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BubbleManager : Singleton<BubbleManager>
{
    public Transform NPCTar;
    public int NUM=15;

    //���
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        Init();

    }

    /// <summary>
    /// ��ʼ��
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
    /// �����µ������ڲ�
    /// </summary>
    public void EnterNewBubble(Enemy enemy)
    {
        switch (enemy.bubbleColorType)
        {
            case BubbleColorType.Red:
                SceneManager.LoadScene("RedScene");//����Ŀ�곡��
                break;
            case BubbleColorType.Green:
                SceneManager.LoadScene("GreenScene");//����Ŀ�곡��
                break;
            case BubbleColorType.Blue:
                SceneManager.LoadScene("BlueScene");//����Ŀ�곡��
                break;
            case BubbleColorType.Yellow:
                SceneManager.LoadScene("YellowScene");//����Ŀ�곡��
                break;
        }
    }
    public void ExitCurrentBubble()
    {

        ////����ԭʼ����
        //string sceneName = ChangeScene.Instance.SwitchSceneByBubbleColorType(originalBubbleColorType);
        //ChangeScene.Instance.LoadNewScene(sceneName);//����Ŀ�곡��

        ////����˳����������
        //AddNewItem(currentBubbleColorType);

        //BubbleColorType temp;
        //temp = originalBubbleColorType;
        //originalBubbleColorType = currentBubbleColorType;
        //currentBubbleColorType = temp;
    }

    
}
