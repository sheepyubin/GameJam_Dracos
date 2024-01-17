using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class status_control : MonoBehaviour
{
    public int power=3;
    public int recovery=3;
    public int speed=3;
    public int maxHP=100;
    public int atkSpeed=3;
    int curPower;
    int curRecovery;
    int curSpeed;
    int curMaxHP;
    int curAtkSpeed;
    // Start is called before the first frame update
    void Start()
    {
        int curPower = power;
        int curRecovery = recovery;
        int curSpeed = speed;
        int curMaxHP = maxHP;
        int curAtkSpeed = atkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        curAtkSpeed = atkSpeed;
        curPower = power;
        curRecovery = recovery;
        curSpeed = speed;
        curMaxHP = maxHP;
    }

    public void InStatus(int n)
    {
        Debug.Log("스텟에 접근");
        switch(n)
        {
            case 0 : power += 3;
                Debug.Log("공격력 3증가");
                break;
            case 1:  recovery += 3;
                break;
            case 2: speed++;
                break;
            case 3: maxHP += 15;
                break;
            case 4: atkSpeed%=10;
                break;
        }
    }
}
