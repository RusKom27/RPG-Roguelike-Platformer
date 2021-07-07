using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public bool isGrounded;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!isGrounded && !collision.isTrigger)
            isGrounded = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isGrounded && !collision.isTrigger)
            isGrounded = false;
    }
}
