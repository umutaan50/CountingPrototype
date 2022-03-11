using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BallController : MonoBehaviour
{
    // 10. sınıfta yaptığı oyunun sunumu

    // Bilgimin %90'ını YouTube'a borçluyum YouTube mükemmel bir şeydir dedi. Bu arada arkada Bilg. Müh olacam oyun yapacam.
    private GameManager gameManager;
    private GameObject lifeImage1;
    private GameObject lifeImage2;
    private GameObject lifeImage3;
    private GameObject lifeImage4;
    private GameObject lifeImage5;
    public bool isMouseHere = false;
    // private Rigidbody ballRb;



    // Generate random number

    void Start()
    {
        lifeImage1 = GameObject.Find("Ball Image 1");
        lifeImage2 = GameObject.Find("Ball Image 2");
        lifeImage3 = GameObject.Find("Ball Image 3");
        lifeImage4 = GameObject.Find("Ball Image 4");
        lifeImage5 = GameObject.Find("Ball Image 5");
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        // ballRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // When player misses the target:
        if (transform.position.x > 70 || transform.position.x < -70 || transform.position.y > 17 || transform.position.z > 26)
        {
            if (gameManager.life > 0)
            {

                LifeRemoval();
                // When there was an exlamation point before the statement above editor crashed...
            }
        }


    }

    public void LifeRemoval() {

        gameManager.life--;
        if (lifeImage5 != null)
        {
            lifeImage5.SetActive(false);
            gameManager.GetComponent<AudioSource>().PlayOneShot(gameManager.missSfx1, 1);
        }
        else if (lifeImage4 != null)
        {
            lifeImage4.SetActive(false);
            gameManager.GetComponent<AudioSource>().PlayOneShot(gameManager.missSfx2, 1);
        }
        else if (lifeImage3 != null)
        {
            lifeImage3.SetActive(false);
            gameManager.GetComponent<AudioSource>().PlayOneShot(gameManager.missSfx3, 1);
        }
        else if (lifeImage2 != null)
        {
            lifeImage2.SetActive(false);
            gameManager.GetComponent<AudioSource>().PlayOneShot(gameManager.missSfx4, 1);
        }
        else if (lifeImage1 != null)
        {
            lifeImage1.SetActive(false);
            gameManager.GetComponent<AudioSource>().PlayOneShot(gameManager.missSfx5, 1);
        }
        gameManager.spawnNeeded = true;
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Clock"))
        {
            gameManager.GetComponent<AudioSource>().PlayOneShot(gameManager.clockTriggerSound, 1);
            Destroy(other.gameObject);
            gameManager.time += 5;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        // Level 1
        if (gameManager.currentLevel == 1)
        {

            WallOne wallOne = GameObject.Find("Main Wall").GetComponent<WallOne>();
            if (collision.gameObject.CompareTag("Wall"))
            {
                gameManager.spawnNeeded = true;
                Destroy(gameObject);
                wallOne.SetHealth(-1);
            }
            else if (collision.gameObject.CompareTag("Wall Cylinder"))
            {
                gameManager.spawnNeeded = true;
                Destroy(gameObject);
                wallOne.SetHealth(-3);
                gameManager.time += 5;
            }
        }

        // Level 2
        else if (gameManager.currentLevel == 2)
        {
            WallTwo wallTwo = GameObject.Find("Second Cylinder").GetComponent<WallTwo>();
            if (collision.gameObject.CompareTag("Wall"))
            {
                gameManager.spawnNeeded = true;
                Destroy(gameObject);
                wallTwo.SetHealth(-3);
                gameManager.time += 5;

            }
            else if (collision.gameObject.CompareTag("Wall Cylinder"))
            {
                gameManager.spawnNeeded = true;
                Destroy(gameObject);
                wallTwo.SetHealth(-1);
            }
        }


        // Level 3
        else if (gameManager.currentLevel == 3)
        {
            WallThree wallThree = GameObject.Find("Third Wall").GetComponent<WallThree>();
            if (collision.gameObject.CompareTag("Wall"))
            {
                gameManager.spawnNeeded = true;
                Destroy(gameObject);
                wallThree.SetHealth(-1);

            }
            else if (collision.gameObject.CompareTag("Wall Cylinder"))
            {
                gameManager.spawnNeeded = true;
                Destroy(gameObject);
                wallThree.SetHealth(-3);
                gameManager.time += 5;
            }
        }

        //void OnMouseEnter()
        //{
        //    Debug.Log("Aha fare!");
        //    isMouseHere = true;
        //}

        //void OnMouseExit()
        //{
        //    isMouseHere = false;
        //    Debug.Log("Fare kaçtı!");
        //}

        //void OnPointerEnter(PointerEventData eventData)
        //{
        //    Debug.Log("here");
        //    isMouseHere = true;
        //}
        //void OnPointerExit(PointerEventData eventData)
        //{
        //    isMouseHere = false;
        //}


    }

    // Format Document: Ctrl+K, Ctrl+D

    // I spend many hours to smoothly achive sticking ball on the wall mechanic but I changed it later.
    // Here are the previous mechanic's codes:

    // Instead of destroying make these objects stick onto wall:
    //ballRb.isKinematic = true;
    //gameObject.transform.SetParent(GameObject.Find("Empty Child").transform);
    //GetComponent<DragAndShoot>().audioSource.PlayOneShot(GetComponent<DragAndShoot>().stickSound, 1);




}
