using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // 10. sınıfta yaptığı oyunun sunumu

    // Bilgimin %90'ını YouTube'a borçluyum YouTube mükemmel bir şeydir dedi. Bu arada arkada Bilg. Müh olacam oyun yapacam.
    private GameManager gameManager;
    

    private Rigidbody ballRb;
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        ballRb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (transform.position.x > 70 || transform.position.x < -70 || transform.position.y > 17 || transform.position.z > 26)
        {
            gameManager.spawnNeeded = true;
            Destroy(gameObject);
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            gameManager.spawnNeeded = true;
            // Destroy(gameObject);
            // Instead of destroying make these objects stick onto wall:
            ballRb.isKinematic = true;
            gameObject.transform.SetParent(GameObject.Find("Empty Child").transform);
            GetComponent<DragAndShoot>().audioSource.PlayOneShot(GetComponent<DragAndShoot>().stickSound, 1);
        }
        
        
    }

    


}
