using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mang_Move : MonoBehaviour
{
    // Start is called before the first frame update
    private int speed;
    Mang_Stats stats;
    void Start()
    {
        //speed = stats.MOV;
        Debug.Log(speed);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * speed * Time.deltaTime;
        transform.Translate(movement);
    }


   
}
