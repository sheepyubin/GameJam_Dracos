using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirPrf : MonoBehaviour
{
    public float Speed = 10f;
    private void Start()
    {
        Destroy(gameObject, 2f);            //�������κ��� 2�� �� ����
    }

    private void Update()
    {
        transform.Translate(Vector2.right * (Speed * Time.deltaTime), Space.Self);
    }
}