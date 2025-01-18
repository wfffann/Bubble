using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // ����
    public float speed = 5f;               // ����ƶ��ٶ�
    public float force = 10f;              // ʩ�ӵ��������Ƽ��ٵĿ���
    public float drag = 3f;                // ���������������ģ�����

    private Vector2 moveDir;               // �ƶ�����

    // ���
    private Rigidbody2D rb;

    private void Start()
    {
        // ��ȡ Rigidbody2D ���
        rb = GetComponent<Rigidbody2D>();

        // ���ó�ʼ������ȷ�����ֹͣʱ������Ȼ�ļ���Ч����
        rb.drag = drag;
    }

    private void FixedUpdate()
    {
        // ������������ƶ�
        PlayerMove();
    }

    private void Update()
    {
        // �����������
        PlayerKeyCheck();
    }

    /// <summary>
    /// ����������벢�����ƶ�����
    /// </summary>
    private void PlayerKeyCheck()
    {
        // ��ȡ��ҵ�ˮƽ�ʹ�ֱ�����루����̷������ WASD��
        moveDir.x = Input.GetAxisRaw("Horizontal");
        moveDir.y = Input.GetAxisRaw("Vertical");

        // ��׼��������������ֹб���ƶ��ٶȹ���
        moveDir = moveDir.normalized;
    }

    /// <summary>
    /// �������뷽��ʩ�������ƶ����
    /// </summary>
    private void PlayerMove()
    {
        // ��������뷽��ʩ����
        if (moveDir != Vector2.zero)
        {
            // ʩ������ǿ���� `force` ����
            rb.AddForce(moveDir * force);
        }

        // ��������ٶ�
        if (rb.velocity.magnitude > speed)
        {
            rb.velocity = rb.velocity.normalized * speed;
        }
    }
}
