using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

// �巡���� ���¸� �����ϴ� ������
public enum DarkDragonState
{
    Idle = 0,       // ���
    TailAttack,     // ���� ��Ÿ
    ClawsAttack,    // ���� ��Ÿ
    FireCircle,     // ���� ��
    EattingMob,     // ���� �������
    CircleShoot,    // ���� ȭ����
    FanShoot        // ��ä�� ȭ����
}

public class DarkDragon : MonoBehaviour
{
    // ȭ���� ������ �� ��ǥ ��ġ
    public GameObject prfFire;
    public Transform target;

    // �� ĳ���� �� ���� ������� ���� ���� ����
    Enemy enemy;
    GameObject eatfield;

    Skill[] SkillList;

    // ���� �巡���� ����
    private DarkDragonState dragonState;

    // ���� �� ȣ��Ǵ� �Լ�
    private void Awake()
    {
        // ���� ������� ���� �ʱ�ȭ
        eatfield = transform.GetChild(0).gameObject;
        eatfield.SetActive(false);

        // �� ĳ���� �� �ʱ� ���� ����
        enemy = GetComponent<Enemy>();
        SkillList = enemy.SkillList;
        ChangeState(DarkDragonState.Idle);
    }

    // ���¸� �����ϴ� �Լ�
    public void SetState(int num)
    {
        switch (num)
        {
            case 0: ChangeState(DarkDragonState.Idle); break;
            case 1: ChangeState(DarkDragonState.TailAttack); break;
            case 2: ChangeState(DarkDragonState.ClawsAttack); break;
            case 3: ChangeState(DarkDragonState.FireCircle); break;
            case 4: ChangeState(DarkDragonState.EattingMob); break;
            case 5: ChangeState(DarkDragonState.CircleShoot); break;
            case 6: ChangeState(DarkDragonState.FanShoot); break;
            default: break;
        }
    }

    // ���� ���¿� ���� ������ �����ϴ� �Լ�
    private void ChangeState(DarkDragonState newState)
    {
        // ���� ���� �ڷ�ƾ ����
        StopCoroutine(dragonState.ToString());

        // ���ο� ���·� ���� �� �ش� ���� �ڷ�ƾ ����
        dragonState = newState;
        StartCoroutine(dragonState.ToString());
    }

    // ��� ���¿� ���� �ڷ�ƾ
    private IEnumerator Idle()
    {
        Debug.Log("���������");

        while (true)
        {
            yield return null;
        }
    }

    // ���� ��Ÿ�� ���� �ڷ�ƾ
    private IEnumerator TailAttack()
    {
        int i = 0;
        Debug.Log("������Ÿ");
        //HitPlayer(20);    //�÷��̾� ü�� ���

        enemy.isAttacking = false;

        // ��� ���·� ��ȯ
        ChangeState(DarkDragonState.Idle);
        yield break;
    }

    // ���� ��Ÿ�� ���� �ڷ�ƾ
    private IEnumerator ClawsAttack()
    {
        int i = 0;
        Debug.Log("������Ÿ");
        //HitPlayer(20);    //�÷��̾� ü�� ���

        enemy.isAttacking = false;

        // ��� ���·� ��ȯ
        ChangeState(DarkDragonState.Idle);
        yield break;
    }

    // ���� �ҿ� ���� �ڷ�ƾ
    private IEnumerator FireCircle()
    {
        int i = 0;
        Debug.Log("ȭ��");
        eatfield.gameObject.SetActive(true);

        while (i < 5)
        {
            i++;
            yield return new WaitForSeconds(1);
        }

        eatfield.gameObject.SetActive(false);
        enemy.isAttacking = false;

        // ��� ���·� ��ȯ
        ChangeState(DarkDragonState.Idle);
    }

    // ���� ������⿡ ���� �ڷ�ƾ
    private IEnumerator EattingMob()
    {
        int i = 0;
        while (i < 3)
        {
            i++;
            yield return new WaitForSeconds(1);
        }

        enemy.isAttacking = false;

        // ��� ���·� ��ȯ
        ChangeState(DarkDragonState.Idle);
    }

    // ���� ȭ������ ���� �ڷ�ƾ
    private IEnumerator CircleShoot()
    {
        int i = 0;
        Debug.Log("����ȭ����");

        while (i < 3)
        {
            i++;
            Circleshoot();
            yield return new WaitForSeconds(1);
        }

        enemy.isAttacking = false;

        // ��� ���·� ��ȯ
        ChangeState(DarkDragonState.Idle);
    }

    // ��ä�� ȭ������ ���� �ڷ�ƾ
    private IEnumerator FanShoot()
    {
        int i = 0;
        Debug.Log("��ä��ȭ����");

        while (i < 3)
        {
            i++;
            Fanshoot();
            yield return new WaitForSeconds(1);
        }

        enemy.isAttacking = false;

        // ��� ���·� ��ȯ
        ChangeState(DarkDragonState.Idle);
    }

    // ���� ȭ���� ���� �Լ�
    private void Circleshoot()
    {
        // 360�� �ݺ�
        for (int i = 0; i < 360; i += 13)
        {
            GameObject temp = Instantiate(prfFire);
            Destroy(temp, 2f);
            temp.transform.position = transform.position;
            temp.transform.rotation = Quaternion.Euler(0, 0, i);
        }
    }

    // ��ä�� ȭ���� ���� �Լ�
    private void Fanshoot()
    {
        Vector3 vec = transform.rotation.eulerAngles;
        // 60���� �����ϸ鼭 10�� �ݺ�
        for (int i = 0; i < 60; i += 10)
        {
            GameObject temp = Instantiate(prfFire);
            Destroy(temp, 2f);
            temp.transform.position = transform.position;
            temp.transform.Rotate(new Vector3(vec.x, vec.y, vec.z - 30 + i));
        }
    }

    private void HitPlayer(int i)
    {
        GameObject target = GameObject.Find("Player");
        target.GetComponent<MoveScript>().nowHp -= i;
    }
}
