using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private GameManager gameManager;
    private DragAndShoot dragAndShoot;
    public AudioClip ballStickSound;
    private AudioSource audioSource;

    private Rigidbody ballRb;
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        audioSource = GameObject.Find("Game Manager").GetComponent<AudioSource>();
        ballRb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (gameObject.transform.position.z > 28 || gameObject.transform.position.x < -19 || gameObject.transform.position.x > 20 || gameObject.transform.position.z < -5)
        {
            Destroy(gameObject);
            gameManager.shouldRespawnOne = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            gameManager.shouldRespawnOne = true;
            // Destroy(gameObject);
            // Instead of destroying make these objects stick onto wall:
            ballRb.isKinematic = true;
            audioSource.PlayOneShot(ballStickSound, 1);
            gameObject.transform.SetParent(collision.gameObject.transform);
        }
        
        
    }

    


}
