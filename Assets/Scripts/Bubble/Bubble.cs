
using UnityEngine;
using UnityEngine.SceneManagement;  // 引入场景管理命名空间

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
    Transparent
}

public class Bubble : MonoBehaviour
{
    public BubbleColorType bubbleColorType;  // 泡泡的颜色类型

    // 碰撞检测方法
    private void OnCollisionEnter(Collision collision)
    {
        // 检查是否与指定物体发生碰撞（可以根据需要判断）
        if (collision.gameObject.CompareTag("Player"))
        {
            SwitchSceneBasedOnColor();
        }
    }

    // 根据泡泡的颜色切换场景
    private void SwitchSceneBasedOnColor()
    {
        // 根据不同的颜色类型切换到对应的场景
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
                Debug.LogWarning("未设置对应颜色的场景");
                break;
        }
    }
}
