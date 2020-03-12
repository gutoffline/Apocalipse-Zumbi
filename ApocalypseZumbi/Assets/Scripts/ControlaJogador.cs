using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlaJogador : MonoBehaviour
{
    public float velocidade = 10f;
    public LayerMask mascaraChao;
    public GameObject textoGameOver;
    public bool vivo = true;
    private Rigidbody rigidbodyJogador;

    void Start()
    {
        Time.timeScale = 1;
        rigidbodyJogador = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!vivo){
            if(Input.GetButtonDown("Fire1")){
                SceneManager.LoadScene("game");
            }
        }

        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit impacto;
        if(Physics.Raycast(raio, out impacto, mascaraChao)){
           Vector3 posicaoMiraJogador = impacto.point - transform.position;
           posicaoMiraJogador.y = 0; 

           Quaternion novaRotacao = Quaternion.LookRotation(posicaoMiraJogador);
           rigidbodyJogador.MoveRotation(novaRotacao);
        }

        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");
        Vector3 direcao = new Vector3(eixoX , 0 , eixoZ);
        rigidbodyJogador.MovePosition(rigidbodyJogador.position + (direcao * velocidade * Time.deltaTime));
        
        if(direcao != Vector3.zero){
            GetComponent<Animator>().SetBool("Movendo",true);
        }else{
            GetComponent<Animator>().SetBool("Movendo",false);
        }
    }
}
