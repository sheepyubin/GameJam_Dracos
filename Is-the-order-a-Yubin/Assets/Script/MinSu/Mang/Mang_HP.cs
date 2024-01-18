using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mang_HP : MonoBehaviour
{
    // Start is called before the first frame update
    public Character playerCharacter;
    protected float curHealth; //* ���� ü��
    public float maxHealth = 10; //* �ִ� ü��
    public int XP=100;
    HP_Bar bar;
    public void SetHp(float amount) //*Hp����
    {
        maxHealth = amount;

    }
    void Start()
    {
        curHealth = maxHealth;
        bar = FindObjectOfType<HP_Bar>();
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void Damage(float damage) //* ������ �޴� �Լ�
    {
        //playerCharacter = GameObject.FindWithTag("Player").GetComponent<Character>();
        if (maxHealth == 0 || curHealth <= 0) //* �̹� ü�� 0���ϸ� �н�
            return;
        curHealth -= damage;
        Debug.Log("�������� �޾ҽ��ϴ�.");
        if (curHealth <= 0)
        {
            gameObject.SetActive(false);
            Debug.Log("��Ȱ��ȭ ����");

            if (playerCharacter != null)
            {
                playerCharacter.GainExperience(XP);
            }
            else
            {
                Debug.Log("xp������ ����...");
            }
        }

    }
}
