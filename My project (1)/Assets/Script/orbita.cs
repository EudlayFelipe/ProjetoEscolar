using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbita : MonoBehaviour
{
    public Transform Alvo;
    public Vector3 Eixo;

    public float velocidade;
    public float diametro;
    
    void Start()
    {
        
    }

   
    void Update()
    {
        transform.RotateAround(Alvo.position, Eixo, velocidade * Time.deltaTime);
        Vector3 posDesejada = (transform.position - Alvo.position).normalized * diametro + Alvo.position;
        
    }
}
