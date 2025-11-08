using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    public int score;
    public Text scoreDisplay;

    private void Update()
    {
        scoreDisplay.text = "Score: " + score.ToString();
    }
    public void Kill()
    {
        score++;
    }
}
