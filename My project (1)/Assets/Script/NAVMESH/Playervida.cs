using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Playervida : MonoBehaviour
{
    public int vida = 100;
    // Start is called before the first frame update
    void Awake()
    {
        transform.tag = "Player";
    }

    // Update is called once per frame
    void Update()
    {
        if (vida <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }  
    }
}
