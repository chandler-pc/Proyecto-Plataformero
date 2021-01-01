using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Life : MonoBehaviour
{
    public Movement_Tank tank;
    public Movement_Archer archer;
    public pj_Active pj;
    public TextMeshProUGUI txt;
    private Image life_bar;
    private void Start()
    {
        life_bar = GetComponent<Image>();
    }
    void Update()
    {
        if (pj.pj_act == "tank")
        {
            life_bar.fillAmount = tank.life / tank.maxLife;
            if (tank.life <= 0)
            {
                txt.text = 0.ToString();
            }
            else
            {
                txt.text = tank.life.ToString();
            }
        }
        else if (pj.pj_act == "archer")
        {
            life_bar.fillAmount = archer.life / archer.maxLife;
            if (archer.life <= 0)
            {
                txt.text = 0.ToString();
            }
            else
            {
                txt.text = archer.life.ToString();
            }
        }
    }
}
