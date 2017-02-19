using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsScript : MonoBehaviour {

    [HideInInspector] public float cloudSpawnRate;
    [HideInInspector] public string objectiveText;
    [HideInInspector] public bool endless;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        cloudSpawnRate = 0;
    }
}
