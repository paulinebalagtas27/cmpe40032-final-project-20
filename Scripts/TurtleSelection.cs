using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurtleSelection : MonoBehaviour
{
    private GameObject[] turtleList;
    private int index;
    public AudioSource selectAudio;
    public AudioSource selectionAudio;
    private void Start()
    {
        index = PlayerPrefs.GetInt("TurtleSelected", 0);
        turtleList = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            turtleList[i] = transform.GetChild(i).gameObject;
        }

        foreach (GameObject go in turtleList)
        {
            go.SetActive(false);
        }

        if (turtleList[index])
            turtleList[index].SetActive(true);
        selectionAudio.Play();
    }

    public void ToggleLeft()
    {
        turtleList[index].SetActive(false);

        index--;
        if (index < 0)
        {
            index = turtleList.Length - 1;
        }

        PlayerPrefs.SetInt("TurtleSelected", index);
        turtleList[index].SetActive(true);
        selectAudio.Play();
    }

    public void ToggleRight()
    {
        turtleList[index].SetActive(false);

        index++;
        if (index > turtleList.Length - 1)
        {
            index = 0;
        }
        PlayerPrefs.SetInt("TurtleSelected", index);
        turtleList[index].SetActive(true);
        selectAudio.Play();
    }

    public void Confirm()
    {
        PlayerPrefs.SetInt("TurtleSelected", index);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        selectAudio.Play();
    }
    
}
