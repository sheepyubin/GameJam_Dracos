using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ��Ģ
[CreateAssetMenu(menuName = "Boids/Behavior/SteeredCohesion")]
public class SteeredCohesionBehavior : FilteredBoidsBehavior
{
    // ���� �̵� ����
    Vector2 currentVelocity;
    public float agentSmoothTime = 0.5f;

    public override Vector2 CalculateMove(BoidsAgent agent, List<Transform> context, Boids boid)
    {
        // ��ó�� ��ü�� ���ٸ� �������� ����
        if (context.Count == 0)
        {
            return Vector2.zero;
        }

        // �̵� ����
        Vector2 cohesionMove = Vector2.zero;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);

        // �ֺ��� �ִ� ��ü���� ��ġ�� ����
        foreach (Transform i in filteredContext)
        {
            cohesionMove += (Vector2)i.position;
        }

        // �ֺ� ��ü���� ��� ��ġ
        cohesionMove /= context.Count;

        // ��� ��ġ�� �̵�
        cohesionMove -= (Vector2)agent.transform.position;

        // �ε巯�� �̵��� �����Ͽ� ���� �̵� ������ ���ο� �̵� �������� ����
        cohesionMove = Vector2.SmoothDamp(agent.transform.up, cohesionMove, ref currentVelocity, agentSmoothTime);

        // �̵� ���� ��ȯ
        return cohesionMove;
    }
}
