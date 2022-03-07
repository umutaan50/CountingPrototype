using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Counter : MonoBehaviour
{
    public TextMeshProUGUI CounterText;

    private int Count = 0;

    private void Start()
    {
        Count = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        TextUpdate();
    }

    void TextUpdate()
    {
        Count += 1;
        CounterText.SetText("isabet: " + Count);
    }
}
