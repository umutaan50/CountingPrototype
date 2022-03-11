using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]

public class DragAndShoot : MonoBehaviour
{
    /* TODO: Firstly I need to use github. After that I need to open the assets I want to use in an empty project.
     Always add gitignore.
     */
    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;
    private AudioSource audioSource;
    public AudioClip shootSound;
    public AudioClip stickSound;
    public AudioClip stickSoundCylinder;
    public BallController ballController;

    private GameManager gameManager;

    private Rigidbody rb;

    private bool isShooted;

    public float forceMultiplier = 7;

    // Start is called before the first frame update
    public Coroutine ballDestruction;

    void Start()
    {
        ballController = GetComponent<BallController>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        audioSource = GameObject.Find("Game Manager").GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        mousePressDownPos = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        mouseReleasePos = Input.mousePosition;
        Shoot(mousePressDownPos - mouseReleasePos);
        audioSource.PlayOneShot(shootSound, 1f);
    }

    void Shoot(Vector3 force)
    {
        forceMultiplier = 7;
        if (isShooted)
        {
            return;
        }

        rb.AddForce(new Vector3(force.x, force.y, force.y) * forceMultiplier);
        isShooted = true;
        ballDestruction = StartCoroutine(BallDestroySeconds());
    }

    IEnumerator BallDestroySeconds()
    {
        yield return new WaitForSeconds(3);
        gameManager.spawnNeeded = true;
        ballController.LifeRemoval();
        Destroy(gameObject);
    }

    // Küçük firmalar biz indieler, onları eksik yönlerinden vurmalıyız.
    // Senaryo. Küçük bir şirketken orasına zaman ayırıp orasından rekabet edebilirsiniz, dediler.

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            audioSource.PlayOneShot(stickSound, 1);
        }
        else if (collision.gameObject.CompareTag("Wall Cylinder"))
        {
            audioSource.PlayOneShot(stickSoundCylinder, 1);
        }
    }

}
