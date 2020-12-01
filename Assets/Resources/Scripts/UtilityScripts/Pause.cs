using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

   public static bool paused;
   public GameObject UI;

    private void Start()
    {
        paused = false;
        Resume();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                Resume();
            }
            else
            {
                Stop();
            }
        }
    }

    void Stop()
    {
        UI.SetActive(true);
        PauseScript.paused = true;
        paused = true;
    }

    public void Resume()
    {
        UI.SetActive(false);
        PauseScript.paused = false;
        paused = false;
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }
}
