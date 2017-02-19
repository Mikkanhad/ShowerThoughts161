using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour {

    private void Awake()
    {
        if(name == "ChipRocket")
        {
            GetComponent<AudioSource>().time = 11.1f;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
