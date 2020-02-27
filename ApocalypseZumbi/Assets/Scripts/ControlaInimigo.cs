using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaInimigo : MonoBehaviour
{
    public GameObject jogador;
    public float velocidade = 5f;
    void Update()
    {
       Vector3 direcao = jogador.transform.position - transform.position;
       GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + direcao.normalized * velocidade * Time.deltaTime);

       Quaternion novaRotacao;
       novaRotacao = Quaternion.LookRotation(direcao);
       GetComponent<Rigidbody>().MoveRotation(novaRotacao);
    }
}
