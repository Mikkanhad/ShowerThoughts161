using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateClouds : MonoBehaviour {

    public GameObject cloud;

    private void Update()
    {
        if(Input.GetButtonDown("Mouse0"))
        {
            Vector3 spawnPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(spawnPoint.y < 7.5)
            {
                spawnPoint.y = 7.5f;
            }
            spawnPoint.z = 0;
            Instantiate(cloud, spawnPoint, cloud.transform.rotation);
        }
    }



}
