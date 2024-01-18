using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ContextFilter 추상 클래스
public abstract class ContextFilter : ScriptableObject
{
    // Filter 메서드: BoidsAgent와 근처 개체의 리스트를 받아 필터링된 결과를 반환
    // Parameters:
    //   - agent: Boids 개체
    //   - original: 근처 개체 목록
    // Returns:
    //   - 필터링된 근처 개체 목록
    public abstract List<Transform> Filter(BoidsAgent agent, List<Transform> original);
}
