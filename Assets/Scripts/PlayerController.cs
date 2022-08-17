using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    private Rigidbody2D myRB;
    [SerializeField] private float velocidade = 5f;
    [SerializeField] private GameObject meuTiro;
    [SerializeField] private Transform posicaoTiro;
    
    
    
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        
        
        
    }

    
    void Update()
    { 
     //pegando o input horizontal 
     float horizontal = Input.GetAxis("Horizontal");
    
     //pegando o input vertical
     float vertical = Input.GetAxis("Vertical");
     Vector2 minhaVelocidade = new Vector2(horizontal,vertical);
     
     //normalizando a velocidade
     minhaVelocidade.Normalize();
     
      
      
      //passando a velocidade para o RB
      myRB.velocity = minhaVelocidade * velocidade;
      
      
      
      //teste de botão de tiro
      if (Input.GetButtonDown("Fire1"))
      {
          Instantiate(meuTiro, posicaoTiro.position, transform.rotation);
      }
    }

    
}
