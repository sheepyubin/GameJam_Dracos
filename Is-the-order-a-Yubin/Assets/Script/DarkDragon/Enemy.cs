using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.U2D;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    public string SkillName;        // ��ų �̸�
    public float DelayTime;         // ��Ÿ��
    public float NowDelay = 0;      // ���� ��Ÿ��
    public float AtkField;          // ���� ����
    public int AtkCode;             // ���� �ڵ� (FSM ȣ��)

    // ��ų ���� �Լ�
    public void SetSkill(string _SkillName, float _DelayTime, float _AtkField, int _AtkCode)
    {
        SkillName = _SkillName;
        DelayTime = _DelayTime;
        NowDelay = _DelayTime;
        AtkField = _AtkField;
        AtkCode = _AtkCode;
    }
}

public class Enemy : MonoBehaviour
{
    public string enemyName;        // �� �̸�
    public int maxHp;               // �ִ� ü��
    public int nowHp;               // ���� ü��
    public bool isAttacking = false; // ���� ������ ����
    public float moveSpeed;         // �̵� �ӵ�
    public float fieldOfVision;     // �þ� ����

    public GameObject FightImage;
    public GameObject FightButton;
    public bool isFitting = false;  //ü�� �����ϴ��� ����
    public bool isStrengthen= false;  //��ȭ������ ����

    public SpriteRenderer spriteRenderer;
    Sprite[] sprites;
    public GameObject playerObject;

    public Skill[] SkillList;       // ��ų ����Ʈ

    private void StartFit()
    {
        hpBar.SetActive(false);
        isStrengthen = true;
        FightImage.SetActive(true);
        FightButton.SetActive(true);
    }
    public void DoneFit()
    {
        hpBar.SetActive(true);
        isStrengthen = false;
        FightImage.SetActive(false);
        FightButton.SetActive(true);
        isFitting = true;

        Debug.Log("ũ�;ƾ�");
        spriteRenderer.sprite = sprites[0];
    }

    // DarkDragon ��ų �ʱ�ȭ �Լ�
    private void SetDarkDragonSkill()
    {
        SkillList = new Skill[6];

        for (int i = 0; i < SkillList.Length; i++)
            SkillList[i] = new Skill();

        SkillList[0].SetSkill("������Ÿ", 3f, 2f, 1);
        SkillList[1].SetSkill("������Ÿ", 3f, 1f, 2);
        SkillList[2].SetSkill("������", 17.5f, 5f, 3);
        SkillList[3].SetSkill("��������", 17.5f, 10f, 4);
        SkillList[4].SetSkill("����ȭ����", 20f, 10f, 5);
        SkillList[5].SetSkill("��ä��ȭ����", 12.5f, 15f, 6);
    }

    // �� ���� �ʱ�ȭ �Լ�
    private void SetEnemyStatus(string _enemyName, int _maxHp, float _moveSpeed, float _fieldOfVision)
    {
        enemyName = _enemyName;
        maxHp = _maxHp;
        nowHp = _maxHp;
        moveSpeed = _moveSpeed;
        fieldOfVision = _fieldOfVision;
    }

    public Image nowHpbar;          // ���� ü�¹�
    public GameObject prfHpBar;     // ü�¹� ������
    public GameObject canvas;       // ĵ����

    GameObject hpBar;               // ü�¹� RectTransform
    public float height = 1.7f;     // ü�¹� ����

    public MoveScript Player;       // �÷��̾� ��ü

    // ���� �� ȣ��Ǵ� �Լ�
    void Start()
    {
        Invoke("StartFit", 2f);
        // ü�¹� ���� �� �ʱ�ȭ
        hpBar = Instantiate(prfHpBar, canvas.transform);
        SetEnemyStatus("DarkDragon", 1000, 3f, 500f);
        nowHpbar = hpBar.transform.GetChild(0).GetComponent<Image>();
        SetDarkDragonSkill();
        sprites = Resources.LoadAll<Sprite>("Resources/Charactor/BuleDragon");
        Debug.Log(sprites[0]);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // �����Ӹ��� ȣ��Ǵ� �Լ�
    void Update()
    {
        // ü�¹� ��ġ ������Ʈ
        Vector3 _hpBarPos = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + height, 0));
        hpBar.GetComponent<RectTransform>().position = _hpBarPos;
        nowHpbar.fillAmount = (float)nowHp / (float)maxHp;
    }

    // �÷��̾���� �浹 �� ȣ��Ǵ� �Լ�
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(isFitting)
        {
            if (col.CompareTag("Player"))
            {
                // �÷��̾� ���� �� ü�� ���� �� ��� üũ
                if (Player.attacked)
                {
                    nowHp -= Player.atkDmg;
                    Player.attacked = false;

                    if (nowHp <= 0) Die(); // ��� ó��
                }
            }
        }
    }

    // �� ��� ó�� �Լ�
    void Die()
    {
        GetComponent<EnemyAI>().enabled = false;    // ���� ��Ȱ��ȭ
        GetComponent<Collider2D>().enabled = false; // �浹ü ��Ȱ��ȭ
        Destroy(GetComponent<Rigidbody2D>());       // �߷� ��Ȱ��ȭ
        Destroy(gameObject, 3);                     // 3�� �� ����
        Destroy(hpBar.gameObject, 3);               // 3�� �� ü�¹� ����
    }
}
