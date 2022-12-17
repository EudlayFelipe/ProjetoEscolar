using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace GERAL
{
    public class cronometro : MonoBehaviour
    {
        public float contador;
        public TextMeshProUGUI cont;
        public GameObject cont1;
        
        // Start is called before the first frame update
        void Start()
        {
            
            cont1.SetActive(false);
            contador = 20;
        }

        // Update is called once per frame
        void Update()
        {
            if (contador >= 0 )
            {

                contador -= Time.deltaTime;
                
                cont.text = contador.ToString("0");
            }
        }
    }
}
