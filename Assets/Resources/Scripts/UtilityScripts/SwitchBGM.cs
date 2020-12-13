using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBGM : MonoBehaviour
{
    private int BGM = 3;

    public GameObject BGM_One;
    public GameObject BGM_Two;
    public GameObject BGM_Three;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchByClick()
    {
        BGM++;
        if (BGM == 4)
        {
            BGM = 1;
        }

        if (BGM == 1)
        {
            BGM_One.SetActive(true);
            BGM_Two.SetActive(false);
            BGM_Three.SetActive(false);
        }

        if (BGM == 2)
        {
            BGM_One.SetActive(false);
            BGM_Two.SetActive(true);
            BGM_Three.SetActive(false);
        }

        if (BGM == 3)
        {
            BGM_One.SetActive(false);
            BGM_Two.SetActive(false);
            BGM_Three.SetActive(true);
        }
    }
}
