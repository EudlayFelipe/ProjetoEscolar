 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class frame : MonoBehaviour
{
    private cenas cen;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        cen = GameObject.Find("SceneManager").GetComponent<cenas>();

        StartCoroutine("fade");
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    IEnumerator fade()
    {
        yield return new WaitForSeconds(5f);

        anim.SetBool("oii", true);

        cen.LoadScene("Espaço");




    }
}
