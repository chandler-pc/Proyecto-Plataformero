using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Movement_Tank : MonoBehaviour
{
    public float life, maxLife, power, speed, jump, dashSpeed;
    public bool grounded;
    public SpriteRenderer spr;
    public Objects obj;
    public TextMeshProUGUI n_coins;
    private BoxCollider2D bc;
    private CircleCollider2D cc;
    private bool can_jump = false;
    private bool can_dash = false;
    private float cooldawn_DashTime=0f;
    private float dashTime;
    private float obs_time=0f;
    private float startDashTime = 0.1f;
    public int dir_dash = 1;
    private float speedShift = 0f;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
        speedShift = speed / 2;
    }

    void Update()
    {
        if (obs_time >= 0)
        {
            obs_time -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            can_jump = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift)&&cooldawn_DashTime<=0)
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
            grounded = false;
        }
        cooldawn_DashTime -= Time.deltaTime;
        if (can_dash)
        {
            if (dashTime <= 0)
            {
                if (!grounded)
                {
                    cooldawn_DashTime = 1f;
                }
                else
                {
                    cooldawn_DashTime = 0.5f;
                }
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
                can_dash = false;
                rb.gravityScale = 1;
            }else{
                rb.gravityScale = 0;
                dashTime -= Time.deltaTime;
                rb.AddForce(new Vector2(dashSpeed*dir_dash,0), ForceMode2D.Impulse);
            }
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
        if (collision.gameObject.CompareTag("Obstacle") && obs_time<=0f)
        {
            life -= 5.0f;
            obs_time = 0.5f;
            rb.AddForce(transform.up * 500, ForceMode2D.Impulse);
            if (dir_dash == 1)
            {
                rb.AddForce(-1*transform.right * 300, ForceMode2D.Impulse);
            }
            else
            {
                rb.AddForce(-1 * transform.right * 300, ForceMode2D.Impulse);
            }
            grounded = false;
        }
    }
}
