using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private GameManager gameManager;

    private Rigidbody ballRb;
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        ballRb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            gameManager.ballCollidedWithWall = true;
            // Destroy(gameObject);
            // Instead of destroying make these objects stick onto wall:
            ballRb.isKinematic = true;
        }
        
        
    }

    


}
