using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //����
    public float force;
    private Vector2 moveDir;
    public float speed;

    //���
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //�ƶ�
        PlayerMove();
    }

    private void Update()
    {
        //�������
        PlayerKeyCheck();
    }

    /// <summary>
    /// ��ҵ�������
    /// </summary>
    public void PlayerKeyCheck()
    {
        moveDir.x = Input.GetAxisRaw("Horizontal");
        moveDir.y = Input.GetAxisRaw("Vertical");

        moveDir = moveDir.normalized;
        Debug.Log(moveDir);
    }

    /// <summary>
    /// ����ƶ�
    /// </summary>
    public void PlayerMove()
    {
        rb.velocity = moveDir * speed;
    }
}
