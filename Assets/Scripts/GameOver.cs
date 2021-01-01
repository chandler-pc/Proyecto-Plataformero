using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{ 
    public Movement_Archer arch;
    public Movement_Tank tankl;
    public GameObject G_O;
    public GameObject Game;

    void Update()
    {
        if(arch.life<=0 && tankl.life <= 0)
        {
            G_O.SetActive(true);
            Game.SetActive(false);
        }
    }
}
