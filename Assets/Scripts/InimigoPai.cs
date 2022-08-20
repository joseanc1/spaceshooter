using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoPai : MonoBehaviour
{
    //atributos que todos inimigos devem ter
    [SerializeField] protected float velocidade;

    [SerializeField] protected int vida;

    [SerializeField] protected GameObject explosao;
    
    
    
    
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
        vida -= dano;

        
        //checando se morri
        if (vida <= 0)
        {
            Destroy(gameObject);

            Instantiate(explosao, transform.position, transform.rotation);
        }
    }
    
}
