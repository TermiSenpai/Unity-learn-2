using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]

public class playerControl : MonoBehaviour
{
    public AudioClip jump;
    public AudioClip death;
    private AudioSource playerSound;
    private Animator playerAnim;
    private Rigidbody playerRB;
    public ParticleSystem explosion;
    public ParticleSystem dirt;
    public GameObject reset;

    public int jumpForce;
    public int gravityModifier;
    public bool playerInFloor = true;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        reset.gameObject.SetActive(false);
        playerSound = GetComponent<AudioSource>();
        playerRB = GetComponent<Rigidbody>();
        //Physics.gravity *= gravityModifier;
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
                playerSound.PlayOneShot(jump, 1);
                Debug.Log(jumpForce);
                Debug.Log(Physics.gravity);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Prototype 3");
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            dirt.Play();
            playerInFloor = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle") && playerAnim.GetBool("Death_b") != true)
        {
            reset.gameObject.SetActive(true);
            explosion.Play();
            Debug.Log("Game over");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            playerSound.PlayOneShot(death, 0.7f);
        }
    }

}
