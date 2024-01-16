using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    Enemy enemy;

    DarkDragon dd;

    void Start()
    {
        dd = GetComponent<DarkDragon>();
        enemy = GetComponent<Enemy>();
    }

    void DecreaseDelay() //��罺ų �����̰���
    {
        for (int i = 0; i < enemy.SkillList.Length; i++)
        {
            enemy.SkillList[i].NowDelay -= Time.deltaTime;
            if (enemy.SkillList[i].NowDelay < 0)
                enemy.SkillList[i].NowDelay = 0;
        }
    }

    void Update()
    {
        Invoke("DecreaseDelay", 1f);
        // Ÿ�ٰ� �ڽ��� �Ÿ��� Ȯ��
        float distance = Vector3.Distance(transform.position, target.position);

        // �þ� �����ȿ� ���� ��
        if (distance <= enemy.fieldOfVision)
        {
            FaceTarget(); // Ÿ�� �ٶ󺸱�
            Debug.Log(enemy.isAttaking);
            if (enemy.isAttaking)
                MoveToTarget();
            else
            {
                List<Skill> skill= new List<Skill>();

                for (int i = 0; i < enemy.SkillList.Length; i++)
                {
                    if (enemy.SkillList[i].NowDelay == 0)
                        if (distance <= enemy.SkillList[i].AtkField)
                            skill.Add(enemy.SkillList[i]);
                }

                if(skill.Count > 0)
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

    void MoveToTarget()
    {
        Vector3 directionToPlayer = target.position - transform.position;
        float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        transform.Translate(Vector3.right * enemy.moveSpeed * Time.deltaTime);
    }

    void FaceTarget()
    {
        if (target.position.x - transform.position.x < 0) // Ÿ���� ���ʿ� ���� ��
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else // Ÿ���� �����ʿ� ���� ��
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void AttackTarget(Skill nowSkill)
    {
        enemy.isAttaking = true;
        dd.SetState(nowSkill.AtkCode);
        nowSkill.NowDelay = nowSkill.DelayTime; //������ ����
    }
}
