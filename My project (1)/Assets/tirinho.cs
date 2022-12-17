using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tirinho : MonoBehaviour
{
   
    public float speed;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3f);
        
    }

    // Update is called once per frame
    void Update()
    {
         transform.Translate(Vector3.forward * speed * Time.deltaTime);
        
    }


    private void OnTriggerEnter(Collider other)
    {     
            if (other.gameObject.tag == "torre")
            {
                Destroy(gameObject, 0.1f);
                Destroy(this.gameObject);
            }
            if (other.gameObject.tag == "Aranha")
            {
                Destroy(gameObject);
                Destroy(other.gameObject);
            }
    }

}
