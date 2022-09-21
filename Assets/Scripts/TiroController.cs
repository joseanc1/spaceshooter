using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroController : MonoBehaviour
{
    private Rigidbody2D meuRB;
    

    [SerializeField] private GameObject impacto;
    
    
    
    void Start()
    {
        
        //pegando o rigidbody
        meuRB = GetComponent<Rigidbody2D>();
        
        //indo para cima
        //meuRB.velocity = new Vector2(0f, vel);
        
        


    }

    
    void Update()
    {
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //pegar o metodo perdeVida e aplicar o dano
        //só deve funcionar se colidir com alguem que tenha o script inimigo controller 01
        //checando se a tag de quem estou colidindo é inimigo01
        if (collision.CompareTag("Inimigo"))
        {
            collision.GetComponent<InimigoPai>().PerdeVida(1);
            

        }
        
        

        
        //checando colisão com o player
        if (collision.CompareTag("Jogador"))
        {
            collision.GetComponent<PlayerController>().PerdaVida(1);
            
        }

        Destroy(gameObject);
        
        //criando o impacto
        Instantiate(impacto, transform.position, transform.rotation);

    }
}
