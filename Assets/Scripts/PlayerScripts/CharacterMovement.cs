using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    [HideInInspector] public SpriteRenderer sr;
    [HideInInspector] public Rigidbody2D m_Rigidbody;
    [HideInInspector] public BoxCollider2D col;
    [HideInInspector] public float velocity;
    private float dashCD;
    private bool facingRight;
    private GameObject particle;
    [HideInInspector] public bool grounded;
    [HideInInspector] public float stunTimer;
    private bool hasBomb;
    

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
        particle = GameObject.Find("DashParticle");
        facingRight = true;
        velocity = 5;
        hasBomb = true;
    }

    private void Update()
    {
        if(stunTimer > 0)
        {
            stunTimer -= Time.deltaTime;
            m_Rigidbody.velocity = Vector2.zero;
            Shake();
            return;
        }
        if(dashCD >= 0)
        {
            particle.SetActive(true);
            Dash();
            dashCD -= Time.deltaTime;
        }
        else
        {
            particle.SetActive(false);
            Move();
        }
        if(Input.GetButtonDown("Bomb") && hasBomb)
        {
            DestroyClouds();
            hasBomb = false;
            GameObject bomb = GameObject.Find("Bomb");
            Color c = bomb.GetComponent<Image>().color;
            c.a = 0;
            bomb.GetComponent<Image>().color = c;
        }
        Flip();
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if(Input.GetButtonDown("Jump") && grounded)
        {
            m_Rigidbody.AddForce(new Vector2(0, 800));
        }
        if(Input.GetButtonDown("Dash"))
        {
            dashCD = 0.1f;
        }

        m_Rigidbody.velocity = new Vector3(horizontal * velocity, m_Rigidbody.velocity.y, 0);

    }
    private void Dash()
    {
        if(!facingRight)
        {
            m_Rigidbody.velocity = new Vector3(-(velocity * 4), 0, 0);
        }
        else
        {
            m_Rigidbody.velocity = new Vector3((velocity * 4), 0, 0);
        }
    }
    private void Flip()
    {
        float h = Input.GetAxisRaw("Horizontal");
        if(h < 0 && facingRight)
        {
            facingRight = false;
        }
        else if(h > 0 && !facingRight)
        {
            facingRight = true;
        }
    }
    private void Shake()
    {
        float x = Random.Range(-0.05f, 0.05f);
        float y = Random.Range(-0.05f, 0.05f);

        transform.position = new Vector2(transform.position.x + x, transform.position.y + y);
    }
    private void DestroyClouds()
    {
        GameObject[] clouds = GameObject.FindGameObjectsWithTag("Cloud");
        foreach(GameObject cloud in clouds)
        {
            Destroy(cloud.gameObject, 0.5f);
            CloudBehavior cb = cloud.GetComponent<CloudBehavior>();
            cb.sr.enabled = false;
            cb.col.enabled = false;
            cb.rb.isKinematic = true;
            GameObject part = cb.GetCloudBreak();
            if (part != null)
            {
                part.GetComponent<ParticleSystem>().Play();
                part.transform.parent = null;
                Destroy(part.gameObject, 5f);
            }
        }
    }
}