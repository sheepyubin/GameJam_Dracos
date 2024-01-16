using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public enum DarkDragonState
{
    Idle = 0,       //���
    TailAttack,     //������Ÿ
    ClawsAttack,    //������Ÿ
    FireCircle,     //������
    EattingMob,     //���� �������
    CircleShoot,    //����ȭ����
    FanShoot        //��ä��ȭ����
}
public class DarkDragon : MonoBehaviour
{
    public GameObject prfFire;
    public Transform target;
    Vector3 whereToAtk;
    Vector3 playerPos;
    Enemy enemy;

    private DarkDragonState dragonState;

    // Start is called before the first frame update
    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        ChangeState(DarkDragonState.Idle);
    }

    public void SetState(int num)
    {
        switch(num)
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

    // Update is called once per frame
    void Update()
    {
    }

    private void ChangeState(DarkDragonState newState)
    {
        StopCoroutine(dragonState.ToString());
        dragonState = newState;
        StartCoroutine(dragonState.ToString());
    }

    private IEnumerator Idle()
    {
        Debug.Log("���������");

        while (true)
        {
            yield return null;
        }
    }
    private IEnumerator TailAttack()
    {
        int i = 0;
        Debug.Log("������Ÿ");

        while (i < 0)
        {
            Debug.Log("�ؾ�");
        }

        enemy.isAttaking = false;

        ChangeState(DarkDragonState.Idle);
        yield return null;
    }

    private IEnumerator ClawsAttack()
    {
        int i = 0;
        Debug.Log("������Ÿ");

        while (i < 0)
        {
            Debug.Log("��");
        }

        enemy.isAttaking = false;

        yield return null;
        ChangeState(DarkDragonState.Idle);
    }

    private IEnumerator FireCircle()
    {
        int i = 0;
        Debug.Log("ȭ��");

        while (i < 3)
        {
            i++;
            Debug.Log("�ѽöѽ�");
            yield return new WaitForSeconds(1);
        }
        enemy.isAttaking = false;
        ChangeState(DarkDragonState.Idle);
    }

    private IEnumerator EattingMob()
    {
        int i = 0;
        Debug.Log("���̲������");

        while (i < 3)
        {
            i++;
            Debug.Log("��;ƾ�");
            yield return new WaitForSeconds(1);
        }
        enemy.isAttaking = false;
        ChangeState(DarkDragonState.Idle);
    }

    private IEnumerator CircleShoot()
    {
        int i = 0;
        Debug.Log("����ȭ����");

        while (i < 3)
        {
            i++;
            Circleshoot();
            Debug.Log("�䵵����");
            yield return new WaitForSeconds(1);
        }
        enemy.isAttaking = false;
        ChangeState(DarkDragonState.Idle);
    }

    private IEnumerator FanShoot()
    {
        int i = 0;
        Debug.Log("��ä��ȭ����");

        while (i<3)
        {
            i++;
            Fanshoot();
            Debug.Log("��������");
            yield return new WaitForSeconds(1);
        }
        enemy.isAttaking = false;
        ChangeState(DarkDragonState.Idle);
    }

    public Transform Target;

    private void Circleshoot()
    {
        //360�� �ݺ�
        for (int i = 0; i < 360; i += 13)
        {
            GameObject temp = Instantiate(prfFire);
            Destroy(temp, 2f);
            temp.transform.position = transform.position;
            temp.transform.rotation = Quaternion.Euler(0, 0, i);
        }
    }

    private void Fanshoot()
    {
        for (int i = 0; i < 60; i += 6)
        {
            GameObject temp = Instantiate(prfFire);
            Destroy(temp, 2f);
            temp.transform.position = transform.position;
            temp.transform.rotation = Quaternion.Euler(0, 0, i);
        }
    }

}
