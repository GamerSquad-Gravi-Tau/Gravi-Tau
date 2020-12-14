using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropMessage : MonoBehaviour
{
    public Text message;
    public static string currentMessage;
    public static Color currentColor;
    public static float displayTime = 0f;
    public float messageTime = 4f;
    public static bool isDisplayed = false;
    // Start is called before the first frame update
    void Start()
    {
        currentMessage = "";
        message.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (isDisplayed) {
            message.text = currentMessage;
            message.color = currentColor;
            displayTime += Time.smoothDeltaTime;
            if (displayTime > messageTime) {
                displayTime = 0f;
                isDisplayed = false;
                message.text = "";
            }
        }
    }

    public static void setMessage(string newMessage, Color newColor) {
        displayTime = 0f;
        isDisplayed = true;
        currentMessage = newMessage;
        currentColor = newColor;
    }
}