using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudParticleDestroy : MonoBehaviour {

    private void Start()
    {
        Destroy(this.gameObject, 2f);
    }
}
