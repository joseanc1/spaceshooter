using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorInimigos : MonoBehaviour
{

    [SerializeField] private GameObject[] inimigos;

    private int pontos = 0;

    private int level = 1;

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

            esperaInimigo = tempoEspera;
            
            //criando um inimigo
            Vector3 posicao = new Vector3(Random.Range(-8f, 8f), Random.Range(6f, 17f), 0f);
            Instantiate(inimigos[0], posicao, transform.rotation);
        }
    }
}
