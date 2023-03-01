using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Hole"))
        {
            try
            {
                Destroy(gameObject);
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }

        }
    }
}
