using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded_Tank : MonoBehaviour
{
    public Movement_Tank player;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            player.grounded = true;
        }
    }
}
