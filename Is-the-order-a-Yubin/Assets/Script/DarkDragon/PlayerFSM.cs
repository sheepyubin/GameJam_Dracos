using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public enum PlayerState
{
    Idle = 0,
    Move,
    Attack
}

public class PlayerFSM : MonoBehaviour
{
    
    private PlayerState playerState;

    private void Awake()
    {
        ChangeState(PlayerState.Idle);
    }

    private void Update()
    {
        if (Input.GetKeyDown("1")) ChangeState(PlayerState.Idle);
        else if (Input.GetKeyDown("2")) ChangeState(PlayerState.Move);
        else if (Input.GetKeyDown("3")) ChangeState(PlayerState.Attack);

        //UpdateState();
    }

    //private void UpdateState()
    //{
    //    switch(playerState)
    //    {
    //        case PlayerState.Idle:
    //            Debug.Log("�����");
    //            break;
    //        case PlayerState.Move:
    //            Debug.Log("�����̴���");
    //            break;
    //        case PlayerState.Attack:
    //            Debug.Log("������");
    //            break;
    //    }
    //}

    private void ChangeState(PlayerState newState)
    {
        StopCoroutine(playerState.ToString());
        playerState = newState;
        StartCoroutine(playerState.ToString());
    }

    private IEnumerator Idle()
    {
        Debug.Log("���������� ����");
        Debug.Log("ü�¸��� ȸ��");

        while(true)
        {
            Debug.Log("�����");
            yield return null;
        }
    }
    private IEnumerator Move()
    {
        Debug.Log("�̵��ӵ� 2");
        while(true)
        {
            Debug.Log("�÷��̾ �ɾ�ϴ�");
            yield return null;
        }
    }
    
    private IEnumerator Attack()
    {
        Debug.Log("���ݽ���");
        while(true)
        {
            Debug.Log("�����ϴ���");
            yield return null;
        }
    }
}
