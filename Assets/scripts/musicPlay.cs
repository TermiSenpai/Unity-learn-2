using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicPlay : MonoBehaviour
{
    public AudioSource music;

    private playerControl playerControlScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControlScript = GameObject.Find("Player").GetComponent<playerControl>();
        music = GetComponent<AudioSource>();
        music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControlScript.gameOver)
        {
            music.Stop();
        }
    }
}
