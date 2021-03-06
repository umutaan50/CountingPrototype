using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    // Küçüklükten merak.
    // Eskiden çok açık dosyalar. XML okumak. XML'i değiştirince oyunda değişiklik. Aaa demek böyle çalışıyor.
    // Çok basit şeyler: 4. 5. sınıf Esas madenini buldum oyunu değiştiriyorum.
    public GameManager gameManager;
    float speed = 15;
    bool rightMovement = true;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == "Second Cylinder")
        {
            speed += 5;
        }
        else if (gameObject.name == "Third Wall")
        {
            speed += 10;
        }
        
    }

    // There is a problem that when I add rigidbody onto wall if collision happens two balls are spawning instead of one.


    // You can shoot and upload a video about that.
    void Update()
    {
        if (!gameManager.isLost)
        {
            //  && !gameManager.isFinished
            if (rightMovement)
            {
                transform.Translate(Vector3.right * Time.deltaTime * speed);
                if (transform.position.x > 30)
                {
                    rightMovement = false;
                }
            }
            else if (rightMovement == false)
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);
                if (transform.position.x < -30)
                {
                    rightMovement = true;
                }
            }
        }
        
    }
}
