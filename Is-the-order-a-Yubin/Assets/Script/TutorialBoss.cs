using System.Collections;
using UnityEngine;

public class TutorialBoss : MonoBehaviour
{
    public Transform Player;
    public float speed = 1;
    public float stoppingDistance = 0.3f;
    public GameObject bullet1;

    private bool isAttacking = false;

    void Update()
    {
        if (Player != null)
        {
            Vector3 directionToPlayer = Player.position - transform.position;
            float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            float distanceToPlayer = Vector3.Distance(transform.position, Player.position);

            // Check if the distance is less than or equal to stoppingDistance and isAttacking is false
            if (distanceToPlayer <= stoppingDistance && !isAttacking)
            {
                StartCoroutine(AttackEveryTwoSeconds());
            }

            if (distanceToPlayer > stoppingDistance && !isAttacking)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
        }
        else
        {
            Debug.LogWarning("Player reference is null. Assign a player to the RedDragon_Move script in the Inspector.");
        }
    }

    IEnumerator AttackEveryTwoSeconds()
    {
        isAttacking = true;

        // Use WaitForSecondsRealtime to ensure the time delay is not affected by time scale
        while (true)
        {
            Attack();
            yield return new WaitForSecondsRealtime(2f);
        }
    }

    void Attack()
    {
        if (bullet1 != null)
        {
            // Calculate the direction to shoot the projectile (in the boss's forward direction)
            Vector3 shootDirection = transform.right;

            // Instantiate the projectile in the direction of the boss's forward vector
            Instantiate(bullet1, transform.position, Quaternion.LookRotation(Vector3.forward, shootDirection));
        }
        else
        {
            Debug.LogWarning("Flame Prefab is not assigned. Assign a prefab to the RedDragon_Move script in the Inspector.");
        }
    }

}
