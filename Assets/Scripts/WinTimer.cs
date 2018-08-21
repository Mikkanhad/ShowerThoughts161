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
    private bool endless;

    private void Start()
    {
        GameLive = true;
        if(!GameObject.Find("OptionsManager"))
        {
            endless = false;
        }
        else
        {
            endless = GameObject.Find("OptionsManager").GetComponent<OptionsScript>().endless;
        }
        if (!endless)
        {
            timer = 30f;
        }
        else
        {
            timer = 0;
        }
        player = GameObject.Find("Character");
        text = GameObject.Find("Timer").GetComponent<Text>();
    }

    private void Update()
    {
        if (GameLive && !endless)
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
        else if(GameLive && endless)
        { 
            if(player.gameObject != null && player.tag != "Dead")
            {
                timer += Time.deltaTime;
                text.text = text.text = "" + Mathf.Ceil(timer);
            }
            if (player.gameObject == null || player.tag != "Dead")
            {
                if (!PlayerPrefs.HasKey("highScore"))
                {
                    PlayerPrefs.SetFloat("highScore", Mathf.Floor(timer));
                }
                else
                {
                    if (PlayerPrefs.GetFloat("highScore") < Mathf.Ceil(timer))
                    {
                        PlayerPrefs.SetFloat("highScore", Mathf.Ceil(timer));
                    }
                }
                PlayerPrefs.Save();
            }
        }
    }
}
