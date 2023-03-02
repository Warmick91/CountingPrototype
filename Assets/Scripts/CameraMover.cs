using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public float cameraSpeed = 10.0f;
    private float leftCamBoundY = 42.0f;
    private float rightCamBoundY = 1.0f;

    private bool rotateLeft = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        if (rotateLeft)
        {
            if (transform.rotation.eulerAngles.y <= leftCamBoundY) transform.Rotate(new Vector3(0, 1, 0) * cameraSpeed * Time.deltaTime);
            else rotateLeft = false;
        }
        else
        {
            if (transform.rotation.eulerAngles.y >= rightCamBoundY)
            {
                transform.Rotate(new Vector3(0, 1, 0) * -cameraSpeed * Time.deltaTime);
                Debug.Log(transform.rotation.eulerAngles.y);
            }
            else rotateLeft = true;
        }
    }
}
