using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadObjective : MonoBehaviour {

    private AudioSource music;

    private void Start()
    {
        music = GameObject.Find("ChipRocket").GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(music.time >= 12.8f)
        {
            SceneManager.LoadScene("MainGame");
        }
    }
}
