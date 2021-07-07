using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldmanQuest1Book : MonoBehaviour
{
    bool inTrigger;
    private Animator pressE;

    private void Start()
    {
        pressE = GameObject.Find("Canvas/PressE").GetComponent<Animator>();
    }
    void Update()
    {
        if (inTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (PlayerPrefs.GetInt("OldmanQuest1") == 1)
                    PlayerPrefs.SetInt("OldmanQuest1", 2);
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            inTrigger = true;
        }
        if (PlayerPrefs.GetInt("OldmanQuest1") == 1)
            pressE.SetBool("inTrigger", true);
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            inTrigger = false;
        }
        if (PlayerPrefs.GetInt("OldmanQuest1") == 1 || PlayerPrefs.GetInt("OldmanQuest1") == 2)
            pressE.SetBool("inTrigger", false);
    }
}
