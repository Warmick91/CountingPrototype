using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text CounterText;

    private static int Count = 0;

    private void Start()
    {
        Count = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Count += 1;

            UpdateCounterText();
            //Debug.Log("A ball fell into the hat. The count: " + Count);
        }
    }

    private void UpdateCounterText()
    {
        if (CounterText != null)
        {
            CounterText.text = "Count : " + Count;
        }
        else
        {
            Debug.Log("No CounterText assigned");
        }
    }


    private void OnDisable()
    {
        Reset();
    }

    private void Reset()
    {
        Count = 0;
    }
}
