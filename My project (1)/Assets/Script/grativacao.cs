using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atracao : MonoBehaviour
{
    public Rigidbody rb;

    public float distancia;

    public float FG;

    public Vector3 forca;


    public bool verificarDirecao;

    public float distancia2 = 15;

    private void FixedUpdate()
    {
        atracao[] atratores = FindObjectsOfType<atracao>();

        foreach (atracao atra in atratores)
        {
            if (atra != this)
            {
                atracaoGravitacional(atra);
            }



        }


    }

    void atracaoGravitacional(atracao objAtracao)
    {
        Rigidbody rbObjetoAtracao = objAtracao.rb; //objeto que será atraido deve receber o rigidboy do objeto que atrai

        //obter a distancia entre os dois corpos

        Vector3 direcao = rb.position - rbObjetoAtracao.position; //distancia entre os dois planetas 

        distancia = direcao.magnitude;








        if (distancia > 8)
        {
            FG = (rb.mass * rbObjetoAtracao.mass) / Mathf.Pow(distancia, 2);

            forca = direcao.normalized * FG;

            rbObjetoAtracao.AddForce(forca);
        }
        else
        {

            verificarDirecao = true;
            rb.velocity = new Vector3(0, 0, 0);
            rbObjetoAtracao.velocity = new Vector3(0, 0, 0);
            FG = 0;
            rbObjetoAtracao.AddForce(new Vector3(0, 0, 0));

        }
        /*
        if (distancia < 15)
        {
            FG = - (rb.mass * rbObjetoAtracao.mass) / Mathf.Pow(distancia, 2);
            forca = direcao.normalized * FG;

            rbObjetoAtracao.AddForce(forca);
        }
       
        */




    }
    /*
    public void Atracao(Rigidbody corpo1, Rigidbody corpo2)
    {
        // F = G (M1 * M2 ) / D^2

        Vector3 distance = corpo1.gameObject.transform.position - corpo2.gameObject.transform.position;

        float Fg = 
         

        // G = 
    }*/
}
