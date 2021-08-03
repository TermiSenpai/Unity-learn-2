using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class playerControl : MonoBehaviour
{
    public float jumpForce = 10.0f;
    public float gravityModifier = 5.0f;
    private Rigidbody playerRB;
    public bool playerInFloor = true;
    public bool gameOver = false;
    private Animator playerAnim;
    AudioSource jump;

    // Start is called before the first frame update
    void Start()
    {
        jump = GetComponent<AudioSource>();
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
                jump.Play(0);
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
            playerAnim.SetBool("Death_b",true);
            playerAnim.SetInteger("DeathType_int", 1);
        }
    }

}
