using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorInimigos : MonoBehaviour
{

    [SerializeField] private GameObject[] inimigos;

    private int pontos = 0;

    [SerializeField ]private int level = 1;

    private float esperaInimigo = 0f;

    [SerializeField] private float tempoEspera = 5f;

   





    void Start()
    {
        
    }

    
    void Update()
    {
       
        
        GeraInimigos();
        

    }

    private void GeraInimigos()
    {
        if (esperaInimigo > 0f)
        {
            esperaInimigo -= Time.deltaTime;
            
        }


        if (esperaInimigo <= 0f)
        {

            GameObject inimigoCriado;
            
            //escolhendo a criação de qual inimigo
            float chance = Random.Range(0f, level);
            if (chance > 4f)
            {
                inimigoCriado = inimigos[1];
            }
            else
            {
                inimigoCriado = inimigos[0];
            }
            

            esperaInimigo = tempoEspera;
            
            //criando um inimigo
            Vector3 posicao = new Vector3(Random.Range(-8f, 8f), Random.Range(6f, 17f), 0f);
            Instantiate(inimigoCriado, posicao, transform.rotation);
        }
    }
}
