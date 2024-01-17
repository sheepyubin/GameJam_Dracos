using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ContextFilter �߻� Ŭ����
public abstract class ContextFilter : ScriptableObject
{
    // Filter() �� ��ü�� ��� �������� ����ϴ� �߻� �޼���
    //Parameters:
    // - agent: ���� Boids ��ü
    // - context: �ֺ� ��ü�� Transform ���
    // Returns:
    // - ���� �����ӿ� �̵��� ������ ��Ÿ���� ����
    public abstract List<Transform> Filter(BoidsAgent agent, List<Transform> original);
}
