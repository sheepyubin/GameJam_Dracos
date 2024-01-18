using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ContextFilter �߻� Ŭ����
public abstract class ContextFilter : ScriptableObject
{
    // Filter �޼���: BoidsAgent�� ��ó ��ü�� ����Ʈ�� �޾� ���͸��� ����� ��ȯ
    // Parameters:
    //   - agent: Boids ��ü
    //   - original: ��ó ��ü ���
    // Returns:
    //   - ���͸��� ��ó ��ü ���
    public abstract List<Transform> Filter(BoidsAgent agent, List<Transform> original);
}
