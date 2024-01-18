using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class power_button : MonoBehaviour
{
    public status_control status_con;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        status_con.InStatus(0);
        falseObject();  
    }

    public void power_call()
    {
        gameObject.SetActive(true);
    }
    public void falseObject()
    {
        gameObject.SetActive(false);
    }
}
