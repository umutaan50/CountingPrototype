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
    public bool isMouseHere = false;
    private Rigidbody ballRb;
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        ballRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (transform.position.x > 70 || transform.position.x < -70 || transform.position.y > 17 || transform.position.z > 26)
        {
            gameManager.spawnNeeded = true;
            Destroy(gameObject);

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

            }
            if (collision.gameObject.CompareTag("Wall"))
            {

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
            }
        }

        void OnMouseEnter()
        {
            Debug.Log("Aha fare!");
            isMouseHere = true;
        }

        void OnMouseExit()
        {
            isMouseHere = false;
            Debug.Log("Fare kaçtı!");
        }

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
