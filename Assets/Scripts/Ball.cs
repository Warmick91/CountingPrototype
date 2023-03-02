using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ball : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] List<AudioClip> collisionSounds;
    [SerializeField] AudioClip magicPoofSound;

    void Awake()
    {
        audioSource = GameObject.Find("AudioManager").GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Hole"))
        {
            try
            {
                Destroy(gameObject);
                audioSource.PlayOneShot(magicPoofSound);
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Ball hit an obstacle");
            try
            {
                int randomIndex = UnityEngine.Random.Range(0, collisionSounds.Count);
                audioSource.PlayOneShot(collisionSounds[randomIndex]);
            }
            catch (ArgumentOutOfRangeException aoore)
            {
                Debug.Log(aoore.Message);
            }

        }
    }

}
