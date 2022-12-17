using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{

    public GameObject canvasInformacao;
    public GameObject videoIntroducao;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InicioJogo());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator InicioJogo()
    {

       

 
        yield return new WaitForSeconds(95);
        SceneManager.LoadScene("Espaço");

    }

    public void fimFade()
    {
        canvasInformacao.SetActive(false);
    }
}
