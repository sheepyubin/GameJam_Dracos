using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HP_Bar : MonoBehaviour
{
    protected float curHealth; //* ���� ü��
    public Slider HpBarSlider;
    public float maxHealth = 10; //* �ִ� ü��
    float dame=0.01f;
    public void SetHp(float amount) //*Hp����
    {
        maxHealth = amount;
        curHealth = maxHealth;
    }
    void Start()
    {
        curHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //Damage(dame);
    }
    public void CheckHp() //*HP ����
    {
        if (HpBarSlider != null)
            HpBarSlider.value = curHealth / maxHealth;
    }
    public void Damage(float damage) //* ������ �޴� �Լ�
    {
        if (maxHealth == 0 || curHealth <= 0) //* �̹� ü�� 0���ϸ� �н�
            return;
        curHealth -= damage;
        CheckHp(); //* ü�� ����
        if (curHealth <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

}
