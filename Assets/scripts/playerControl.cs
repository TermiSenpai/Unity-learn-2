using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    public float jumpForce = 10.0f;
    public float gravityModifier = 5.0f;
    private Rigidbody playerRB;
    public bool playerInFloor = true;
    public bool gameOver = false;
    private Animator playerAnim;


    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space) && playerInFloor == true)
            {
                playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                playerInFloor = false;
                playerAnim.SetTrigger("Jump_trig");
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            playerInFloor = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game over");
            gameOver = true;
            playerAnim.speed = 0;
            playerAnim.SetTrigger("Death_b");
        }
    }

}
