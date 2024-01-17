using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionVeiw : MonoBehaviour
{
    GameObject optionTap;
    private bool isOpen = false;

    [System.Obsolete]
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        optionTap = transform.FindChild("Canvas").GetChild(0).gameObject;
    }

    private void Update()
    {

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log(isOpen);
            if(isOpen)
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
        Debug.Log(isOpen);
        if (isOpen)
        {
            Time.timeScale = 1.0f;
            optionTap.SetActive(false);
            isOpen = false;
        }
        else
        {
            Time.timeScale = 0f;
            optionTap.SetActive(true);
            isOpen = true;
        }
    }
}
