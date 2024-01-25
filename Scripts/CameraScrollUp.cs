using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScrollUp : MonoBehaviour
{
    public GameObject player;

   
    void Update()
    {
        transform.position = new Vector2(transform.position.x, player.transform.position.y);

    }
}




























