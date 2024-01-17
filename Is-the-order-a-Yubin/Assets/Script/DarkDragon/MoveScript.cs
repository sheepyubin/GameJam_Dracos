using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveScript : MonoBehaviour
{
    // �̵� �ӵ�
    public float speed = 20;

    // ������ٵ�� �̵� ����
    Rigidbody rigidbody;
    Vector3 movement;

    // ü�� �� ���� ���� ����
    public int maxHp;
    public int nowHp;
    public int atkDmg;
    public float atkSpeed = 1;
    public bool attacked = false;
    public Image nowHpbar;

    // �ǰ� ���� Ÿ�̸�
    float timer;

    // �浹 �߻� �� ȣ��Ǵ� �Լ�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // "fire" �±��� ������Ʈ�� �浹 ��
        if (collision.tag == "fire")
        {
            nowHp -= 5;
            Destroy(collision.gameObject);
        }
    }

    // �浹 ���� �� ȣ��Ǵ� �Լ�
    private void OnTriggerStay2D(Collider2D collision)
    {
        timer += Time.deltaTime;
        // 0.25�ʸ��� "filed" �±��� ������Ʈ�� �浹 �� ü�� ����
        if (timer > 0.25f)
        {
            if (collision.tag == "filed")
                nowHp -= 1;
            timer = 0;
        }
    }

    // ���� �� ȣ��Ǵ� �Լ�
    void Start()
    {
        // �ʱⰪ ����
        maxHp = 50;
        nowHp = 50;
        atkDmg = 30;
        rigidbody = GetComponent<Rigidbody>();
    }

    // �����Ӹ��� ȣ��Ǵ� �Լ�
    void Update()
    {
        // ���� ü�¹� ������Ʈ
        nowHpbar.fillAmount = (float)nowHp / (float)maxHp;

        // Ű���� �Է¿� ���� �̵� ó��
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = transform.position + transform.up * Time.deltaTime * speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position = transform.position - transform.up * Time.deltaTime * speed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + transform.right * Time.deltaTime * speed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position - transform.right * Time.deltaTime * speed;
        }
        // �����̽��� �Է� �� ���� �÷��� ����
        else if (Input.GetKey(KeyCode.Space))
        {
            attacked = true;
        }
    }
}
