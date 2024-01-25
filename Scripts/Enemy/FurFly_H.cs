using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurFly_H : MonoBehaviour
{

    public float speedEnemy;
    public bool rightEnemy;
   
    void Start()
    {
        rightEnemy = true;
        speedEnemy = 3.0f;
    }

   
    void Update()
    {

        if (rightEnemy == false)
        {
            transform.Translate(Vector3.left * speedEnemy * Time.deltaTime);
            if (transform.position.x < 117.00f)
            {
                rightEnemy = true;
            }
        }
        else if (rightEnemy == true)
        {
            transform.Translate(Vector3.right * speedEnemy * Time.deltaTime);
            if (transform.position.x > 150.0f)
            {
                rightEnemy = false;
            }
        }
    }
}
































