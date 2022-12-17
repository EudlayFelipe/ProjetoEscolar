using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace Geral
{
    public class Inimigo : MonoBehaviour
    {
        public NavMeshAgent navMeshAgent;
        public Transform[] destino;
        private int identificadorDestino;



        private Animator anim;



        [SerializeField]
        GameObject player;
        bool pegarEle = false;
        [SerializeField]
        float dist = 5;
        [SerializeField]
        float distAtaque;


        public GameObject detectArea;
        //private detection detec;
        


        // Start is called before the first frame update
        void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            anim = GetComponent<Animator>();

            navMeshAgent.destination = destino[0].position;

            distAtaque = navMeshAgent.stoppingDistance;

            //detec = detectArea.gameObject.GetComponent<detection>();
        }

        // Update is called once per frame
        void Update()
        {
            anim.SetBool("Andar", true);

           // pegaEle();
            patrol();

            //Debug.Log(detec.detectado);
        }



        void patrol()
        {

            if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
            {


                if (identificadorDestino <= destino.Length)
                {


                    identificadorDestino += 1;



                }
                else
                {

                    identificadorDestino = 0;


                }

                navMeshAgent.destination = destino[identificadorDestino].position;


            }
        }


        void Perseguir()
        {

        }

       /* void pegaEle()
        {
           // if(detec.detectado == true)
           // {
                pegarEle = true;
            }
            else
            {
                pegarEle =false;
            }
            
            if (pegarEle)
            {
                navMeshAgent.destination = player.transform.localPosition;
            }
        }
       */

    }
}

