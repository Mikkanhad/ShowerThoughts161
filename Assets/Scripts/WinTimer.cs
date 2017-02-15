using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinTimer : MonoBehaviour {

    private float timer;
    private Text text;
    private GameObject player;
    [HideInInspector] public bool GameLive;

    private void Start()
    {
        GameLive = true;
        timer = 30f;
        player = GameObject.Find("Character");
        text = GameObject.Find("Timer").GetComponent<Text>();
    }

    private void Update()
    {
        if (GameLive)
        {
            timer -= Time.deltaTime;
            text.text = "" + Mathf.Ceil(timer);
            if (timer <= 0 && (player.gameObject == null || player.tag != "Dead"))
            {
                Time.timeScale = 0.25f;
                if (GameObject.Find("ChipRocket").GetComponent<AudioSource>().time >= 46.5f)
                {
                    SceneManager.LoadScene("WIN");
                }
            }
        }
    }
}
