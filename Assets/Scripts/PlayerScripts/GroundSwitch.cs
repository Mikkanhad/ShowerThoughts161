using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSwitch : MonoBehaviour {

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            GetComponentInParent<CharacterMovement>().grounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponentInParent<CharacterMovement>().grounded = false;
    }
}
