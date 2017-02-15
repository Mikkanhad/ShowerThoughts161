using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManipulator : MonoBehaviour {

    private Text txt;
    private GameObject textObject;
    private bool rotateLeft;
    private float timePassed;
    private Vector3 origin;

    private void Start()
    {
        textObject = GameObject.Find("Text");
        txt = textObject.GetComponent<Text>();
        rotateLeft = true;
        timePassed = 0;
        origin = textObject.transform.position;
    }

    private void Update()
    {
        Rotate();
        CircleAround();
        timePassed += Time.deltaTime;
        Time.timeScale = 1;
    }

    private void Rotate()
    {
        float z = textObject.transform.rotation.eulerAngles.z;
        if (z >= 345 && z < 346)
        {
            rotateLeft = false;
        }
        else if (z >= 14 && z < 15)
        {
            rotateLeft = true;
        }

        if (rotateLeft)
        {
            Vector3 temp = textObject.transform.rotation.eulerAngles;
            temp -= new Vector3(0, 0, Time.deltaTime * 30);
            textObject.transform.rotation = Quaternion.Euler(temp);
        }
        else
        {
            Vector3 temp = textObject.transform.rotation.eulerAngles;
            temp += new Vector3(0, 0, Time.deltaTime * 30);
            textObject.transform.rotation = Quaternion.Euler(temp);
        }
    }

    private void CircleAround()
    {
        float x = Mathf.Cos(timePassed * 10) * 30;
        float y = Mathf.Sin(timePassed * 10) * 30;
        textObject.transform.position = origin + new Vector3(x, y, 0);
    }
}
