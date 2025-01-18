
using UnityEngine;
using UnityEngine.SceneManagement;  // ���볡�����������ռ�

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
    Transparent
}

public class Bubble : MonoBehaviour
{
    public BubbleColorType bubbleColorType;  // ���ݵ���ɫ����

    // ��ײ��ⷽ��
    private void OnCollisionEnter(Collision collision)
    {
        // ����Ƿ���ָ�����巢����ײ�����Ը�����Ҫ�жϣ�
        if (collision.gameObject.CompareTag("Player"))
        {
            SwitchSceneBasedOnColor();
        }
    }

    // �������ݵ���ɫ�л�����
    private void SwitchSceneBasedOnColor()
    {
        // ���ݲ�ͬ����ɫ�����л�����Ӧ�ĳ���
        switch (bubbleColorType)
        {
            case BubbleColorType.Red:
                SceneManager.LoadScene("RedScene");
                break;

            case BubbleColorType.Green:
                SceneManager.LoadScene("GreenScene");
                break;

            case BubbleColorType.Blue:
                SceneManager.LoadScene("BlueScene");
                break;

            case BubbleColorType.Yellow:
                SceneManager.LoadScene("YellowScene");
                break;

            case BubbleColorType.Purple:
                SceneManager.LoadScene("PurpleScene");
                break;

            default:
                Debug.LogWarning("δ���ö�Ӧ��ɫ�ĳ���");
                break;
        }
    }
}
