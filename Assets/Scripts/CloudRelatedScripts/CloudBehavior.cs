using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloudBehavior : MonoBehaviour {

    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public PolygonCollider2D col;
    [HideInInspector] public SpriteRenderer sr;
    private bool frozen;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<PolygonCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        rb.isKinematic = true;
        frozen = false;
        col.enabled = false;
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
        col.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GameObject.Find("Main Camera").GetComponent<WinTimer>().GameLive = false;
            Destroy(collision.gameObject, 2f);
            collision.tag = "Dead";
            CharacterMovement script = collision.GetComponent<CharacterMovement>();
            script.sr.enabled = false;
            script.col.enabled = false;
            script.m_Rigidbody.isKinematic = false;
            GameObject.Find("Blood").GetComponent<ParticleSystem>().Play();
            GameObject.Find("Blood").transform.parent = null;
            GameObject.Find("Text").GetComponent<Text>().text = "You Died!\nPress R to Try Again";
            GameObject.Find("ChipRocket").GetComponent<AudioSource>().Pause();
            GameObject.Find("Lol U Died").GetComponent<AudioSource>().Play();
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

    public GameObject GetCloudBreak()
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
