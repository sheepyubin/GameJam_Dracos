using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 레이어 마스크로 근처 오브젝트를 필터링
[CreateAssetMenu(menuName = "Boids/Filter/Physics Layer")]
public class PhysicsLayerFilter : ContextFilter
{
    // 레이어 마스크
    public LayerMask mask;

    // Filter() 메서드: BoidsAgent와 근처 오브젝트를 목록을 필터링
    // Parameters:
    //   - agent: Boids 개체
    //   - original: 근처 오브젝트를 목록
    // Returns:
    //   - 필터링된 근처 오브젝트를 목록
    public override List<Transform> Filter(BoidsAgent agent, List<Transform> original)
    {
        // 필터링된 오브젝트를 담을 리스트
        List<Transform> filtered = new List<Transform>();

        // 근처 오브젝트를 목록을 순회하면서 개체를 찾아 필터링
        foreach (Transform objTransform in original)
        {
            if (mask == (mask | (1 << objTransform.gameObject.layer)))
            {
                // 필터링된 리스트에 추가
                filtered.Add(objTransform);
            }
        }

        // 오브젝트를 목록 반환
        return filtered;
    }
}
