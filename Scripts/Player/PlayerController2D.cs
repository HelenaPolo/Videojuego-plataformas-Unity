using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController2D : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float shootForce;
    public float granadeForceX;
    public float granadeForceY;
    public float horizontal;
    public float jumpingZoneForce;

    private bool isJumping;
    private bool isBlocked;
    private float attackRate;
    private float nextAttack;

    public GameObject energyCounter;
    public GameObject uiCandy;
    public GameObject uiLifes;
    public GameObject uiGranades;

    public GameObject bulletPlayer2D;
    private GameObject bulletPlayer2DClon;
    public GameObject creatorBulletRight;
    public GameObject creatorBulletLeft;

    public GameObject granadePlayer2D;
    private GameObject granadePlayer2DClon;
    public GameObject creatorGranade;

    public GameObject lifeSound;
    public GameObject bombSound;
    public GameObject candySound;
    public GameObject jumpingZoneSound;
    public GameObject energySound;
    public GameObject jumpSound;
    public GameObject granadeSound;
    public GameObject shootSound;
    public GameObject noBulletsSound;

    public GameObject victoryPanel;
    public GameObject losePanel;

    public GameObject cupcake1;
    public GameObject cupcake2;
    public GameObject cupcake3;

    private int numCupcakeWon;


    private void Start()
    {
        isJumping = false;
        speed = 5.0f;
        jumpForce = 10.0f;
        attackRate = 1.0f;
        isBlocked = false;
        numCupcakeWon = 0;

    }

    private void FixedUpdate()
    {
        //SALTO
        if (!isJumping && Input.GetKeyDown(KeyCode.Space)) 
        {
            isJumping = true;
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, jumpForce);
            this.gameObject.GetComponent<Transform>().GetChild(0).gameObject.GetComponent<Animator>().SetBool("jump", true);
            jumpSound.gameObject.GetComponent<AudioSource>().Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        //PLATAFORMAS
        if (other.gameObject.tag == "Platform") 
        {
            isJumping = false;
            this.gameObject.GetComponent<Transform>().GetChild(0).gameObject.GetComponent<Animator>().SetBool("jump", false);

        }

        //PLATAFORMA MUELLE
        if (other.gameObject.tag == "JumpingZone") 
        {
            jumpingZoneSound.gameObject.GetComponent<AudioSource>().Play();
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, jumpingZoneForce);
        }

        if (other.gameObject.tag == "Energy") //ESTRELLAS = MUNICION
        { 
            energySound.gameObject.GetComponent<AudioSource>().Play();
            General.currentStars++;
            energyCounter.gameObject.GetComponent<Slider>().value = General.currentStars;
            Destroy(other.gameObject);

        }

        //PALITOS CARAMELO = GRANADAS
        if (other.gameObject.tag == "Add_Granade") 
        {
            energySound.gameObject.GetComponent<AudioSource>().Play();
            if (General.currentGranades < General.maxGranades)
            {
                General.currentGranades++;
                uiGranades.gameObject.GetComponent<Text>().text = General.currentGranades.ToString();
            }
            else
            {
                General.currentGranades = General.maxGranades;
            }
            Destroy(other.gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        //CARAMELOS COLECCIONABLES
        if (other.gameObject.tag == "Sweets") 
        {
            candySound.gameObject.GetComponent<AudioSource>().Play();
            General.numCandy++;
            uiCandy.gameObject.GetComponent<Text>().text = General.numCandy.ToString();
            Destroy(other.gameObject);

        }

        //DAÑO ENEMIGO Y HUEVOS BOMBA
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Egg_Bullet") 
        {
            if (!isBlocked)
            {
                General.currentLifes = General.currentLifes -1;
                uiLifes.gameObject.GetComponent<Text>().text = General.currentLifes.ToString();


				if(General.currentLifes <= General.minLifes)
                {
					uiLifes.gameObject.GetComponent<Text>().text = "0";

					General.isDie = true;
                    this.gameObject.GetComponent<Transform>().GetChild(0).gameObject.GetComponent<Animator>().SetTrigger("Die");      
                    losePanel.SetActive(true);

					Debug.Log("currentLifes "+ General.currentLifes.ToString() + " minLifes "+ General.minLifes.ToString()); 
                }
             }
        }


        //LOLLYPOPS = VIDA
        if (other.gameObject.tag == "AddLife") 
        {
            lifeSound.gameObject.GetComponent<AudioSource>().Play();
            if (General.currentLifes < General.maxLifes)
            {
                General.currentLifes++;
                uiLifes.gameObject.GetComponent<Text>().text = General.currentLifes.ToString();

            }
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "LimitPlayerDown" || other.gameObject.name == "LimitPlayerUp") //MARGENES VERTICALES
        {
            losePanel.SetActive(true);
            General.isDie = true;
        }


        //FIN PANTALLA + LOGROS
        if (other.gameObject.name == "EndGame" && General.enemyDead) 
        {
			victoryPanel.SetActive(true);
			Destroy(this.gameObject);

            if (General.min < 2)
            {
                numCupcakeWon += 1;
            }
            if(General.currentLifes >= General.maxLifes)
            {
                numCupcakeWon += 1;
            }
            if (General.currentLevel==1 && General.numCandyLevel1 == 3)
            {
                numCupcakeWon += 1;
            }
            if (numCupcakeWon == 1)
            {
                cupcake1.gameObject.SetActive(true);
            }
            if (numCupcakeWon == 2)
            {
                cupcake1.gameObject.SetActive(true);
                cupcake2.gameObject.SetActive(true);

            }
            if (numCupcakeWon == 3)
            {
                cupcake1.gameObject.SetActive(true);
                cupcake2.gameObject.SetActive(true);
                cupcake3.gameObject.SetActive(true);

            }
				
			if(victoryPanel)
			{
				General.currentLevel = General.currentLevel+1;
			}
		}
    }
   


    private void Update()
    {

        //MOVIMIENTO PLAYER

        horizontal = speed * Time.deltaTime * Input.GetAxis("Horizontal");
        this.gameObject.GetComponent<Transform>().Translate(horizontal, 0.0f, 0.0f);

        this.gameObject.GetComponent<Transform>().GetChild(0).gameObject.GetComponent<Animator>().SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal")));


        if (Input.GetAxis("Horizontal") > 0.0f)
        {
            this.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().flipX = false;
			this.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().flipX = false;
           
        }
        else if (Input.GetAxis("Horizontal") < 0.0f)
        {
            this.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().flipX = true;
			this.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().flipX = true;

        }


        //DISPARO MAGIC WAND
        if (Input.GetMouseButtonDown(0) && Time.time > nextAttack) 
        {

            if (General.currentStars > General.minStars)
            {
                this.gameObject.GetComponent<Transform>().GetChild(0).gameObject.GetComponent<Animator>().SetTrigger("attackShoot");

                Invoke("Shoot", 0.6f);
                nextAttack = Time.time + attackRate;

            }
            else
            {
                noBulletsSound.gameObject.GetComponent<AudioSource>().Play();
            }

        }


        //DISPARO GRANADA
        if (Input.GetMouseButtonDown(1) && Time.time> nextAttack) 
        {
            if (General.currentGranades > General.minGranades)
            {
                this.gameObject.GetComponent<Transform>().GetChild(0).gameObject.GetComponent<Animator>().SetTrigger("attackBomb");
                Invoke("Granada", 0.5f);
                nextAttack = Time.time + attackRate;

            }
            else
            {
                noBulletsSound.gameObject.GetComponent<AudioSource>().Play();
            }
        }

        if (Input.GetMouseButtonDown(2)) //DEFENSA
        {
            this.gameObject.GetComponent<Transform>().GetChild(0).gameObject.GetComponent<Animator>().SetTrigger("Defense");
            isBlocked = true;
            Invoke("NoBlocked",0.5f);
        }

    }


    //DISPARO Y NUMERO GRANADAS
    private void Granada() 
    {
        if (this.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().flipX)
        {

            granadePlayer2DClon = (GameObject)Instantiate(granadePlayer2D, creatorGranade.gameObject.transform.position, Quaternion.identity);
            granadePlayer2DClon.name = "GranadePlayer2D";
            granadePlayer2DClon.tag = "GranadePlayer2D";
            granadePlayer2DClon.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-granadeForceX, granadeForceY);
            Destroy(granadePlayer2DClon.gameObject, 3.0f);
            General.currentGranades--;
            uiGranades.gameObject.GetComponent<Text>().text = General.currentGranades.ToString();
        }
        else
        {
            granadePlayer2DClon = (GameObject)Instantiate(granadePlayer2D, creatorGranade.gameObject.transform.position, Quaternion.identity);
            granadePlayer2DClon.name = "GranadePlayer2D";
            granadePlayer2DClon.tag = "GranadePlayer2D";
            granadePlayer2DClon.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(granadeForceX, granadeForceY);
            Destroy(granadePlayer2DClon.gameObject, 3.0f);
            General.currentGranades--;
            uiGranades.gameObject.GetComponent<Text>().text = General.currentGranades.ToString();
        }
        granadeSound.gameObject.GetComponent<AudioSource>().Play();


    }


    //DISPARO Y NUMERO MAGIC WAND
    private void Shoot() 
    {
        if (this.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().flipX)
        {
            bulletPlayer2DClon = (GameObject)Instantiate(bulletPlayer2D, creatorBulletLeft.gameObject.transform.position, Quaternion.identity);
            bulletPlayer2DClon.name = "BulletPlayer2D";
            bulletPlayer2DClon.tag = "BulletPlayer2D";
            bulletPlayer2DClon.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-shootForce, 0.0f);
            Destroy(bulletPlayer2DClon.gameObject, 3.0f);
            General.currentStars--;
            energyCounter.gameObject.GetComponent<Slider>().value = General.currentStars;
        }
        else
        {
            bulletPlayer2DClon = (GameObject)Instantiate(bulletPlayer2D, creatorBulletRight.gameObject.transform.position, Quaternion.identity);
            bulletPlayer2DClon.name = "BulletPlayer2D";
            bulletPlayer2DClon.tag = "BulletPlayer2D";
            bulletPlayer2DClon.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(shootForce, 0.0f);
            Destroy(bulletPlayer2DClon.gameObject, 3.0f);
            General.currentStars--;
            energyCounter.gameObject.GetComponent<Slider>().value = General.currentStars;

        }

        shootSound.gameObject.GetComponent<AudioSource>().Play();
    }


    //DAÑO PLAYER
    public void HitPlayer(int hitForce)
    {
       

        General.currentLifes = General.currentLifes - hitForce;
        uiLifes.gameObject.GetComponent<Text>().text = General.currentLifes.ToString();

        if(!this.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().flipX)
        {
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2( -6.0f, 0.0f);
        }
        else{
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(6.0f,0.0f);
        }
    }

    //QUITAR DEFENSA
    public void NoBlocked() 
    {
        isBlocked = false;
    }


}