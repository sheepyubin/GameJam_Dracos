using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SameBoidsFilter: ���� ��ü�� ���͸��ϴ� ScriptableObject Ŭ����
[CreateAssetMenu(menuName = "Boids/Filter/Same Boids")]
public class SameBoidsFilter : ContextFilter
{
    // Filter �޼��� ����: ���� ��ü�� ���͸�
    // Parameters:
    //   - agent: Boids ��ü
    //   - original: ��ó ��ü ���
    // Returns:
    //   - ���͸��� ��ó ��ü ���
    public override List<Transform> Filter(BoidsAgent agent, List<Transform> original)
    {
        // ���͸��� ��ü�� ���� ����Ʈ
        List<Transform> filtered = new List<Transform>();

        // ��ó ��ü ����� ��ȸ�ϸ鼭 ��ü�� ã�� ���͸�
        foreach (Transform objTransform in original)
        {
            BoidsAgent itemAgent = objTransform.GetComponent<BoidsAgent>();

            // ���͸��� ����Ʈ�� �߰�
            if (itemAgent != null && itemAgent.AgentBoid == agent.AgentBoid)
            {
                filtered.Add(objTransform);
            }
        }

        // ���͸��� ���� ������Ʈ ��� ��ȯ
        return filtered;
    }
}
