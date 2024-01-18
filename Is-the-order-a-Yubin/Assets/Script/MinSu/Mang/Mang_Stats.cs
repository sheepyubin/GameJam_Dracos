using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mang_Stats : Character_Stats
{
    public Image nowHpbar;          // 현재 체력바
    public GameObject prfHpBar;     // 체력바 프리팹
    public GameObject canvas;       // 캔버스

    GameObject hpBar;               // 체력바 RectTransform
     int nowHp;
    int maxHp;
    void Start()
    {

        hpBar = Instantiate(prfHpBar, canvas.transform);
        nowHpbar = hpBar.transform.GetChild(0).GetComponent<Image>();
        MangStats(3, 100, 3, 2, 3);
        //Debug.Log(sprites[0]);
    }

    private void MangStats(int _ATK, int _HP, int _MOV, int _ATK_Speed, int _HP_recover)
    {
        ATK = _ATK;
        HP = _HP;
        nowHp = _HP;
        maxHp = _HP;
        MOV = _MOV;
        ATK_Speed = _ATK_Speed;
        HP_Recovery = _HP_recover;
    }
    void Update()
    {
        // 체력바 위치 업데이트
        Vector3 _hpBarPos = Camera.main.WorldToScreenPoint(new Vector3(-30, 19));
        hpBar.GetComponent<RectTransform>().position = _hpBarPos;
        nowHpbar.fillAmount = (float)nowHp / (float)maxHp;
    }
}
