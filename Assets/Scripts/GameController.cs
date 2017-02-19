using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    private GameObject menuMusic;

    private void Start()
    {
        menuMusic = Resources.Load<GameObject>("Prefabs/MURASAME");
    }

    private void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }
        if(Input.GetButtonDown("Restart") && (SceneManager.GetActiveScene().name == "MainGame" || SceneManager.GetActiveScene().name == "WIN"))
        {
            SceneManager.LoadScene("MainGame");
            GameObject.Find("ChipRocket").GetComponent<AudioSource>().time = 13.1f;
            GameObject.Find("ChipRocket").GetComponent<AudioSource>().Play();
        }
        if(Input.GetButtonDown("Menu") && (SceneManager.GetActiveScene().name == "MainGame" ||
                                            SceneManager.GetActiveScene().name == "Objective" ||
                                            SceneManager.GetActiveScene().name == "WIN"))
        {
            if(GameObject.Find("ChipRocket") != null)
            {
                Destroy(GameObject.Find("ChipRocket"));
            }   
            GameObject.Instantiate(menuMusic);
            SceneManager.LoadScene("Options");
        }
    }
}
