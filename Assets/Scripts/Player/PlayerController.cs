using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 变量
    public float speed = 5f;               // 移动速度（与力无关，主要用来控制施加的力的大小）
    public float force = 10f;              // 施加的力，控制加速的快慢
    public float drag = 3f;                // 物体的阻力（用于模拟减速）

    private Vector2 moveDir;               // 移动方向

    // 组件
    private Rigidbody2D rb;

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
        // 使用 AddForce 来控制玩家移动
        if (moveDir != Vector2.zero)
        {
            // 施加力，强度由 `force` 控制
            rb.AddForce(moveDir * force);
        }

        // 如果你想限制玩家的最大速度（比如使用最大速度控制玩家的移动），可以加入以下限制：
        // rb.velocity = Vector2.ClampMagnitude(rb.velocity, speed);
    }
}
