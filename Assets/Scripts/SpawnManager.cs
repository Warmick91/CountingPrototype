using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject ball;
    private const float rangeXZ = 5.0f;
    private const float rangeBottomY = 12.0f;
    private const float rangeTopY = 18.0f;
    private const float massSpawnDelay = 0.2f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Check if ONLY the space button is hit AND the shift button isn't being held, then spawn a single ball
        if (Input.GetKeyDown(KeyCode.Space) && !Input.GetKey(KeyCode.LeftShift))
        {
            spawnBall();
        }

        //Check if BOTH the space button AND the shift button are hit (or vice versa), then run an repeated invocation of the spawn method
        if ((Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Space)) || (Input.GetKey(KeyCode.Space) && Input.GetKeyDown(KeyCode.LeftShift)))
        {
            InvokeRepeating("spawnBall", 0f, 0.5f);
        }

        //Check if either the space button OR shift button are released, then stop the repeated invocation of the spawn method
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.LeftShift))
        {
            CancelInvoke("spawnBall");
        }
    }

    void spawnBall()
    {
        float randomX = Random.Range(-rangeXZ, rangeXZ);
        float randomY = Random.Range(rangeBottomY, rangeTopY);
        float randomZ = Random.Range(-rangeXZ, rangeXZ);

        Vector3 spawnLocation = new Vector3(randomX, randomY, randomZ);
        Instantiate(ball, spawnLocation, this.transform.rotation);
    }

}
