using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo02Controller : InimigoPai
{
    //rigidbody
    private Rigidbody2D meuRb;

    [SerializeField] private GameObject meuTiro;

    [SerializeField] private Transform posicaoTiro;

    [SerializeField] private float yMax = 2.5f;

    private bool possoMover = true;
    
    
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

        //checando se cheguei no meio da tela e se posso mover
        if (transform.position.y < yMax && possoMover)
        {
            
            //checando se estou na esquerda ou direita
            if (transform.position.x < 0f)
            {
               
                    //indo para direita
                    meuRb.velocity = new Vector2(velocidade * -1, velocidade);
                    
                //não posso mais mover
                possoMover = false;
            }
            else
            {
               
                //indo para esquerda
                meuRb.velocity = new Vector2(velocidade , velocidade);
                
                
                //não posso mais mover
                possoMover = false;
            }
        }
        

    }

    private void Atirando()
    {

        
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        if (viewPos.y > 0 && viewPos.y < 1)
        {
                      
        
            bool visivel = GetComponentInChildren<SpriteRenderer>().isVisible;
        
            if (visivel)
            {
                //encontrando o player na cena
                var player = FindObjectOfType<PlayerController>();
            
                //só fazer animação se o player existir
                if (player)
                {
                    //diminuindo a espera, e se ela for igual ou menor que 0 o inimigo atira
                    esperaTiro -= Time.deltaTime;
                    if (esperaTiro <= 0)
                    {
                        //instanciando o tiro
                        var tiro = Instantiate(meuTiro, posicaoTiro.position, transform.rotation);
               
                        //encontrando o valor da direção
                        Vector2 direcao = player.transform.position - tiro.transform.position;
                        //normalizando a velocidade 
                        direcao.Normalize();
                        //dando a direcao e velocidade do meu tiro
                        tiro.GetComponent<Rigidbody2D>().velocity = direcao * velocidadeTiro;
               
                        //dando o angulo que o tiro deve estar
                        float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;
               
                        //passando o ângulo
                        tiro.transform.rotation = Quaternion.Euler(0f, 0f, angulo +90f);

                        //reiniciar a espera do tiro
                        esperaTiro = Random.Range(1.5f, 2f);
                    }
                }
            }
        }
      
    }
}
