using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GERAL
{
    public class torre : MonoBehaviour
    {
        public Transform target;
        public GameObject tiro;
        public int vida = 10;
        public RaycastARma dano;
        public Transform posTorre;
        bool verificar;

        // Start is called before the first frame update
        void Start()
        {
            InvokeRepeating("contar", 1, 2);
            StartCoroutine(contar());
        }

        // Update is called once per frame
        void Update()
        {
            transform.LookAt(target, Vector3.up);



        }

        void InstanciarProj()
        {

        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                StartCoroutine(contar());
            }
            else
            {
                StopAllCoroutines();
            }

        }


        IEnumerator contar()
        {
            yield return new WaitForSeconds(1f);
            Instantiate(tiro, posTorre.position, transform.rotation);

            StartCoroutine(contar());
        }
    }
}