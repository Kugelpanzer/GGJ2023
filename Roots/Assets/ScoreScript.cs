using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI score;
    // Start is called before the first frame update
    void Start()
    {
        score.text = "SCORE: " + PlayerPrefs.GetInt("score") + "\n" + "HIGH SCORE: " + PlayerPrefs.GetInt("high_score");
    }


}
