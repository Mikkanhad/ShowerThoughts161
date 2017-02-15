using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCloudSpawner : MonoBehaviour {

    public GameObject cloud;
    private float cloudTimer;
    private Quaternion rotation;
    private float WinTimer;

    private void Start()
    {
        WinTimer = 30;
        cloudTimer = 1;
        rotation = Quaternion.Euler(0, 0, 0);
    }

    private void Update()
    {
        if(cloudTimer <= 0)
        {
            float x = Random.Range(-7.5f, 7.5f);
            float y = Random.Range(7.5f, 9f);
            Vector3 spawnPoint = new Vector3(x, y, 0);
            GameObject.Instantiate(cloud, spawnPoint, rotation);
            cloudTimer = 0.5f;
        }
        WinTimer -= Time.deltaTime;
        cloudTimer -= Time.deltaTime;
    }
}
