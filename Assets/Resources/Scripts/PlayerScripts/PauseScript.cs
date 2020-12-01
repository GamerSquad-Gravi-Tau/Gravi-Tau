using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public static bool paused = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            paused = !paused;

        if(paused){
            Time.timeScale=0;
        }else{
            Time.timeScale=1;
        }

    }
}
