using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Movement_Archer : MonoBehaviour
{
    public float life, maxLife, power, speed, jump, dashSpeed;
    public int grounded=0;
    public SpriteRenderer spr;
    public Objects obj;
    public TextMeshProUGUI n_coins;
    private BoxCollider2D bc;
    private CircleCollider2D cc;
    private bool can_jump = false;
    private bool can_dash = false;
    private float cooldawn_DashTime = 0f;
    private float obs_time = 0f;
    public int dir_dash = 1;
    private float speedShift = 0f;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speedShift = speed / 2;
    }

    void Update()
    {
        if (obs_time >= 0)
        {
            obs_time -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space) && grounded<2)
        {
            can_jump = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && cooldawn_DashTime <= 0)
        {
            can_dash = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            spr.flipX = true;
            dir_dash = -1;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            spr.flipX = false;
            dir_dash = 1;
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y);
        if (can_jump)
        {
            rb.AddForce(transform.up * jump, ForceMode2D.Impulse);
            can_jump = false;
            grounded += 1;
        }
        cooldawn_DashTime -= Time.deltaTime;
        if (can_dash)
        {   
            rb.gravityScale = 0;
            if (grounded<=2)
            {
                cooldawn_DashTime = 1.2f;
            }
            else
            {
                cooldawn_DashTime = 0.7f;
             }
            transform.position += new Vector3(dir_dash * 4, 0,0);
            can_dash = false;
            rb.gravityScale = 1;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("speedTrigger"))
        {
            speed = speedShift;
        }
        if (collision.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            obj.nc += 1;
            if (obj.nc < 10)
            {
                n_coins.text = "0" + obj.nc.ToString();
            }
            else
            {
                obj.nc = 10;
                n_coins.text = obj.nc.ToString();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("speedTrigger"))
        {
            speed = speedShift * 2;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") && obs_time <= 0f)
        {
            life -= 5.0f;
            obs_time = 0.5f;
            rb.AddForce(transform.up * 200, ForceMode2D.Impulse);
            if (dir_dash == 1)
            {
                rb.AddForce(-1 * transform.right * 200, ForceMode2D.Impulse);
            }
            else
            {
                rb.AddForce(-1 * transform.right * 200, ForceMode2D.Impulse);
            }
            grounded++;
        }
    }
}
