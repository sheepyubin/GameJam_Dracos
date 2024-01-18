using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionView : MonoBehaviour
{
    EffectPlay effectPlay;
    private GameObject optionTap;
    private bool isOpen = false;

    [System.Obsolete]

    private void Start()
    {
        effectPlay = GameObject.Find("OptionCanvas").GetComponent<EffectPlay>();
        DontDestroyOnLoad(this);
        optionTap = transform.FindChild("Canvas").GetChild(0).gameObject;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            effectPlay.buttonClick();

            if (isOpen)
            {
                Time.timeScale= 1.0f;
                optionTap.SetActive(false);
                isOpen = false;
            }
            else
            {
                Time.timeScale= 0f;
                optionTap.SetActive(true);
                isOpen = true;
            }
        }
    }

    public void ClickOptionBack()
    {
        effectPlay.buttonClick();

        if (isOpen)
        {
            Time.timeScale= 1.0f;
            optionTap.SetActive(false);
            isOpen = false;
        }
        else
        {
            Time.timeScale= 0f;
            optionTap.SetActive(true);
            isOpen = true;
        }
    }
}
