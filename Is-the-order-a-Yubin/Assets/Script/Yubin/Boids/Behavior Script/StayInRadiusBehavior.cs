using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Boids/Behavior/Stay In Radius")]
public class StayInRadiusBehavior : BoidsBehavior
{
    // �߽� ��ġ
    public Vector2 center;

    // �ݰ�
    public float radius = 15;

    // Boids ��ü�� �̵��� ���
    public override Vector2 CalculateMove(BoidsAgent agent, List<Transform> context, Boids flock)
    {
        // �߽� ��ġ�� ��ü�� ���� ��ġ ���� �Ÿ� ���� ���
        Vector2 centerOffset = center - (Vector2)agent.transform.position;
        
        // �Ÿ� ���� ���
        float t = centerOffset.magnitude / radius;

        // �Ÿ� ������ 0.9���� ������ ���� ���·� ��ȯ
        if (t < 0.9f)
        {
            return Vector2.zero;
        }

        // �Ÿ� ������ ������ ����Ͽ� �߽� �������� �̵��ϴ� ���� ��ȯ
        return centerOffset * t * t;
    }
}
