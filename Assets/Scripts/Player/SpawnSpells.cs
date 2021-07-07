using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpells : MonoBehaviour
{
    private Vector3 mousePosition;
    private GameObject Missile;

    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 difference = mousePosition - transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        if (Screen.width / 2 <= Input.mousePosition.x)
            transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);
        else if (Screen.width / 2 >= Input.mousePosition.x)
            transform.rotation = Quaternion.Euler(0f, 0f, -rotation_z);
        if (Input.GetMouseButtonDown(0) && HUDScript.actualChar != null)
        {
            Missile = HUDScript.actualChar;
            if (Screen.width / 2 <= Input.mousePosition.x)
                Instantiate(Missile, transform.position, Quaternion.Euler(0f, 0f, rotation_z));
            else if (Screen.width / 2 >= Input.mousePosition.x)
                Instantiate(Missile, transform.position, Quaternion.Euler(0f, 0f, rotation_z - 180));
        }
    }
}
