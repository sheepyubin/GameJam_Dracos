using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GroundDragonAttack : MonoBehaviour
{
    public GameObject stonePrefab; // �߻�ü �̹���
    public GameObject dustPrefab; // �߻�ü �̹���
    public bool isAttacking = false; // ���� ������ ���θ� ��Ÿ���� ����
    public float nomalAttackCooldownTime = 2f; // ��Ÿ�� ���� (��)

    private float cooldownTimer = 0f; // ��Ÿ�� Ÿ�̸�
    public int skill = 0;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        cooldownTimer += Time.deltaTime;

        if (cooldownTimer >= nomalAttackCooldownTime)
        {
            skill++;
            if (skill > 3)
                DustAttack();
            else
                StoneAttack();


            isAttacking = false;
            cooldownTimer = 0f; // Ÿ�̸� �ʱ�ȭ
        }
        
    }
    void StoneAttack()
    {
        isAttacking = true;
            Instantiate(stonePrefab, transform.position, transform.rotation);
    }
    void DustAttack()
    {
        isAttacking = true;
        for (int i = 0; i < 20;i++)
            Instantiate(dustPrefab, transform.position, transform.rotation);
        skill = 0;
    }
    
}
