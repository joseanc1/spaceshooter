using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    //somente test
    float vel = 0.1f;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        var horizontal  = Input.GetAxis("Horizontal")* vel;
        Debug.Log(horizontal);
    }

    
}
