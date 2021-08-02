using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleMovement : MonoBehaviour
{
    private playerControl playerControlScript;
    public float movementSpeed = 20.0f;
    // Start is called before the first frame update
    void Start()
    {
        playerControlScript = GameObject.Find("Player").GetComponent<playerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControlScript.gameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * movementSpeed);
            movementSpeed = Random.Range(20, 25);
        }
    }
}
