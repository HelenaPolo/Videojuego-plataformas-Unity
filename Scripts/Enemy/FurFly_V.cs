using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurFly_V : MonoBehaviour
{

    public float speedEnemy;
    public bool upEnemy;
   
    void Start()
    {
        upEnemy = true;
        speedEnemy = 5.0f;
    }

   
    void Update()
    {

        if (upEnemy == false)
        {
            transform.Translate(Vector3.down * speedEnemy * Time.deltaTime);
            if (transform.position.y < -12.50f)
            {
                upEnemy = true;
            }
        }
        else if (upEnemy == true)
        {
            transform.Translate(Vector3.up * speedEnemy * Time.deltaTime);
            if (transform.position.y > -2.50f)
            {
                upEnemy = false;
            }
        }
    }
}
































