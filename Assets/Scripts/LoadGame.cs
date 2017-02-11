using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour {

    private float timer;

    private void Start()
    {
        timer = 0;
    }

    private void Update()
    {
        if(timer >= 13.2f)
        {
            SceneManager.LoadScene("MainGame");
        }
        timer += Time.deltaTime;
    }

}
