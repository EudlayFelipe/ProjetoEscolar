using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CutSceneToScene2 : MonoBehaviour
{
    private Animator anim;
    // private float tempoEspera = 3f;
    public GameObject camCut;
    public Transform target;
    private void Start()
    {
        camCut.SetActive(false);
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
           camCut.SetActive(true);
           
           
           //transform.LookAt(target);
            anim.SetBool("Planet", anim);
        }
    }




}
