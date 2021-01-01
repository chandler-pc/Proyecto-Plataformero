using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded_Archer : MonoBehaviour
{
    public Movement_Archer player;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            player.grounded = 0;
        }
    }
}
