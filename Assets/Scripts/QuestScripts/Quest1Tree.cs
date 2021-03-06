using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest1Tree : MonoBehaviour
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
                if (PlayerPrefs.GetInt("Quest1") == 1)
                    PlayerPrefs.SetInt("Quest1", 2); 
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            inTrigger = true;
        }
        if (PlayerPrefs.GetInt("Quest1") == 1)
            pressE.SetBool("inTrigger", true);
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            inTrigger = false;
        }
        if (PlayerPrefs.GetInt("Quest1") == 1 || PlayerPrefs.GetInt("Quest1") == 2)
            pressE.SetBool("inTrigger", false);
    }
}
