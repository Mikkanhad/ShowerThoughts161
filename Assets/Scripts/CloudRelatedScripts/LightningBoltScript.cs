using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBoltScript : MonoBehaviour {

    private void Start()
    {
        Destroy(this.gameObject, 0.1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<CharacterMovement>().stunTimer = 1f;
        }
    }

}
