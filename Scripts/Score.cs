using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int scoreValue = 0;
    Text score;
    public AudioSource scoreAudio;

    // Use this for initialization
    void Start()
    {
        score = GetComponent<Text>();
        scoreAudio.Play();
     }

    // Update is called once per frame
    void Update()
    {
        score.text = " SCORE: " + scoreValue;
    }
}
