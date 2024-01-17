using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxHP_button : MonoBehaviour
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
    public void MaxHP_call()
    {
        gameObject.SetActive(true);
    }
    public void OnClick()
    {
        Debug.Log("최대체력 증가");
    }
}
