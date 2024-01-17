using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class EnemyAI : MonoBehaviour
{
    // Ÿ�� �� �� ĳ���� ���� ����
    public Transform target;
    Enemy enemy;
    DarkDragon dd;

    void Start()
    {
        // DarkDragon �� Enemy ������Ʈ ��������
        dd = GetComponent<DarkDragon>();
        enemy = GetComponent<Enemy>();
    }

    // ��ų ������ ���� �Լ�
    void DecreaseDelay()
    {
        // ��� ��ų�� �����̸� ���ҽ�Ŵ
        for (int i = 0; i < enemy.SkillList.Length; i++)
        {
            enemy.SkillList[i].NowDelay -= Time.deltaTime;
            if (enemy.SkillList[i].NowDelay < 0)
                enemy.SkillList[i].NowDelay = 0;
        }
    }

    void Update()
    {
        if (!enemy.isStrengthen)
        {
            // ��ų ������ ���� �Լ� 1�ʸ��� ȣ��
            Invoke("DecreaseDelay", 1f);
            // Ÿ�ٰ��� �Ÿ� ���
            float distance = Vector3.Distance(transform.position, target.position);

            // �þ� ���� �ȿ� ���� ��
            if (distance <= enemy.fieldOfVision)
            {
                FaceTarget(); // Ÿ���� �ٶ󺸱�

                // ���� ���̸� Ÿ���� ���� �̵�
                if (enemy.isAttacking)    
                    MoveToTarget();
                else
                {
                    List<Skill> skill = new List<Skill>();

                    // ��� ������ ��ų�� ã�� ����Ʈ�� �߰�
                    for (int i = 0; i < enemy.SkillList.Length; i++)
                    {
                        if (enemy.SkillList[i].NowDelay == 0)
                            if (distance <= enemy.SkillList[i].AtkField)
                                skill.Add(enemy.SkillList[i]);
                    }

                    // ��� ������ ��ų�� ������ �������� �����Ͽ� Ÿ�� ����
                    if (skill.Count > 0)
                    {
                        int i = Random.Range(0, skill.Count);
                        AttackTarget(skill[i]);
                        skill.Clear();
                    }
                    else
                        MoveToTarget();
                }
            }
        }
    }

    // Ÿ���� ���� �̵��ϴ� �Լ�
    void MoveToTarget()
    {
        Vector3 directionToPlayer = target.position - transform.position;
        float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        transform.Translate(Vector3.right * enemy.moveSpeed * Time.deltaTime);
    }

    // Ÿ���� ���� �ٶ󺸴� �Լ�
    void FaceTarget()
    {
        // Ÿ���� ���ʿ� ������ �������� -1�� �����Ͽ� �¿� ����
        if (target.position.x - transform.position.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else // Ÿ���� �����ʿ� ������ �������� 1�� ����
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    // Ÿ���� �����ϴ� �Լ�
    void AttackTarget(Skill nowSkill)
    {

        //��Ÿ ��ų ������ ������ ���� ���� ó��
        if (nowSkill.AtkCode == 0)
        {
            Skill friendSkill = enemy.SkillList[nowSkill.AtkCode + 1];
            friendSkill.NowDelay = friendSkill.DelayTime;

        }
        if (nowSkill.AtkCode == 1)
        {
            Skill friendSkill = enemy.SkillList[nowSkill.AtkCode - 1];
            friendSkill.NowDelay = friendSkill.DelayTime;
        }
        nowSkill.NowDelay = nowSkill.DelayTime;

        // ���� ���� ���·� �����ϰ� DarkDragon ���� ���� �� ������ ����
        enemy.isAttacking = true;
        dd.SetState(nowSkill.AtkCode);
    }
}
