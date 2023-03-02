using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Obstacle : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] List<AudioClip> collisionSounds;

    void Awake()
    {
        audioSource = GameObject.Find("AudioManager").GetComponent<AudioSource>();
    }

    void Start()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
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
