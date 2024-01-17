using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats_box : MonoBehaviour
{
    // Start is called before the first frame update

    static public Stats_box Sbox;
    public int Strength { get; private set; }
    public int Agility { get; private set; }
    public int Intelligence { get; private set; }
    public int Stamina { get; private set; }
    public power_button power;
    public Recovery_button recovery;
    public Speed_button speed;
    public MaxHP_button maxHP;
    public ATK_Speed_button atkSpeed;
    //public Stats_box(int strength, int agility, int intelligence, int stamina)
    //{
    //    Strength = strength;
    //    Agility = agility;
    //    Intelligence = intelligence;
    //    Stamina = stamina;
    //}
    private void Start()
    {

    }
    public void IncreaseStatsForLevelUp()
    {
        // 레벨업 시 스탯을 상승하는 로직을 추가합니다. 예를 들어, 각 스탯을 일정량씩 증가시킬 수 있습니다.
        Debug.Log("레벨업!");
        power.power_call();
        recovery.Recovery_call();
        speed.Speed_call();
        maxHP.MaxHP_call();
        atkSpeed.ATK_Speed_call();
    }
}
