using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetText : MonoBehaviour {

    private void Awake()
    {
        Text text = GameObject.Find("Text").GetComponent<Text>();
        text.text = GameObject.Find("OptionsManager").GetComponent<OptionsScript>().objectiveText;
    }

}
