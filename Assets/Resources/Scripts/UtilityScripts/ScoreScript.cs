using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int score;
    public Text t;
    private void Start()
    {
        score = 0;
    }
    private void Update()
    {
        t.text = "Score: " + score;
    }
    public static void IncScore(int s)
    {
        score += s;
    }

    public static int setScore()
    {
        return score;
    }
}
