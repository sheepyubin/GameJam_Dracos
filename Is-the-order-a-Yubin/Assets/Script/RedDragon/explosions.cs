using System.Collections;
using UnityEngine;

public class Explosions : MonoBehaviour
{
    public GameObject explosionPrefab; // Inspector���� �������� �Ҵ��ϼ���.

    private int AtkStyle = 1;

    private Transform playerTransform;

    void Start()
    {
        StartCoroutine(SpawnExplosions());
    }

    IEnumerator SpawnExplosions()
    {
        while (true)
        {
            Debug.Log("SpawnExplosions()");
            yield return new WaitForSeconds(1f);

            AtkStyle = FindObjectOfType<RedDragon_Move>().AtkStyle;
            if (AtkStyle == 2)
            {
                // �÷��̾��� ���� ��ġ�� �����ɴϴ�.
                playerTransform = FindObjectOfType<RedDragon_Move>().Player;

                if (playerTransform != null)
                {
                    Debug.Log("Player Transform is not null.");
                    // �ֺ��� ���� �ִϸ��̼��� �����մϴ�.
                    yield return StartCoroutine(SpawnExplosionsInSquareRegion(3, 3f)); // 3���� ������ �����¿� 10�� �������� �����մϴ�.
                }
                else
                {
                    Debug.LogWarning("Player Transform is null. Make sure the RedDragon_Move script has a valid reference to the player.");
                }
            }
        }
    }

    // �����¿� ���� ������ ������ ����ŭ ���� �ִϸ��̼��� �����ϴ� �޼����Դϴ�.
    IEnumerator SpawnExplosionsInSquareRegion(int count, float regionSize)
    {
        for (int i = 0; i < count; i++)
        {
            // ������ X�� Y �������� ����մϴ�.
            float xOffset = Random.Range(-regionSize, regionSize);
            float yOffset = Random.Range(-regionSize, regionSize);

            // X�� Y �������� �÷��̾��� ��ġ�� �����մϴ�.
            Vector3 spawnPosition = new Vector3(xOffset, yOffset, 0f) + playerTransform.position;

            // ���� �ִϸ��̼��� �����մϴ�.
            GameObject explosion = Instantiate(explosionPrefab, spawnPosition, Quaternion.identity);

            // ���� �ִϸ��̼ǿ� Animator ������Ʈ�� �ִٸ� �ִϸ��̼��� ����մϴ�.
            Animator animator = explosion.GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetTrigger("PlayAnimationTrigger");
            }

            // ��ٸ��ϴ�.
            yield return new WaitForSeconds(1.0f); // �ʿ信 ���� �ð��� �����ϼ���.

            // ������ ���� �ִϸ��̼��� �ı��մϴ�.
            Destroy(explosion);
        }
    }
}
