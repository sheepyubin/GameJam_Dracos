using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;
    public int PlayerHP = 1000;

    // �߰�: ������ �������� Inspector���� ����
    public GameObject prefabToDetect;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * speed * Time.deltaTime;
        transform.Translate(movement);
    }

    // �߰�: �浹 ����
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == prefabToDetect)
        {
            // Ư�� �����հ� �浹���� �� ������ �ڵ�
            Debug.Log("�����տ� ��ҽ��ϴ�!");

            // �߰�: HP ���� �� ����� ���
            PlayerHP -= 1;
            Debug.Log("�÷��̾� HP: " + PlayerHP);

            // �߰�: HP�� 0���Ϸ� �������� ���� ó��
            if (PlayerHP <= 0f)
            {
                Debug.Log("�÷��̾ ����߽��ϴ�!");
                // ���ϴ� ��� ó���� ���⿡ �߰�
            }
        }
    }
}
