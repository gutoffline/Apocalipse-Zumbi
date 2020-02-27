using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaArma : MonoBehaviour
{
    public GameObject Bala;
    public GameObject canoDaArma;

    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            Instantiate(Bala, canoDaArma.transform.position, canoDaArma.transform.rotation);
        }
    }
}
