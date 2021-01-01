using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Controll_UI : MonoBehaviour
{
    [Header("Menu")]
    public GameObject mm;
    public Button playbtn;
    public Button optbtn;
    public Button xmbtn;
    public Button loadbtn;
    [Header("Options")]
    public GameObject opt;
    public Button xbtn;

    void Start()
    {
        mm.SetActive(true);
        opt.SetActive(false);
        playbtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("SampleScene");
        });
        optbtn.onClick.AddListener(() =>
        {
            opt.SetActive(true);
            playbtn.gameObject.SetActive(false);
            loadbtn.gameObject.SetActive(false);
            optbtn.interactable=false;
            xmbtn.interactable = false;
        }); 
        xmbtn.onClick.AddListener(() =>
        {
            Application.Quit();
        }); 
        xbtn.onClick.AddListener(() =>
        {
            opt.SetActive(false);
            playbtn.gameObject.SetActive(true);
            loadbtn.gameObject.SetActive(true);
            optbtn.interactable = true;
            xmbtn.interactable = true;
        });
    }
}
