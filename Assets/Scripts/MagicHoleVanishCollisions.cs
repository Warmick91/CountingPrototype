using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicHoleVanishCollisions : MonoBehaviour
{
    private MagicHat magicHatScript;
    // Start is called before the first frame update
    void Start()
    {
        magicHatScript = GetComponentInParent<MagicHat>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Ball"))
        {
            /*HandleVanishCollision() is a private method so we're sending a message to the parent with a request to call the method.
            The third parameter makes sure the message is only sent to those parents which can receive it at all, AKA have the method with
            the given name.*/
            magicHatScript.SendMessageUpwards("HandleVanishCollision", collider, SendMessageOptions.RequireReceiver);
        }
    }
}
