using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// BoidsBehavior �߻� Ŭ����
public abstract class BoidsBehavior : ScriptableObject
{
    // CalculateMove() �� ��ü�� ��� �������� ����ϴ� �߻� �޼���
    //Parameters:
    // - agent: ���� Boids ��ü
    // - context: �ֺ� ��ü�� Transform ���
    // - boid: Boids�� ���ϴ� ��ü
    // Returns:
    // - ���� �����ӿ� �̵��� ������ ��Ÿ���� ����
    public abstract Vector2 CalculateMove(BoidsAgent agent, List<Transform> context, Boids boid);
}
