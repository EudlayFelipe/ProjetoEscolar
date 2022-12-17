using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


namespace GERAL
{
    [RequireComponent(typeof(IntObj))] //permite utilizar outro script com o mesmo namespace

    public class acaoInteracao : MonoBehaviour
    {
        private IntObj interPersonagem; //permite utilizar os elementos do outro script
        public bool pegou; //verifica se já pegou um objeto ou não
        private float distancia; //verifica a distância do objeto;
        public int QuantColetavel;
        public TextMeshProUGUI texto;
        public TextMeshProUGUI text;
        public GameObject porta;
        public GameObject InfoPorta;
        

        public float contador;
        public TextMeshProUGUI cont;
        public GameObject cont1;

        public bool missionC;
        public float tempoAt;

        //   public GameObject pegaObjeto;


        void Start()
        {
            interPersonagem = GetComponent<IntObj>();
            pegou = false;
            InfoPorta.SetActive(false);
            cont1.SetActive(false);
            
        }


        void Update()
        {

            

            distancia = interPersonagem.distanciaAlvo;
            
            if (distancia <= 10 && Input.GetKeyDown(KeyCode.E))
            {
                if( interPersonagem.porta != null && QuantColetavel >= 1)
                {
                    porta.GetComponent<Animator>().SetTrigger("porta");
                   

                }
                else if(interPersonagem.porta != null && QuantColetavel < 1 && missionC == false)
                {
                    
                    
                        StartCoroutine("Textos");
                       
                   

                }
                



                if (interPersonagem.objPegar != null)
                {
                    Pegar();
                    QuantColetavel += 1;
                    texto.text = QuantColetavel.ToString();

                }


                if (interPersonagem.objArrastar != null)
                {
                    if (!pegou)
                    {
                        pegou = true;
                        Arrastar();
                    }
                    else
                    {
                        pegou = false;
                        Soltar();
                    }

                }

            }

            if (QuantColetavel > 0)
            {
                StopAllCoroutines();
                cont.text = contador.ToString("0");
                return;

            }
            if (contador >= 0)
            {

                contador -= Time.deltaTime;

                cont.text = contador.ToString("0");

                

            }

           

        }

        void Pegar()
        {
            Destroy(interPersonagem.objPegar);
        }

        void Arrastar()
        {
            interPersonagem.objArrastar.GetComponent<Rigidbody>().isKinematic = true;  //quando marcado o objeto fica fixo na cena;
            interPersonagem.objArrastar.GetComponent<Rigidbody>().useGravity = false; //desativa a gravidade
            interPersonagem.objArrastar.transform.SetParent(transform); //manda o objeto ser filho da câmera desta forma se movimento junto com a câmera
            interPersonagem.objArrastar.transform.localPosition = new Vector3(0f, 0f, 3f); //distânica do objetop a câmera
            interPersonagem.objArrastar.transform.localRotation = Quaternion.Euler(0, 0, 0); //o objeto fica reto na tela
        }

        void Soltar()
        {
            interPersonagem.objArrastar.transform.localPosition = new Vector3(0f, 0f, 3f);
            interPersonagem.objArrastar.transform.SetParent(null);
            interPersonagem.objArrastar.GetComponent<Rigidbody>().isKinematic = false;
            interPersonagem.objArrastar.GetComponent<Rigidbody>().useGravity = true;

        }
        IEnumerator Textos()
        {
            InfoPorta.SetActive(true);
            yield return new WaitForSeconds(1f);
            InfoPorta.SetActive(false);
            cont1.SetActive(true);
            contador = 20;


        }

    }

   

}
