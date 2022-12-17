using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GERAL //FACILITA O ACESSO EM OUTRO SCRIPT
{


    public class IntObj : MonoBehaviour
    {

        private Transform mainCamera;
        private Ray raio;
        private RaycastHit raioInformacao;
        public float alcanceRaio;
        public LayerMask layerInteracao;
        public GameObject objArrastar, objPegar, porta;  //add atribui os objetos interacao
        public float distanciaAlvo; //add verifica a distância do alvo
        public GameObject Info;
        




        void Start()
        {
            mainCamera = Camera.main.transform;
            Info.SetActive(false);

        }

        // Update is called once per frame
        void Update()
        {
            raio.origin = mainCamera.position;
            raio.direction = mainCamera.forward;
            Debug.DrawRay(raio.origin, raio.direction * alcanceRaio, Color.red);

            if (Physics.Raycast(raio.origin, raio.direction, out raioInformacao, alcanceRaio, layerInteracao))
            {

                Info.SetActive(true);

                distanciaAlvo = raioInformacao.distance;//add exibe a distância do personagem ao objeto

                if (raioInformacao.transform.gameObject.tag == "objArrastar") //verifica se o objeto interação esta na tag especificada
                {
                    objArrastar = raioInformacao.transform.gameObject; //atribui o objeto selecionado
                    objPegar = null;
                }
                else
                {
                    objArrastar = null; //caso não intergir com objetoArrastar variável fica vazia 
                }

                if (raioInformacao.transform.gameObject.tag == "objPegar") //verifica se o objeto interação esta na tag especificada
                {
                    objPegar = raioInformacao.transform.gameObject; //atribui o objeto selecionado
                    objArrastar = null;
                }
                else
                {
                    objPegar = null; //caso não intergir com objetoArrastar variável fica vazia 
                }

                if (raioInformacao.transform.gameObject.tag == "porta") //verifica se o objeto interação esta na tag especificada
                {
                   porta = raioInformacao.transform.gameObject; //atribui o objeto selecionado
                    objPegar = null;
                    objArrastar = null;
                }
                else
                {
                    porta = null; //caso não intergir com objetoArrastar variável fica vazia 
                }

            }
            else
            {
                Info.SetActive(false);
            }

        }
    }
}
