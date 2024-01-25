using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mini_Platform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            this.gameObject.AddComponent<Rigidbody2D>();
            Destroy(this.gameObject, 1.0f);
        }
    }
}
