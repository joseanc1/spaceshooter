using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo01Controller : MonoBehaviour
{

    //variavel do rigidbody2d
    private Rigidbody2D meuRb;

    [SerializeField] private float velocidade = -3f;

    [SerializeField] private GameObject meuTiro;


    [SerializeField] private Transform posicaoTiro;

    [SerializeField] private int vida = 1;
    
    private float esperaTiro = 1f;
    
    void Start()
    {

        //pegando o rigidbody
        meuRb = GetComponent<Rigidbody2D>();
        
        //dando velocidade para o meuRB
        meuRb.velocity = new Vector2(0f, velocidade);
        
        
        //deixando a espera aleatória para o primeiro tiro
        esperaTiro = Random.Range(0.5f, 2f);

    }

    
    void Update()
    {
        //checando se o spriterender esta visivel
        
        //pegando info dos "filhos"
        bool visivel = GetComponentInChildren<SpriteRenderer>().isVisible;
        
        
        
       

        if (visivel)
        {
            //diminuindo a espera, e se ela for igual ou menor que 0 o inimigo atira
            esperaTiro -= Time.deltaTime;
            
            if (esperaTiro <= 0)
            {
                //instanciando o tiro
                Instantiate(meuTiro, posicaoTiro.position, transform.rotation);
            
                //reiniciar a espera do tiro
                esperaTiro = Random.Range(1.5f, 2f);
            }
        }
        
    }

    //metodo para morte do inimigo
    public void PerdaVida(int dano)
    {
        //perdendo a vida com base no dano
        vida -= dano;
        
      
    }
}
