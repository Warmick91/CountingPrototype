using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicHat : MonoBehaviour
{
    private Transform magicHoleObject;
    private ParticleSystem vanishParticles;
    private AudioSource audioSource;
    [SerializeField] AudioClip magicPoofSound;

    void Awake()
    {
        audioSource = GameObject.Find("AudioManager").GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        magicHoleObject = this.gameObject.transform.Find("MagicHole");
        vanishParticles = this.gameObject.transform.Find("VanishParticle").GetComponent<ParticleSystem>();
    }

    // The method used for handling collisions of balls with the MagicHole child element
    private void HandleVanishCollision(Collider collider)
    {
        Destroy(collider.gameObject);
        audioSource.PlayOneShot(magicPoofSound);
        vanishParticles.Play();
    }
}
