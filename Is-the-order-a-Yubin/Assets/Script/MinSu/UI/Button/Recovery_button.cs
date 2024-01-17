using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recovery_button : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject status;
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Recovery_call()
    {
        gameObject.SetActive(true);
    }
    public void OnClick()
    {
        Debug.Log("체력재생 증가");
    }
}
