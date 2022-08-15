using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroController : MonoBehaviour
{
    private Rigidbody2D meuRB;

    [SerializeField] private float vel = 10f;
    
    
    void Start()
    {
        
        //pegando o rigidbody
        meuRB = GetComponent<Rigidbody2D>();
        
        //indo para cima
        meuRB.velocity = new Vector2(0f, vel);
        
        


    }

    
    void Update()
    {
      
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
        Destroy(gameObject);
    }
}
