using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadExplanation : MonoBehaviour {

    private AudioSource music;

    private void Start()
    {
        music = GameObject.Find("ChipRocket").GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(music.time >= 5.6f)
        {
            SceneManager.LoadScene("Explanation");
        }
    }
}
