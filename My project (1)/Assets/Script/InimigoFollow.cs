using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoFollow : MonoBehaviour
{
    [SerializeField] GameObject player;
    Vector3 distancia;
    [SerializeField] float followSpeed;
    private Animator Mov;
    public GameObject oi;
    public float distance;
    public float AreaDeSeguir;
    

    // Start is called before the first frame update
    void Start()
    {
        Mov = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distancia = player.transform.position - transform.position;

        if (distance<= AreaDeSeguir)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, followSpeed * Time.deltaTime);
            Mov.SetBool("Mov", true);

        }
        else
        {
            Mov.SetBool("Mov", false);
        }
    }
}
