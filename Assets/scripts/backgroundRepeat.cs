using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundRepeat : MonoBehaviour
{
    private Vector3 initialPos;
    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -21.3)
        {
            transform.position = initialPos;
        }
    }
}
