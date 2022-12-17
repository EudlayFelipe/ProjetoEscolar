using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtracaoGravidade : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;
    [SerializeField]
    Rigidbody rbPlaneta;

    private Vector3 Direcao;
    public float distancia;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Direcao = rb.position - rbPlaneta.position;
        distancia = Direcao.magnitude;
    }
}
