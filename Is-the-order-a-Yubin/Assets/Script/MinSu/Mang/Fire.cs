using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public int damage = 5;

    Monster_HP M_HP;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
    private void Awake()
    {
        M_HP = FindObjectOfType<Monster_HP>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ãæµ¹");
        M_HP.Damage(damage);
    }
}
