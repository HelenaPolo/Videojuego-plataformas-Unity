using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Cat : MonoBehaviour
{

    private GameObject player2D;
    private float distanceToPlayer2D;
    private int currentEnemyLife;
    private int minEnemyLife;
    private int maxEnemyLife;
    private float speed;

    private void Awake()
    {
        player2D = (GameObject)GameObject.Find("Player2D");

    }

    void Start()
    {
       	currentEnemyLife = 3;
        minEnemyLife = 0;
        maxEnemyLife = 3;
        speed = 3.0f;
    }


    //ANIMACIONES Y SEGUIMIENTO PLAYER
    void Update()
    {
        distanceToPlayer2D = Vector2.Distance(player2D.gameObject.GetComponent<Transform>().position, this.gameObject.GetComponent<Transform>().position);
        this.gameObject.GetComponent<Animator>().SetFloat("Distance", distanceToPlayer2D);

        if (distanceToPlayer2D >= 3.0f && distanceToPlayer2D <= 15.0f)
        {
            this.gameObject.GetComponent<Animator>().SetFloat("Distance", distanceToPlayer2D);
            //this.gameObject.GetComponent<Animator>().SetBool("Walk_Enemy", true);
            this.gameObject.GetComponent<Transform>().position = Vector2.MoveTowards(this.gameObject.GetComponent<Transform>().position, player2D.gameObject.GetComponent<Transform>().position, speed * Time.deltaTime);
            Debug.Log("Lejos");


            //Enemy_Cat se gira con el player para seguirle
            if(player2D.gameObject.GetComponent<Transform>().position.x > this.gameObject.GetComponent<Transform>().position.x)
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }


        }

        //Debug.Log(distanceToPlayer2D);
    }



    //DAÑO Y MUERTE

    private void OnTriggerEnter2D (Collider2D other)  
    {
        if (other.gameObject.tag == "BulletPlayer2D" || other.gameObject.tag == "GranadePlayer2D")
        {
            currentEnemyLife = currentEnemyLife-1;
            this.gameObject.GetComponent<Transform>().GetChild(0).gameObject.GetComponent<TextMesh>().text = currentEnemyLife + "/" + maxEnemyLife;
            Destroy(other.gameObject);

            if(currentEnemyLife == minEnemyLife)
            {
                this.gameObject.GetComponent<Animator>().SetTrigger("Enemy_Dead");
                Destroy(this.gameObject, 1.5f);
                General.enemyDead = true;
            }
        }
    }


}
