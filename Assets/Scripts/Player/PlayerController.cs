using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //变量
    public float force;
    private Vector2 moveDir;
    public float speed;

    //组件
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //移动
        PlayerMove();
    }

    private void Update()
    {
        //按键检测
        PlayerKeyCheck();
    }

    /// <summary>
    /// 玩家的输入监测
    /// </summary>
    public void PlayerKeyCheck()
    {
        moveDir.x = Input.GetAxisRaw("Horizontal");
        moveDir.y = Input.GetAxisRaw("Vertical");

        moveDir = moveDir.normalized;
        Debug.Log(moveDir);
    }

    /// <summary>
    /// 玩家移动
    /// </summary>
    public void PlayerMove()
    {
        rb.velocity = moveDir * speed;
    }
}
