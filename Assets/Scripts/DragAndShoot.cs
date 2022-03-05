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
    public AudioClip ballShootSound;
    private Rigidbody rb;

    private bool isShooted;

    public float forceMultiplier = 3;

    // Start is called before the first frame update
    void Start()
    {
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
    }

    void Shoot(Vector3 force)
    {
        if (isShooted)
        {
            return;
        }
        audioSource.PlayOneShot(ballShootSound, 1);
        rb.AddForce(new Vector3(force.x, force.y, force.y) * forceMultiplier);
        isShooted = true;
    }
}
