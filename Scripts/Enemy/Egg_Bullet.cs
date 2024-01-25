using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg_Bullet : MonoBehaviour
{

    public GameObject eggBullet;
    private GameObject eggBulletClon;
    public GameObject eggBulletCreator;

    void Start()
    {
        InvokeRepeating("CreateEgg", 0.0f, 3.0f);
    }

    public void CreateEgg()
    {
        eggBulletClon = (GameObject)Instantiate(eggBullet, eggBulletCreator.gameObject.transform.position, Quaternion.identity);
        eggBulletClon.name = "BulletPlayer2D";
        eggBulletClon.tag = "BulletPlayer2D";
        eggBulletClon.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, -5.0f);
        Destroy(eggBulletClon.gameObject, 2.0f);
   
       
    }

    void Update()
    {
        
    }
}
