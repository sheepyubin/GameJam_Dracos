using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GroundDragonMove : MonoBehaviour
{
    public Transform Player;
    public float speed = 1;
    public double stoppingDistance = 3;
    public GroundDragonAttack groundDragonAttack;
    void Start()
    {
        GetComponent<GroundDragonAttack>();
    }
    void Update()
    {
        if (Player != null)
        {
            // �÷��̾� �������� ȸ��
            Vector2 newPos = Player.transform.position - transform.position;
            float rotZ = Mathf.Atan2(newPos.y, newPos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rotZ);

            // �÷��̾���� �Ÿ� ���
            float distanceToPlayer = Vector3.Distance(transform.position, Player.position);

            // ���� �Ÿ����� �ָ� �ְ� ���� ���� �ƴ� ��쿡�� �̵�
            if (distanceToPlayer > stoppingDistance && !groundDragonAttack.isAttacking)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
        }
        else
        {
            Debug.LogWarning("Player reference is null. Assign a player to the GroundDragonMove script in the Inspector.");
        }
    }
}

