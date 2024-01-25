using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spiral : MonoBehaviour
{
    public float rot;


    void Start()
    {
        rot = 100.0f; 
    }

  
    void Update()
    {
        this.gameObject.GetComponent<Transform>().Rotate(0.0f, 0.0f, rot * Time.deltaTime);
    }
}
