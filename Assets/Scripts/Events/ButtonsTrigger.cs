using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsTrigger : MonoBehaviour
{
   
    public bool isPressed;

    public void ButtonEvent()
    {
        if (!isPressed)
            isPressed = true;
    }
}
