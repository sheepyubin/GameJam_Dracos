using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���̾� ����ũ�� ��ó ������Ʈ�� ���͸�
[CreateAssetMenu(menuName = "Boids/Filter/Physics Layer")]
public class PhysicsLayerFilter : ContextFilter
{
    // ���̾� ����ũ
    public LayerMask mask;

    // Filter() �޼���: BoidsAgent�� ��ó ������Ʈ�� ����� ���͸�
    // Parameters:
    //   - agent: Boids ��ü
    //   - original: ��ó ������Ʈ�� ���
    // Returns:
    //   - ���͸��� ��ó ������Ʈ�� ���
    public override List<Transform> Filter(BoidsAgent agent, List<Transform> original)
    {
        // ���͸��� ������Ʈ�� ���� ����Ʈ
        List<Transform> filtered = new List<Transform>();

        // ��ó ������Ʈ�� ����� ��ȸ�ϸ鼭 ��ü�� ã�� ���͸�
        foreach (Transform objTransform in original)
        {
            if (mask == (mask | (1 << objTransform.gameObject.layer)))
            {
                // ���͸��� ����Ʈ�� �߰�
                filtered.Add(objTransform);
            }
        }

        // ������Ʈ�� ��� ��ȯ
        return filtered;
    }
}
