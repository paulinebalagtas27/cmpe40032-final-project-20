using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Third : MonoBehaviour
{
    public static int highScore = 0;
    Text score;
    // Use this for initialization
    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        highScore = PlayerPrefs.GetInt("Third", 0);
        score.text = highScore.ToString();
    }
}
