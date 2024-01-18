using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SameBoidsFilter: 같은 개체를 필터링하는 ScriptableObject 클래스
[CreateAssetMenu(menuName = "Boids/Filter/Same Boids")]
public class SameBoidsFilter : ContextFilter
{
    // Filter 메서드 구현: 같은 개체를 필터링
    // Parameters:
    //   - agent: Boids 개체
    //   - original: 근처 개체 목록
    // Returns:
    //   - 필터링된 근처 개체 목록
    public override List<Transform> Filter(BoidsAgent agent, List<Transform> original)
    {
        // 필터링된 개체를 담을 리스트
        List<Transform> filtered = new List<Transform>();

        // 근처 개체 목록을 순회하면서 개체를 찾아 필터링
        foreach (Transform objTransform in original)
        {
            BoidsAgent itemAgent = objTransform.GetComponent<BoidsAgent>();

            // 필터링된 리스트에 추가
            if (itemAgent != null && itemAgent.AgentBoid == agent.AgentBoid)
            {
                filtered.Add(objTransform);
            }
        }

        // 필터링된 인접 오브젝트 목록 반환
        return filtered;
    }
}
