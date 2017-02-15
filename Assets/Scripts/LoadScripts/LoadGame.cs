using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour {

    private AudioSource music;

    private void Start()
    {
        music = GameObject.Find("ChipRocket").GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(music.time >= 10.9f)
        {
            SceneManager.LoadScene("Objective");
        }
    }

}
