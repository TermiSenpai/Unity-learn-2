using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleSpawn : MonoBehaviour
{
    public float delay = 1.0f;
    public GameObject[] obstacleArray;
    int randomNumber;
    int obstaclePos;
    private playerControl playerControlScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControlScript = GameObject.Find("Player").GetComponent<playerControl>();
        Invoke("obstacleGenerator",delay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void obstacleGenerator()
    {
        if (!playerControlScript.gameOver)
        { 
        obstaclePos = randomGenerator(0, obstacleArray.Length);
        delay = randomGenerator(0, 5);
        Vector3 spawnPos = new Vector3(40, 0, 0);
        Instantiate (obstacleArray[obstaclePos], spawnPos, obstacleArray[obstaclePos].transform.rotation);
        Invoke("obstacleGenerator", delay);
        }
    }

    int randomGenerator(int min, int max)
    {
        return Random.Range(min, max);
    }
}
