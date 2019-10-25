using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicDown : MonoBehaviour
{
    private Vector2 screenBounds;
    private Vector3 pos;
    private float speed = 6f;
    private Turtle babyTurtle;

    // Use this for initialization
    void Start()
    {
        babyTurtle = FindObjectOfType<Turtle>();
        pos = transform.position;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (transform.position.x < -screenBounds.x * 1.4)
        {
            Destroy(this.gameObject);
        }
    }
    void Move()
    {
        pos -= transform.right * Time.deltaTime * speed;
        transform.position = pos + transform.right;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            babyTurtle.Death();
        }
    }
}
