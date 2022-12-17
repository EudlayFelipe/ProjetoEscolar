using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using UnityEngine.UI;
using System;
namespace GERAL
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(IntObj))]

    public class inimigo : MonoBehaviour
    {
        public GameObject player;
        private NavMeshAgent navMesh;
        public float distance;
        public float AreaDeSeguir;
        public GameObject pInicial;
        public float distancia;
        private bool puloBoss;
        public float AreaDePulo;

        private Animator anim;
        private bool mov;
        private bool idle;

        public bool podeAtacar;

        private int pontuacao;
        public Text txtPontuacao;
        public RaycastARma dano;
        public int vida = 100;

        

        void Start()
        {
            dano = GetComponent<RaycastARma>();

            player = GameObject.FindWithTag("Player");
            navMesh = GetComponent<NavMeshAgent>();
            anim = GetComponent<Animator>();

            StartCoroutine("AtacarInimigo");
        }

        // Update is called once per frame
        void Update()
        {
            distance = Vector2.Distance(transform.position, player.transform.position);

            if (vida <= 0)
            {
                Destroy(this.gameObject);
            }

           
            
            if (distance <= AreaDeSeguir )
            {
                navMesh.destination = player.transform.position;
                mov = true;
            }
            else
            {
                navMesh.destination = pInicial.transform.position;

                podeAtacar = false;
               
            }
            if(transform.position.x == pInicial.gameObject.transform.position.x)
            {
                mov = false;    
            }
            if (transform.position.x < 50)
            {
                mov = false;
            }                  
            anim.SetBool("Mov", mov);
            anim.SetBool("Idle", idle);
            anim.SetBool("Ataque", podeAtacar);

            Atacar();

        }    

        void Atacar()
        {
           
            StartCoroutine("AtacarInimigo");
        }

        IEnumerator AtacarInimigo()
        {
            if (Vector3.Distance(transform.position, player.transform.position) < 10)
            {

                if(podeAtacar == false)
                {
                    podeAtacar = true;
                    mov = false;
                    yield return new WaitForSeconds(6f);
                }
                             
            }

            StartCoroutine("AtacarInimigo");

        }


        private void OnCollisionEnter(Collision coll)
        {
            if(coll.gameObject.tag == "Player")
            {
                player.GetComponent<Playervida>().vida -= 5;
            }
        }
     
    }
}
