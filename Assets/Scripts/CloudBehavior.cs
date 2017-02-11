using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehavior : MonoBehaviour {

    private Rigidbody2D rb;
    private PolygonCollider2D col;
    private SpriteRenderer sr;
    private bool frozen;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<PolygonCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        rb.isKinematic = true;
        frozen = false;
    }

    private void Update()
    {
        if(Input.GetButtonUp("Mouse0") || transform.localScale.x >= 3)
        {
            Freeze();
        }
        else if(!frozen)
        {
            transform.localScale += new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime);
        }
    }

    private void Freeze()
    {
        frozen = true;
        rb.isKinematic = false;
        sr.material = Resources.Load<Material>("Materials/IcyMaterial");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Destroy(collision.gameObject, 2f);
            CharacterMovement script = collision.GetComponent<CharacterMovement>();
            script.sr.enabled = false;
            script.col.enabled = false;
            script.m_Rigidbody.isKinematic = false;
            GameObject.Find("Blood").GetComponent<ParticleSystem>().Play();
            GameObject.Find("Blood").transform.parent = null;
        }
        Destroy(this.gameObject, 2f);
        sr.enabled = false;
        col.enabled = false;
        GameObject part = GetCloudBreak();
        if(part != null)
        {
            part.GetComponent<ParticleSystem>().Play();
        }
    }

    private GameObject GetCloudBreak()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).name.Contains("CloudBreak"))
            {
                return transform.GetChild(i).gameObject;
            }
        }
        return null;
    }
}
