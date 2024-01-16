using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Boids/Behavior/Alignment")]
// ���� ��Ģ
public class AlignmentBehavior : FilteredBoidsBehavior
{
    public override Vector2 CalculateMove(BoidsAgent agent, List<Transform> context, Boids boid)
    {
        // �ֺ��� ��ü�� ������ �״�� �̵���
        if (context.Count == 0)
        {
            return agent.transform.up;
        }

        // �̵� ����
        Vector2 alignmentMove = Vector2.zero;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);

        // �ֺ��� �ִ� ��ü���� ��ġ�� ����
        foreach (Transform i in filteredContext)
        {
            alignmentMove += (Vector2)i.transform.up;
        }

        // �ֺ� ��ü���� ��� ���� ���
        alignmentMove /= context.Count;

        // �̵� ���� ��ȯ
        return alignmentMove;
    }
}
