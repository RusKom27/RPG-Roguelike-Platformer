using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkSound : MonoBehaviour
{
    public AudioSource someSound;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            someSound.Play();
        }
    }
}
