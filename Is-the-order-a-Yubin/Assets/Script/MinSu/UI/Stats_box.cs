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
        // ������ �� ������ ����ϴ� ������ �߰��մϴ�. ���� ���, �� ������ �������� ������ų �� �ֽ��ϴ�.
        Debug.Log("������!");
        power.power_call();
        recovery.Recovery_call();
        speed.Speed_call();
        maxHP.MaxHP_call();
        atkSpeed.ATK_Speed_call();
    }
}
