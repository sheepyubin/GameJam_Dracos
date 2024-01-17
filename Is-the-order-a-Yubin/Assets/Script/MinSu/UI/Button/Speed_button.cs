using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed_button : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Speed_call()
    {
        gameObject.SetActive(true);
    }
    public void OnClick()
    {
        Debug.Log("이동속도 증가");
    }
}
