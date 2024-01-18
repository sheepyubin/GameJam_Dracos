using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public int damage = 5;
    public int curDamage=0;

    Monster_HP M_HP;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
    private void Awake()
    {
        M_HP = FindObjectOfType<Monster_HP>();
        curDamage = damage;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        damage = curDamage;
    }
    public void damageUpdate(int damage)
    {
        curDamage += damage; 
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("데미지"+damage);
        M_HP.Damage(damage);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("데미지" + damage);
        M_HP.Damage(damage);
    }
}
