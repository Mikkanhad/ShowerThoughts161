using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [HideInInspector] public SpriteRenderer sr;
    [HideInInspector] public Rigidbody2D m_Rigidbody;
    [HideInInspector] public BoxCollider2D col;
    private float dashCD;
    private bool facingRight;
    private GameObject particle;

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
        particle = GameObject.Find("DashParticle");
        facingRight = true;
    }

    private void Update()
    {
        if(dashCD >= 0)
        {
            col.enabled = false;
            particle.SetActive(true);
            Dash();
            dashCD -= Time.deltaTime;
        }
        else
        {
            particle.SetActive(false);
            col.enabled = true;
            Move();
        }
        Flip();
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if(Input.GetButtonDown("Jump"))
        {
            m_Rigidbody.AddForce(new Vector2(0, 800));
        }
        if(Input.GetButtonDown("Dash"))
        {
            dashCD = 0.1f;
        }

        m_Rigidbody.velocity = new Vector3(horizontal * 5, m_Rigidbody.velocity.y, 0);

    }

    private void Dash()
    {
        if(!facingRight)
        {
            m_Rigidbody.velocity = new Vector3(-20, 0, 0);
        }
        else
        {
            m_Rigidbody.velocity = new Vector3(20, 0, 0);
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
}