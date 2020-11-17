using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    public Text t;
    int score = 0;
    private void Start()
    {
        score = ScoreScript.setScore();
        t.text = "Score: " + score;
    }
}
