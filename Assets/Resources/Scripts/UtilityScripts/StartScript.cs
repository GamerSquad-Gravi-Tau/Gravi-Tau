using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
   public void onClickStart()
    {
        SceneManager.LoadScene(1);
    }
    public void onClickSettings()
    {
        SceneManager.LoadScene(3);
    }

    public void onClickControls()
    {
        SceneManager.LoadScene(4);
    }

    private void Update()
    {
        if (Input.GetKeyDown("b"))
        {
            SceneManager.LoadScene(0);
        }
    }
    public void onClickQuit()
    {
        Application.Quit();
    }
}
