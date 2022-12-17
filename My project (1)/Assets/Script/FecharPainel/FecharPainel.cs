using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FecharPainel : MonoBehaviour
{
    public GameObject painel;
    bool active;
   public void OpenAndClose()
    {       
     gameObject.transform.gameObject.SetActive(false);
      active = false;     
    }
}
