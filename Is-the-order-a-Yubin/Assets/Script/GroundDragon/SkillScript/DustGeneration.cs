using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustGeneration : MonoBehaviour
{
    EffectPlay effectPlay; //ȿ������

    public float speed = 3f;
    public float lifeTime = 1f;
    public float angle = 20f;

    private float attackAngle;

    public Vector2 startSize = new Vector2(0.1f, 0.1f);
    public Vector2 targetSize = new Vector2(0.5f, 0.5f);

    public Color startColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    public Color targetColor = new Color(1.0f, 0.0f, 0.0f, 0.0f);

    public float animationDuration = 2.0f;
    public float fadeDuration = 2.0f;

    private float elapsedTime = 0.0f;
    private Vector2 originalSize;
    private Color originalColor;

    // Start is called before the first frame update
    void Start()
    {
        effectPlay = GameObject.Find("OptionCanvas").GetComponent<EffectPlay>();
        effectPlay.enemyAttack();
        // prefab�� �ð��� �°� �����
        Destroy(gameObject, lifeTime);

        // �߻�ü ������ ���� ����
        attackAngle = Random.Range(-angle, angle);

        // �� �ٲٱ�
        originalColor = startColor;
    }

    // Update is called once per frame
    void Update()
    {
        float z = transform.rotation.eulerAngles.z;
        Vector2 direction = new Vector2(Mathf.Cos(z * Mathf.Deg2Rad + attackAngle), Mathf.Sin(z * Mathf.Deg2Rad + attackAngle));
        GetComponent<Rigidbody2D>().velocity = direction * speed;
        AnimateColor();
        AnimateSize(targetSize);
    }

    void AnimateColor()
    {
        elapsedTime += Time.deltaTime;
        float t = Mathf.Clamp01(elapsedTime / fadeDuration);
        Color newColor = Color.Lerp(originalColor, targetColor, t);
        SetObjectColor(newColor);
    }

    void AnimateSize(Vector2 target)
    {
        elapsedTime += Time.deltaTime;
        SetObjectSize(Vector2.Lerp(originalSize, target, Mathf.Clamp01(elapsedTime / animationDuration)));
    }
    void SetObjectSize(Vector2 newSize) => transform.localScale = newSize;

    void SetObjectColor(Color newColor)
    {
        Renderer renderer = GetComponent<Renderer>();

        if (renderer != null)
        {
            renderer.material.color = newColor;
        }
        else
        {
            Debug.LogWarning("Renderer not found. Make sure the object has a Renderer component.");
        }
    }
}
