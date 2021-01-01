using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class pj_Active : MonoBehaviour
{
    public GameObject archer;
    public GameObject tank;
    public Movement_Archer arch;
    public Movement_Tank tankl;
    public GameObject txt;
    public string pj_act;
    private bool tab_show=false;
    private Vector3 pos;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)){
            if (tank.activeInHierarchy && arch.life>=0 && (tankl.grounded || tankl.life<=0))
            {
                tab_show = true;
                pos = tank.transform.position;
                tank.SetActive(false);
                archer.transform.position=pos;
                archer.SetActive(true);
                pj_act = "archer";
                txt.SetActive(false);
            }
            else if (archer.activeInHierarchy && tankl.life >= 0 && (arch.grounded == 0 || arch.life<=0))
            {
                pos = archer.transform.position;
                archer.SetActive(false);
                tank.transform.position = pos;
                tank.SetActive(true);
                pj_act = "tank";
                txt.SetActive(false);
            }
        }
        if (tankl.life <= 0 && tab_show==false)
        {
            tankl.speed = 0;
            txt.SetActive(true);
        }
        if (arch.life <= 0 && tab_show == false)
        {
            arch.speed = 0;
            txt.SetActive(true);
        }
    }
}
