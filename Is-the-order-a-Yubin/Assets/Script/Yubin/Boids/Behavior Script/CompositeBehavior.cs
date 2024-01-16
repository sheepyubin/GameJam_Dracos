using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Boids/Behavior/Composite")]
// �ൿ ����
public class CompositeBehavior : BoidsBehavior
{
    // �ൿ���� �迭
    public BoidsBehavior[] behaviors;

    // �� �ൿ�� ���� ����ġ �迭
    public float[] weights;

    public override Vector2 CalculateMove(BoidsAgent agent, List<Transform> context, Boids boid)
    {
        // ����ġ �迭�� �ൿ �迭�� ���̰� ��ġ���� ������ ����, �� ���� ��ȯ
        if (weights.Length != behaviors.Length)
        {
            Debug.LogError("����ġ �迭�� �ൿ �迭�� ���̰� �ٸ�" + name, this);
            return Vector2.zero;
        }

        // ���� �̵� ����
        Vector2 move = Vector2.zero;

        // �� �ൿ�� ���� ����ġ�� ���Ͽ� �κ� �̵� ���� ���
        for (int i = 0; i < behaviors.Length; i++)
        {
            Vector2 partialMove = behaviors[i].CalculateMove(agent, context, boid) * weights[i];

            if (partialMove != Vector2.zero)
            {
                // �κ� �̵� ������ ���� ���̰� ����ġ�� �������� ū ��쿡�� ������ ũ�� ����
                if (partialMove.sqrMagnitude > weights[i] * weights[i])
                {
                    // partialMove�� ������ �����ϸ� ũ�⸦ 1�� ����
                    partialMove.Normalize();
                    partialMove *= weights[i];
                }

                // ���� �̵� ���Ϳ� �κ� �̵� ���� ���ϱ�
                move += partialMove;
            }
        }
        // ���� �̵� ���� ��ȯ
        return move;
    }
}
