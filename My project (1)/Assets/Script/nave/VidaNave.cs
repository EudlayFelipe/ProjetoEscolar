using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaNave : MonoBehaviour
{
    private cenas PoassarCena;
    [Header("Vida")]
    public Text txVida;
    public int vida;
    // Start is called before the first frame update
    void Start()
    {
        PoassarCena = GameObject.Find("SceneManager").GetComponent<cenas>();
    }

    // Update is called once per frame
    void Update()
    {
            if(vida <= 0)
        {
            PoassarCena.LoadScene("GameOver");
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("asteroide"))
        {
            Destroy(coll.gameObject);
            vida -= 1;
            txVida.text = vida.ToString();

        }


        if (coll.gameObject.CompareTag("planeta"))
        {
            

            PoassarCena.LoadScene("SampleScene");
        }


    }
}
