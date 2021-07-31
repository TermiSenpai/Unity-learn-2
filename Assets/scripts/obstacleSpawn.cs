using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleSpawn : MonoBehaviour
{
    public float startDelay = 1.0f;
    public float repeatDelay = 3.0f;
    public GameObject[] obstacleArray;
     
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("obstacleGenerator",startDelay,repeatDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void obstacleGenerator()
    {
        Vector3 spawnPos = new Vector3(40, 0, 0);
        Instantiate (obstacleArray[0], spawnPos, obstacleArray[0].transform.rotation);
    }
}
