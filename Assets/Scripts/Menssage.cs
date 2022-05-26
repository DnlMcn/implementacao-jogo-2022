using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Menssage : MonoBehaviour
{
    public Text texto;
    private GameObject jogador;
    [Range(1, 10)] public float distanca = 3;
      void Start()
    {
        texto.enabled = false;
        jogador = GameObject.FindWithTag ("player"); 

    }
    void Update()
    {
        if(Vector3.Distance(transform.position,jogador.transform.position) < distanca)
        {
            texto.enabled= true;

        }
        else
        {
            texto.enabled= false;
        }
    }
   
}
