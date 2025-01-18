using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 变量
    public float speed = 5f;               // 最大移动速度
    public float force = 10f;              // 施加的力，控制加速的快慢
    public float drag = 3f;                // 物体的阻力，用于模拟减速

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
        // 如果有输入方向，施加力
        if (moveDir != Vector2.zero)
        {
            // 施加力，强度由 `force` 控制
            rb.AddForce(moveDir * force);
        }

        // 限制最大速度
        if (rb.velocity.magnitude > speed)
        {
            rb.velocity = rb.velocity.normalized * speed;
        }
    }
}
