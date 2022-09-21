using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo02Controller : InimigoPai
{
    //rigidbody
    private Rigidbody2D meuRb;

    [SerializeField] private GameObject meuTiro;

    [SerializeField] private Transform posicaoTiro;
    
    protected float esperaTiro;
    
    
    
    
    void Start()
    {
        meuRb = GetComponent<Rigidbody2D>();
        
        
        //dando velocidade para o meuRB
        meuRb.velocity = new Vector2(0f, velocidade);
        
        //deixando a espera aleatória para o primeiro tiro
        esperaTiro = Random.Range(0.5f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
       
        Atirando();
    }

    private void Atirando()
    {


        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        if (viewPos.y > 0 && viewPos.y <1)
        {
            //diminuindo a espera, e se ela for igual ou menor que 0 o inimigo atira
            esperaTiro -= Time.deltaTime;

            if (esperaTiro <= 0)
            {
                //instanciando o tiro
               var tiro = Instantiate(meuTiro, posicaoTiro.position, transform.rotation);
               //encontrando o player na cena
               var player = FindObjectOfType<PlayerController>();
               //encontrando o valor da direção
               Vector2 direcao = player.transform.position - tiro.transform.position;
               //normalizando a velocidade 
               direcao.Normalize();
               //dando a direcao e velocidade do meu tiro
               tiro.GetComponent<Rigidbody2D>().velocity = direcao * velocidadeTiro;

                   //reiniciar a espera do tiro
                esperaTiro = Random.Range(1.5f, 2f);
            }
        }
    }
}
