using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer2D : MonoBehaviour
{
  
    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Platform")
        {
            Destroy(this.gameObject);
        }
    }
}
