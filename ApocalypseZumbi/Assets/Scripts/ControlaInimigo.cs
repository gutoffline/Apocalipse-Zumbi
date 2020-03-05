using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaInimigo : MonoBehaviour
{
    public GameObject jogador;
    public float velocidade = 5f;
    void Update()
    {
        float distancia = Vector3.Distance(transform.position, jogador.transform.position);

        Vector3 direcao = jogador.transform.position - transform.position;

        if(distancia > 2.5){
            GetComponent<Animator>().SetBool("Atacando",false);
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + direcao.normalized * velocidade * Time.deltaTime);

            Quaternion novaRotacao;
            novaRotacao = Quaternion.LookRotation(direcao);
            GetComponent<Rigidbody>().MoveRotation(novaRotacao);
        }else{
            GetComponent<Animator>().SetBool("Atacando",true);
        }
    }
}
