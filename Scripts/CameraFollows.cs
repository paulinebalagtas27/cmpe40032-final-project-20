using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollows : MonoBehaviour
{
    public Transform player;
    public GameObject ring;
    public GameObject toxicUp;
    public GameObject toxicDown;
    private float respawnTime = 2.7f;
    private float respawnTimeR = 2.0f;
    private Vector2 screenBounds;
    private int randomNumber;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(enemyWave());
    }

    void Update()
    {
        transform.position = new Vector3(player.position.x + 6, 0, -10); // Camera follows the player but 6 to the right
    }

    IEnumerator enemyWave()
    {
        int counter = 1;
        while (true)
        {
            if (counter <= 10 || counter > 20)
            {
                randomNumber = Random.Range(0, 50);
                spawnRing();
                yield return new WaitForSeconds(respawnTimeR);
                counter++;
            }
            if (counter >= 11)
            {
                randomNumber = Random.Range(0, 50);
                spawnToxic();
                yield return new WaitForSeconds(respawnTime);
                counter++;
            }
        }
    }

    private void spawnRing()
    {
        GameObject a = Instantiate(ring) as GameObject;
        a.transform.position = new Vector2(screenBounds.x * 2, Random.Range(-screenBounds.y * 2 / 5, screenBounds.y * 2 / 5));
    }

    public void spawnToxic()
    {
        if (randomNumber <= 10)
        {
            Instantiate(toxicUp, new Vector3(screenBounds.x * 2, 5f), transform.rotation);
            Instantiate(toxicDown, new Vector3(screenBounds.x * 2, -7f), transform.rotation);
        }
        else if (randomNumber > 10 && randomNumber <= 20)
        {
            Instantiate(toxicUp, new Vector3(screenBounds.x * 1.7f, 6f), transform.rotation);
            Instantiate(toxicDown, new Vector3(screenBounds.x * 1.7f, -6f), transform.rotation);
        }
        else if (randomNumber > 20 && randomNumber <= 30)
        {
            Instantiate(toxicUp, new Vector3(screenBounds.x * 1.9f, 5f), transform.rotation);
            Instantiate(toxicDown, new Vector3(screenBounds.x * 1.9f, -8f), transform.rotation);
        }
        else if (randomNumber > 30 && randomNumber <= 40)
        {
            Instantiate(toxicUp, new Vector3(screenBounds.x * 1.8f, 7f), transform.rotation);
            Instantiate(toxicDown, new Vector3(screenBounds.x * 1.8f, -6f), transform.rotation);
        }
        else if (randomNumber > 40 && randomNumber <= 50)
        {
            Instantiate(toxicUp, new Vector3(screenBounds.x * 2, 8f), transform.rotation);
            Instantiate(toxicDown, new Vector3(screenBounds.x * 2, -5f), transform.rotation);
        }
        else if (randomNumber > 50)
        {
            Instantiate(toxicUp, new Vector3(screenBounds.x * 1.6f, 7f), transform.rotation);
            Instantiate(toxicDown, new Vector3(screenBounds.x * 21.6f, -5f), transform.rotation);
        }
    }
}
