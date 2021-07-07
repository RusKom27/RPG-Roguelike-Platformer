using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject SecondTeleportPlace;

    private Transform destination;
    private GameObject _player;
    private bool inTrigger;
    private void Start()
    {
        destination = SecondTeleportPlace.GetComponent<Transform>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inTrigger)
        {
            _player.transform.position = new Vector3(destination.position.x, destination.position.y, _player.transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inTrigger = true;
            _player = collision.gameObject;
        }
            
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            inTrigger = false;
    }
}
