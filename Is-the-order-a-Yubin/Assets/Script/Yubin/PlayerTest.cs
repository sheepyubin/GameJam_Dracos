using UnityEngine;

public class PlayerTest: MonoBehaviour
{
    public float speed = 5f; // �÷��̾� �̵� �ӵ�

    void Update()
    {
        // Ű �Է��� �����Ͽ� �̵�
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // �̵� ���� ���
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);
        movement.Normalize(); // �밢�� �̵� �ӵ� ����

        // �÷��̾� �̵�
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
