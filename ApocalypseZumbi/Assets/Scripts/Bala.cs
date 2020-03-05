using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{

    public float velocidade = 100f;
    
    void Update()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.forward * velocidade * Time.deltaTime);
    }

    void OnTriggerEnter(Collider objetoColidido) {
        Debug.Log(objetoColidido.tag);
        if(objetoColidido.tag == "Inimigo"){
            Destroy(objetoColidido.gameObject);
        }
        
        Destroy(gameObject);
    }
}
