using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Mang_HP : MonoBehaviour
{
    // Start is called before the first frame update
    public Character playerCharacter;
    protected float curHealth; //* ���� ü��
    public float maxHealth = 10; //* �ִ� ü��
    public int XP=100;
    public Slider HpBarSlider;
    public void SetHp(float amount) //*Hp����
    {
        maxHealth = amount;

    }
    void Start()
    {
        curHealth = maxHealth;
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (HpBarSlider != null)
            HpBarSlider.value = curHealth / maxHealth;
    }
    public void Damage(float damage) //* ������ �޴� �Լ�
    {
        //playerCharacter = GameObject.FindWithTag("Player").GetComponent<Character>();
        if (maxHealth == 0 || curHealth <= 0) //* �̹� ü�� 0���ϸ� �н�
            return;
        curHealth -= damage;
        if (curHealth <= 0)
        {
            gameObject.SetActive(false);
        }

    }
}
