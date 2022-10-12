using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorInimigos : MonoBehaviour
{

    [SerializeField] private GameObject[] inimigos;

    [SerializeField] private int pontos = 0;

    [SerializeField ]private int level = 1;

    private float esperaInimigo = 0f;

    [SerializeField] private float tempoEspera = 2f;

    [SerializeField] private int baseLevel = 100;

    [SerializeField] private int qtdInimigos = 0;

    void Start()
    {
        
    }

    
    void Update()
    {

        GeraInimigos();
    }
    

    public void GanhaPontos(int pontos)
    {
        this.pontos += pontos;
        
        
        //ganhando level
        if (this.pontos > baseLevel * level)
        {
            level++;
        }
    }

    public void DiminuiQuantidade()
    {
        qtdInimigos--;
    }

    private void GeraInimigos()
    {
        if (esperaInimigo > 0f && qtdInimigos <= 0)
        {
            esperaInimigo -= Time.deltaTime;
        }


        if (esperaInimigo <= 0f && qtdInimigos <= 0)
        {
            int quantidade = level * 4;
            
            
            //criando vários inimigos de uma vez
            while (qtdInimigos < quantidade)
            {
                GameObject inimigoCriado;
            
                //escolhendo qual inimigo inimigo criar
                float chance = Random.Range(0f, level);
                if (chance > 2f)
                {
                    inimigoCriado = inimigos[1];
                }
                else
                {
                    inimigoCriado = inimigos[0];
                }
                
            
                //definindo a posição e criando o inimigo
                Vector3 posicao = new Vector3(Random.Range(-8f, 8f), Random.Range(6f, 12f), 0f);
                Instantiate(inimigoCriado, posicao, transform.rotation);
                
                //aumentando a quantidade de inimigos criados 
                qtdInimigos++;
                
                //reiniciando o tempo de espera
                esperaInimigo = tempoEspera;
            }
        }
    }
}
