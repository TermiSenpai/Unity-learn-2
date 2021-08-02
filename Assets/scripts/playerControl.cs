using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    public float jumpForce = 10.0f;
    public float gravityModifier = 5.0f;
    private Rigidbody playerRB;
    public bool playerInFloor = true;


    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInFloor == true)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerInFloor = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        playerInFloor = true;
    }

}
