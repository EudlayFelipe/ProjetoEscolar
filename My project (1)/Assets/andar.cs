using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class andar : MonoBehaviour
{
    public GameObject player;
    float distanciaDoPlayer;
    public float distanciaSeguir;
    public float distanciaAtacar;
    public float speed;
    Vector3 startPos;
    bool atacando;

    Animator animAranha;

    Rigidbody rB;


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        rB = GetComponent<Rigidbody>();
        animAranha = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        distanciaDoPlayer = Vector3.Distance(player.transform.position, transform.position);

        Seguir();

       
    }

    void Morrer()
    {

    }

    void Seguir()
    {

        if (distanciaDoPlayer <= distanciaSeguir)
        {
            animAranha.SetBool("Mov", true);
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        else if (distanciaDoPlayer >= distanciaSeguir)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
            animAranha.SetBool("Mov", false);
        }

       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "tiro")
        {
            Destroy(gameObject, 0.3f);
        }
    }


    


}