using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaInimigo : MonoBehaviour
{
    public GameObject jogador;
    public float velocidade = 5f;

    void Start() {
        jogador = GameObject.FindWithTag("Jogador");
        int geraTipoZumbi = Random.Range(1,28);
        transform.GetChild(geraTipoZumbi).gameObject.SetActive(true);
    }

    void AtacaJogador(){
        Time.timeScale = 0;
        jogador.GetComponent<ControlaJogador>().textoGameOver.SetActive(true);
        jogador.GetComponent<ControlaJogador>().vivo = false;
    }

    void Update()
    {
        float distancia = Vector3.Distance(transform.position, jogador.transform.position);

        Vector3 direcao = jogador.transform.position - transform.position;

        Quaternion novaRotacao;
        novaRotacao = Quaternion.LookRotation(direcao);
        GetComponent<Rigidbody>().MoveRotation(novaRotacao);

        if(distancia > 2.5){
            GetComponent<Animator>().SetBool("Atacando",false);
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + direcao.normalized * velocidade * Time.deltaTime);
        }else{
            GetComponent<Animator>().SetBool("Atacando",true);
        }
    }
}
