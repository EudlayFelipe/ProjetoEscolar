using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacaoPlaneta : MonoBehaviour
{
    public Vector3 axisRotate;
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(axisRotate * speed * Time.deltaTime);


    }
}
