using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongratScript : MonoBehaviour
{
    public TextMesh Text;
    public ParticleSystem SparksParticles;
    
    private List<string> TextToDisplay;
    
    private float RotatingSpeed;
    private float TimeToNextText;

    private int CurrentText;


    void Start()
    {
        TextToDisplay = new List<string>();
        // I don't remember if I instantiated audioclips on my previous project... : /


        TimeToNextText = 0.0f;
        CurrentText = 0;

        RotatingSpeed = 1;

        TextToDisplay.Add("Congratulation");
        TextToDisplay.Add("All Errors Fixed");

        Debug.Log(TextToDisplay.IndexOf("Congratulation") + " " + TextToDisplay.IndexOf("All Errors Fixed"));
        Debug.Log(TextToDisplay.Count);

        Text.text = TextToDisplay[0];


        SparksParticles.Play();
    }

    private Vector3 textRotation;
    void Update()
    {

        gameObject.transform.RotateAround(textRotation, gameObject.transform.position, 2);

        Text.text = TextToDisplay[CurrentText];

        TimeToNextText += Time.deltaTime;

        if (TimeToNextText > 1.5f)
        {
            TimeToNextText = 0.0f;

            if (CurrentText == 0)
            {
                CurrentText++;
            }
            else if (CurrentText >= 1)
            {
                CurrentText--;
            
            }

            //int randomX = Random.Range(0, 3);
            //int randomY = Random.Range(0, 3);
            //int randomZ = Random.Range(0, 3);
            textRotation = new Vector3(0, 0, 0);

        }

        Debug.Log(TimeToNextText);
    }
}
            //while (TimeToNextText <= 0)
            //{

            //    gameObject.transform.Rotate(Vector3.forward * RotatingSpeed * 10);
            //    TimeToNextText += Time.deltaTime;
            //    Text.text = TextToDisplay[CurrentText];
            //}