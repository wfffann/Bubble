
using UnityEngine;
using UnityEngine.SceneManagement;  // ���� SceneManager �����ռ�

public class PlayerController : MonoBehaviour
{
    // ����
    public float speed = 5f;               // ����ƶ��ٶ�
    public float force = 10f;              // ʩ�ӵ��������Ƽ��ٵĿ���
    public float drag = 3f;                // ���������������ģ�����

    public int HP = 100;                   // ��ҳ�ʼ����ֵ

    private Vector2 moveDir;               // �ƶ�����

    // ���
    private Rigidbody2D rb;

    private Enemy tempEnemy;               // ��ײ���ĵ���
    private BubbleColorType bubbleColorType; // ��ײ���˵���ɫ����

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
        else
        {
            // ���û�����룬�𽥼���
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, Time.deltaTime * drag);
        }

        // ��������ٶ�
        if (rb.velocity.magnitude > speed)
        {
            rb.velocity = rb.velocity.normalized * speed; // ��������ٶ�
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("NPC"))
        {
            // ������˺�����ɫ����
            tempEnemy = collision.gameObject.GetComponent<Enemy>();
            bubbleColorType = tempEnemy.bubbleColorType;

            Debug.Log(bubbleColorType);

            // ����ͬ��ɫ���͵���ײ
            switch (bubbleColorType)
            {
                case BubbleColorType.Red:
                case BubbleColorType.Green:
                case BubbleColorType.Blue:
                case BubbleColorType.Yellow:
                    tempEnemy.ChangeScene();
                    break;

                case BubbleColorType.Purple:
                    // ��ɫ���ݣ������κδ���
                    break;

                case BubbleColorType.Transparent:
                    // ͸�����ݣ���ѡ�񲻴���
                    break;

                case BubbleColorType.stationary:
                    // ͣ�����ݣ�����˺�
                    tempEnemy.TakeDamage(this);
                    break;

                case BubbleColorType.bouncing:
                    // �������ݣ�����ʩ����
                    rb.AddForce(-moveDir * force);
                    break;

                case BubbleColorType.chased:
                    // ��׷�����ݣ���������
                    break;
            }
        }
    }

    /// <summary>
    /// ����ܵ��˺��Ĵ�����
    /// </summary>
    public void TakeDamage(int damage)
    {
        HP -= damage;
        Debug.Log("����ܵ��˺���ʣ������ֵ��" + HP);
        if (HP <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// ��������Ĵ���
    /// </summary>
    private void Die()
    {
        Debug.Log("���������");
        // ���¼����ʼ�ĳ����������ʼ�ĳ���������Ϊ 0 �ĳ�����
        SceneManager.LoadScene(0); // ���¼��س�������Ϊ 0 �ĳ���
    }
}
