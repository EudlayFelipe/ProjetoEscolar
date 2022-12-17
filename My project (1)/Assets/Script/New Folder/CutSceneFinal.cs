using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CutSceneFinal : MonoBehaviour
{
    public GameObject fadeOut;
    public GameObject TextoFinal;
        
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FinaldoJogo());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator FinaldoJogo()
    {
        yield return new WaitForSeconds(16f);
        fadeOut.SetActive(true);
        TextoFinal.SetActive(true);
    }
}
