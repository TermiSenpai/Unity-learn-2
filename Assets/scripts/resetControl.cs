using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class resetControl : MonoBehaviour
{
    // Start is called before the first frame update

    public void resetLevel()
    {
        SceneManager.LoadScene("Prototype 3");
    }
}
