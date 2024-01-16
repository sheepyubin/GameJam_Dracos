using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Skill : MonoBehaviour
{
    public string SkillName;        //�̸�
    public float DelayTime;    //��Ÿ��
    public float NowDelay = 0;      //������Ÿ��
    public float AtkField;     //���ݹ���
    public int AtkCode;           //�����ڵ�(FSMȣ��)

    public void SetSkill(string _SkillName, float _DelayTime,
        float _AtkField, int _AtkCode)
    {
        SkillName = _SkillName;
        DelayTime = _DelayTime;
        AtkField = _AtkField;
        AtkCode = _AtkCode;
        NowDelay = 0;
    }
}

public class Enemy : MonoBehaviour
{
    public string enemyName;
    public int maxHp;
    public int nowHp;
    public bool isAttaking = false;
    public float moveSpeed;
    public float fieldOfVision;

    public Skill[] SkillList;
    private void SetDarkDragonSkill() //��ų����Ʈ �ʱ�ȭ
    {
        SkillList = new Skill[6];

        for (int i = 0; i < SkillList.Length; i++)
            SkillList[i] = new Skill();

        SkillList[0].SetSkill("������Ÿ", 1.5f, 2f, 1);
        SkillList[1].SetSkill("������Ÿ", 1.5f, 1f, 2);
        SkillList[2].SetSkill("������", 13f, 5f, 3);
        SkillList[3].SetSkill("��������", 13f, 10f, 4);
        SkillList[4].SetSkill("����ȭ����", 12f, 10f, 5);
        SkillList[5].SetSkill("��ä��ȭ����", 7f, 10f, 6);
    }

    private void SetEnemyStatus(string _enemyName, int _maxHp,
        float _moveSpeed, float _fieldOfVision)
    {
        enemyName = _enemyName;
        maxHp = _maxHp;
        nowHp = _maxHp;
        moveSpeed = _moveSpeed;
        fieldOfVision = _fieldOfVision;
    }

    public Image nowHpbar;
    public GameObject prfHpBar;
    public GameObject canvas;

    RectTransform hpBar;
    public float height = 1.7f;

    public MoveScript Player;
    

    void Start()
    {
        hpBar = Instantiate(prfHpBar, canvas.transform).GetComponent<RectTransform>();
        SetEnemyStatus("DarkDragon", 1000, 3f, 500f);
        nowHpbar = hpBar.transform.GetChild(0).GetComponent<Image>();
        SetDarkDragonSkill();
    }

    void Update()
    {
        Vector3 _hpBarPos = Camera.main.WorldToScreenPoint
            (new Vector3(transform.position.x, transform.position.y + height, 0));
        hpBar.position = _hpBarPos;
        nowHpbar.fillAmount = (float)nowHp / (float)maxHp;
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (Player.attacked)
            {
                nowHp -= Player.atkDmg;
                Player.attacked = false;

                if (nowHp <= 0) Die(); //���ó��
            }
        }
    }

    void Die() //���ó��
    {
        GetComponent<EnemyAI>().enabled = false;    // ���� ��Ȱ��ȭ
        GetComponent<Collider2D>().enabled = false; // �浹ü ��Ȱ��ȭ
        Destroy(GetComponent<Rigidbody2D>());       // �߷� ��Ȱ��ȭ
        Destroy(gameObject, 3);                     // 3���� ����
        Destroy(hpBar.gameObject, 3);               // 3���� ü�¹� ����
    }
}