using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GroundDragonAttack : MonoBehaviour
{
    EffectPlay effectPlay; //ȿ������

    public GameObject stonePrefab; // �� Prefab
    public GameObject terrainPrefab; // ���� Prefab

    public GameObject dustRangePrefab; // ���� ���� Prefab
    public GameObject quakeRangePrefab; // ��ų ���� Prefab
    public GameObject sPoint;

    public QuackAttack quackAttack;


    public bool isAttacking = false; // ���� ������ ���θ� ��Ÿ���� ����
    public float nomalAttackCooldownTime = 2f; // ��Ÿ�� ���� (��)

    private float cooldownTimer = 0f; // ��Ÿ�� Ÿ�̸�
    private int skill = 0;
    void Start()
    {
        effectPlay = GameObject.Find("OptionCanvas").GetComponent<EffectPlay>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }
    private void Attack()
    {

        cooldownTimer += Time.deltaTime;
        if (cooldownTimer >= nomalAttackCooldownTime)
        {
            switch (skill)
            {
                case 3: Terrain(); break;
                case 7: ShowQuakeRange(); ShowDustSRange(); break;
                default: StoneAttack(); break;
            }
            cooldownTimer = 0f; // Ÿ�̸� �ʱ�ȭ
        }
        else
            isAttacking = false;

    }
    private void StoneAttack() // �ٷ� ����
    {
        isAttacking = true;
        Instantiate(stonePrefab, sPoint.transform.position, sPoint.transform.rotation);
        skill++;
        effectPlay.enemyAttack();
    }
    private void Terrain() // �ٷ� ����
    {
        isAttacking = true;
        for (int i = 0; i < 3; i++)
            Instantiate(terrainPrefab, transform.position, transform.rotation);
        skill++;
        effectPlay.enemyAttack();
    }
    private void ShowDustSRange() // ������ ������ ��ų ���
    {
        isAttacking = true;
        // ��ȯ�� ���� Prefeb�� ��ų�� �����
        Instantiate(dustRangePrefab, transform.position, Quaternion.identity);
        effectPlay.enemySkill();
        skill = 0;

    }
    private void ShowQuakeRange() // ������ ������ ��ų ���
    {
        isAttacking = true;
        // ��ȯ�� ���� Prefeb�� ��ų�� �����
        Instantiate(quakeRangePrefab, transform.position, Quaternion.identity);
        effectPlay.enemySkill();
        skill = 0;
    }

}
