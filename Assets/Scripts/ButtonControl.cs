using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonControl : MonoBehaviour {

    private EventSystem eventSystem;
    private GameObject[] optionManagers;

    private void Start()
    {
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        optionManagers = GameObject.FindGameObjectsWithTag("Options");
        for (int i = 0; i < optionManagers.Length; i++)
        {
            if (i != 0)
            {
                Destroy(optionManagers[i]);
            }
        }
    }

    private void Update()
    {
        if(Input.GetButtonDown("Submit") && eventSystem.currentSelectedGameObject.name == "Normal")
        {
            GameObject.Find("OptionsManager").GetComponent<OptionsScript>().cloudSpawnRate = 0.5f;
            GameObject.Find("OptionsManager").GetComponent<OptionsScript>().objectiveText = "SURVIVE 30 SECONDS";
            GameObject.Find("OptionsManager").GetComponent<OptionsScript>().endless = false;
            if(GameObject.Find("MURASAME") != null)
            {
                Destroy(GameObject.Find("MURASAME"));
            }
            else if(GameObject.Find("MURASAME(Clone)") != null)
            {
                Destroy(GameObject.Find("MURASAME(Clone)"));
            }
            SceneManager.LoadScene("Objective");
        }
        if (Input.GetButtonDown("Submit") && eventSystem.currentSelectedGameObject.name == "Hard")
        {
            GameObject.Find("OptionsManager").GetComponent<OptionsScript>().cloudSpawnRate = 0.2f;
            GameObject.Find("OptionsManager").GetComponent<OptionsScript>().objectiveText = "SURVIVE 30 SECONDS";
            GameObject.Find("OptionsManager").GetComponent<OptionsScript>().endless = false;
            if (GameObject.Find("MURASAME") != null)
            {
                Destroy(GameObject.Find("MURASAME"));
            }
            else if (GameObject.Find("MURASAME(Clone)") != null)
            {
                Destroy(GameObject.Find("MURASAME(Clone)"));
            }
            SceneManager.LoadScene("Objective");
        }
        if (Input.GetButtonDown("Submit") && eventSystem.currentSelectedGameObject.name == "Endless")
        {
            GameObject.Find("OptionsManager").GetComponent<OptionsScript>().cloudSpawnRate = 0.5f;
            GameObject.Find("OptionsManager").GetComponent<OptionsScript>().objectiveText = "HOW LONG CAN YOU SURVIVE?";
            GameObject.Find("OptionsManager").GetComponent<OptionsScript>().endless = true;
            if (GameObject.Find("MURASAME") != null)
            {
                Destroy(GameObject.Find("MURASAME"));
            }
            else if (GameObject.Find("MURASAME(Clone)") != null)
            {
                Destroy(GameObject.Find("MURASAME(Clone)"));
            }
            SceneManager.LoadScene("Objective");
        }
        if (Input.GetButtonDown("Submit") && eventSystem.currentSelectedGameObject.name == "Controls")
        {
            SceneManager.LoadScene("Controls");
        }
        if (Input.GetButtonDown("Submit") && eventSystem.currentSelectedGameObject.name == "ResetHighScore")
        {
            PlayerPrefs.SetFloat("highScore", 0);
            PlayerPrefs.Save();
        }


    }

}
