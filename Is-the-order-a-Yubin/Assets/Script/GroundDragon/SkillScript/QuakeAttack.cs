using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuackAttack : MonoBehaviour
{
    EffectPlay effectPlay;
    public GameObject quakePrefab; // �տ� Prefab

    private float skillInterval = 4f; // ��Ÿ�� ���� (��)
    private float skillTimer = 0f; // ��Ÿ�� Ÿ�̸�

    // Start is called before the first frame update
    void Start()
    {
        effectPlay = GameObject.Find("OptionCanvas").GetComponent<EffectPlay>();
    }

    // Update is called once per frame
    void Update()
    {
        skillTimer += Time.deltaTime;

        if (skillTimer >= skillInterval)
        {
            effectPlay.enemyAttack();
            Instantiate(quakePrefab, transform.position, Quaternion.identity);

            Destroy(gameObject);
            skillTimer = 0f; // Ÿ�̸� �ʱ�ȭ
        }
    }
}
