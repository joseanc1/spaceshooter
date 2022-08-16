using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo01Controller : MonoBehaviour
{

    //variavel do rigidbody2d
    private Rigidbody2D meuRb;

    [SerializeField] private float velocidade = -3f;

    [SerializeField] private GameObject meuTiro;
    
    void Start()
    {

        //pegando o rigidbody
        meuRb = GetComponent<Rigidbody2D>();
        
        //dando velocidade para o meuRB
        meuRb.velocity = new Vector2(0f, velocidade);

    }

    
    void Update()
    {
        //instanciando o tiro
        Instantiate(meuTiro, transform.position, transform.rotation);
    }
}
