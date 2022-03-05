using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    public Vector3 translation;

    public int moveSteps;
    // Start is called before the first frame update
    void Start()
    {
        translation = -transform.right;
        InvokeRepeating("Movement", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    public void Movement()
    {
        transform.Translate(translation);
    }
}
