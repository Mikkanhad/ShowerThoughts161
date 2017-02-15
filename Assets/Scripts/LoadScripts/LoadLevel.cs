using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            SceneManager.LoadScene("Controls");
        }
        if (Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }
    }
}
