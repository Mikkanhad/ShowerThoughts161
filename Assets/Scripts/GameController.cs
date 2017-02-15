using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    private void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }
        if(Input.GetButtonDown("Restart"))
        {
            SceneManager.LoadScene("MainGame");
            GameObject.Find("ChipRocket").GetComponent<AudioSource>().time = 13.1f;
            GameObject.Find("ChipRocket").GetComponent<AudioSource>().Play();
        }
    }
}
