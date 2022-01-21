using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Debug : MonoBehaviour
{
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene(
            (SceneManager.GetActiveScene().buildIndex + 1) %
                SceneManager.sceneCountInBuildSettings
            );
        }
    }
}
