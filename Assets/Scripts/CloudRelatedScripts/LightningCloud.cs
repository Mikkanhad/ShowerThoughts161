using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningCloud : MonoBehaviour {

    private Rigidbody2D rigidBody;
    private GameObject player;
    public float max_Velocity;
    private float bobbleCycle;
    private float zapTimer;
    private float startY;
    private Light charge;
    private bool charging;
    public GameObject lightning;
    private RaycastHit2D hit;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Character");
        max_Velocity = 5f;
        startY = transform.position.y;
        zapTimer = 3;
        bobbleCycle = 0;
        charge = GetComponent<Light>();
        charge.intensity = 0;
    }

    private void Update()
    {
        hit = Physics2D.Raycast(transform.position, Vector2.down);
        if (player != null)
        {
            Move();
        }
        if (hit)
        {
            if (charging || (zapTimer <= 0 && hit.transform.tag == "Player"))
            {
                Charge();
            }
        }
        Bobble();
        Zap();
        zapTimer -= Time.deltaTime;
    }

    private void Move()
    {
        if(player.transform.position.x < transform.position.x && rigidBody.velocity.x > -5)
        {
            rigidBody.velocity -= new Vector2(Time.deltaTime * 5, 0);
        }
        else if (player.transform.position.x > transform.position.x && rigidBody.velocity.x < 5)
        {
            rigidBody.velocity += new Vector2(Time.deltaTime * 5, 0);
        }
        else if (player.transform.position.x < transform.position.x && rigidBody.velocity.x <= -5)
        {
            rigidBody.velocity = new Vector2(-max_Velocity, 0);
        }
        else if (player.transform.position.x > transform.position.x && rigidBody.velocity.x >= 5)
        {
            rigidBody.velocity = new Vector2(max_Velocity, 0);
        }
    }

    private void Bobble()
    {
        bobbleCycle += Time.deltaTime;
        float add = Mathf.Sin(bobbleCycle * 2);
        transform.position = new Vector2(transform.position.x, startY + add);
    }

    private void Zap()
    {
        if (charge.intensity >= 1)
        {
            charge.intensity = 0;
            Vector2 spawnPoint = new Vector2(transform.position.x - 0.37f, 4.54f);
            Vector2 Offset = Vector2.zero;
            GameObject.Instantiate(lightning, spawnPoint + Offset, transform.rotation);
            charging = false;
            zapTimer = 3f;
        }
    }

    private void Charge()
    {
        if(zapTimer <= 0)
        {
            charging = true;
            rigidBody.velocity = Vector2.zero;
        }
        charge.intensity += Time.deltaTime;
    }
}
