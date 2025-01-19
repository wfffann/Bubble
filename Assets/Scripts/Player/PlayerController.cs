
using UnityEngine;
using UnityEngine.SceneManagement;  // 引入 SceneManager 命名空间

public class PlayerController : MonoBehaviour
{
    // 变量
    public float speed = 5f;               // 最大移动速度
    public float force = 10f;              // 施加的力，控制加速的快慢
    public float drag = 3f;                // 物体的阻力，用于模拟减速

    public int HP = 100;                   // 玩家初始生命值

    private Vector2 moveDir;               // 移动方向

    // 组件
    private Rigidbody2D rb;

    private Enemy tempEnemy;               // 碰撞到的敌人
    private BubbleColorType bubbleColorType; // 碰撞敌人的颜色类型

    private void Start()
    {
        // 获取 Rigidbody2D 组件
        rb = GetComponent<Rigidbody2D>();
        // 设置初始阻力（确保玩家停止时会有自然的减速效果）
        rb.drag = drag;
    }

    private void FixedUpdate()
    {
        // 持续进行玩家移动
        PlayerMove();
    }

    private void Update()
    {
        // 监听玩家输入
        PlayerKeyCheck();
    }

    /// <summary>
    /// 监听玩家输入并计算移动方向
    /// </summary>
    private void PlayerKeyCheck()
    {
        // 获取玩家的水平和垂直轴输入（如键盘方向键或 WASD）
        moveDir.x = Input.GetAxisRaw("Horizontal");
        moveDir.y = Input.GetAxisRaw("Vertical");

        // 标准化方向向量，防止斜向移动速度过快
        moveDir = moveDir.normalized;
    }

    /// <summary>
    /// 根据输入方向施加力来移动玩家
    /// </summary>
    private void PlayerMove()
    {
        // 如果有输入方向，施加力
        if (moveDir != Vector2.zero)
        {
            // 施加力，强度由 `force` 控制
            rb.AddForce(moveDir * force);
        }
        else
        {
            // 如果没有输入，逐渐减速
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, Time.deltaTime * drag);
        }

        // 限制最大速度
        if (rb.velocity.magnitude > speed)
        {
            rb.velocity = rb.velocity.normalized * speed; // 保持最大速度
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("NPC"))
        {
            // 缓存敌人和其颜色类型
            tempEnemy = collision.gameObject.GetComponent<Enemy>();
            bubbleColorType = tempEnemy.bubbleColorType;

            Debug.Log(bubbleColorType);

            // 处理不同颜色类型的碰撞
            switch (bubbleColorType)
            {
                case BubbleColorType.Red:
                case BubbleColorType.Green:
                case BubbleColorType.Blue:
                case BubbleColorType.Yellow:
                    tempEnemy.ChangeScene();
                    break;

                case BubbleColorType.Purple:
                    // 紫色气泡，不做任何处理
                    break;

                case BubbleColorType.Transparent:
                    // 透明气泡，可选择不处理
                    break;

                case BubbleColorType.stationary:
                    // 停滞气泡，造成伤害
                    tempEnemy.TakeDamage(this);
                    break;

                case BubbleColorType.bouncing:
                    // 弹跳气泡，反向施加力
                    rb.AddForce(-moveDir * force);
                    break;

                case BubbleColorType.chased:
                    // 被追逐气泡，不做处理
                    break;
            }
        }
    }

    /// <summary>
    /// 玩家受到伤害的处理方法
    /// </summary>
    public void TakeDamage(int damage)
    {
        HP -= damage;
        Debug.Log("玩家受到伤害，剩余生命值：" + HP);
        if (HP <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// 玩家死亡的处理
    /// </summary>
    private void Die()
    {
        Debug.Log("玩家死亡！");
        // 重新加载最开始的场景（假设最开始的场景是索引为 0 的场景）
        SceneManager.LoadScene(0); // 重新加载场景索引为 0 的场景
    }
}
