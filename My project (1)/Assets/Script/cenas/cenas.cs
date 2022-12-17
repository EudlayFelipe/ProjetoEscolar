    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cenas : MonoBehaviour
{

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        Cursor.visible = true;
        
    }

    /*private void Update()
    {
        if (Input.anyKeyDown)
        {
            Cursor.visible = false;

        }
    }*/

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);


    }
    public void LoadSceneAsy(int sceneID)
    {
        SceneManager.LoadSceneAsync(sceneID);

    }

    public void SairJogo()
    {
        Application.Quit();
    }
}
