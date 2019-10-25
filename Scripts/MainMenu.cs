using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource menuAudio;

    void Start()
    {
       // PlayerPrefs.DeleteAll();
        if (!PlayerPrefs.HasKey("HighScore"))
            PlayerPrefs.SetInt("HighScore", 0);
    }

    public void Play()
    {
        SceneManager.LoadScene("CharacterSelection");
        menuAudio.Play();
    }
}
