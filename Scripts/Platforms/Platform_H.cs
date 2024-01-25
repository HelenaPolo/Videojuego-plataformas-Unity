using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_H : MonoBehaviour
{

    private float horizontalSpeed;


    void Start()
    {
        horizontalSpeed = 3.0f;
    }

   
    void Update()
    {
        this.gameObject.GetComponent<Transform>().Translate(horizontalSpeed * Time.deltaTime, 0.0f, 0.0f);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "LimitLeft")
        {
            horizontalSpeed = 3.0f;
        }
        if (other.gameObject.name == "LimitRight")
        {
            horizontalSpeed = -3.0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Transform>().SetParent(this.gameObject.GetComponent<Transform>());
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Transform>().SetParent(null);
        }
    }
}
