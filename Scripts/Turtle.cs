using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Turtle : MonoBehaviour
{
    private Vector2 screenBounds;
    public Rigidbody2D rb;
    public float moveSpeed = 6;
    public float flapHeight = 5;
    public AudioSource jumpAudio;
    public AudioSource hurtAudio;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }


    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -screenBounds.x, screenBounds.x), Mathf.Clamp(transform.position.y, -screenBounds.y * 2, screenBounds.y - 1.1f));
        rb.velocity = new Vector2(0f, rb.velocity.y);
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = new Vector2(0f, flapHeight);
            jumpAudio.Play();
        }

        if (transform.position.y < -6)
        {
            Death();
            hurtAudio.Play();
        }
    }

    public void Death()
    {
        int currentScore = Score.scoreValue;
        int first = PlayerPrefs.GetInt("First", 0);
        int second = PlayerPrefs.GetInt("Second", 0);
        int third = PlayerPrefs.GetInt("Third", 0);
        if(currentScore >= first)
        {
            PlayerPrefs.SetInt("First", currentScore);
            PlayerPrefs.SetInt("Second", first);
            PlayerPrefs.SetInt("Third", second);
        }else if(currentScore >= second)
        {
            PlayerPrefs.SetInt("Second", currentScore);
            PlayerPrefs.SetInt("Third", second);
        }else if(currentScore >= third) 
        {
            PlayerPrefs.SetInt("Third", currentScore);
        }
        Score.scoreValue = 0;
        SceneManager.LoadScene("Main Menu");
    }
}
