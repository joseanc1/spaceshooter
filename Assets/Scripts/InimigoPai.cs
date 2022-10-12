using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InimigoPai : MonoBehaviour
{
    //atributos que todos inimigos devem ter
    [SerializeField] protected float velocidade;

    [SerializeField] protected int vida;
    [SerializeField] protected float velocidadeTiro = 5f;
    [SerializeField] protected GameObject explosao;
    [SerializeField] protected float esperaTiro = 1f;
    [SerializeField] protected int pontos = 10;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //metodo perde vida
    public void PerdeVida(int dano)
    {
        
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        if (viewPos.y > 0 && viewPos.y < 1)
        {
            vida -= dano;

        
            //checando se morri
            if (vida <= 0)
            {
                Destroy(gameObject);

                Instantiate(explosao, transform.position, transform.rotation);
                
                
                //ganhando pontos
                FindObjectOfType<GeradorInimigos>().GanhaPontos(pontos);
            }
            
            
        }
        
        
    }

    //destruindo inimigo ao sair da cena
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Destruidor"))
        {
            Destroy(gameObject);
        } 
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.CompareTag("Jogador"))
        {
            Destroy(gameObject);
            
            Instantiate(explosao, transform.position, transform.rotation);
            
            //tirando vida do player
            other.gameObject.GetComponent<PlayerController>().PerdaVida(1);
         
        }
    }
}
