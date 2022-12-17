using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pergunta2 : MonoBehaviour
{
    public GameObject painelPergunta2;
    bool colidindoPergunta;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (colidindoPergunta == false)
            {
                painelPergunta2.SetActive(true);
                colidindoPergunta = true;
                Time.timeScale = 0;
                Cursor.visible = true;
            }
        }
    }
}
