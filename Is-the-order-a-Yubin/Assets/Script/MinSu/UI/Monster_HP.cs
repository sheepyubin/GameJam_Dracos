using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_HP : MonoBehaviour
{
    // Start is called before the first frame update
    public Character playerCharacter;
    protected float curHealth; //* 현재 체력
    public float maxHealth = 10; //* 최대 체력
    public int XP=100;
    Boss_HP_Bar bar;
    public void SetHp(float amount) //*Hp설정
    {
        maxHealth = amount;

    }

    void Start()
    {
        curHealth = maxHealth;
        bar = FindObjectOfType<Boss_HP_Bar>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Damage(float damage) //* 데미지 받는 함수
    {
        //playerCharacter = GameObject.FindWithTag("Player").GetComponent<Character>();
        if (maxHealth == 0 || curHealth <= 0) //* 이미 체력 0이하면 패스
            return;
        curHealth -= damage;
        if (curHealth <= 0)
        {
            gameObject.SetActive(false);


            if (playerCharacter != null)
            {
                playerCharacter.GainExperience(XP);
            }
            else
            {
                Debug.Log("xp보내기 실패...");
            }
        }
        bar.Damage(damage);
    }
}
