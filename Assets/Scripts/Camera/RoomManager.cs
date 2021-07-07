using System.Collections;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public int backZIndex = 8;
    public int frontZIndex = -2;

    private bool inTrigger;
    private Animator pressE;
    private SpriteRenderer filter;
    private GameObject player, room, _frontColliders, _floor;
    private Rigidbody2D PlayerRigidbody;
    void Start()
    {
        pressE = GameObject.Find("Canvas/PressE").GetComponent<Animator>();
        _frontColliders = GameObject.Find("FrontColliders");
        _floor = GameObject.Find("Floor");
        player = GameObject.FindGameObjectWithTag("Player");
        PlayerRigidbody = player.GetComponent<Rigidbody2D>();
        filter = GameObject.Find("Filter").GetComponent<SpriteRenderer>();
        room = GameObject.Find("Rooms/" + transform.parent.gameObject.name);
    }
    IEnumerator Fade()
    {
        for (float ft = 1f; ft >= 0; ft -= 0.125f)
        {
            Color c = filter.color;
            c.a = ft;
            filter.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        { 
            inTrigger = true;
            pressE.SetBool("inTrigger", true);
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            inTrigger = false;
            pressE.SetBool("inTrigger", false);
        }
    }
    void Update()
    {
        if (player != null && player.transform.position.z == backZIndex)
        {
            _frontColliders.SetActive(false);
            _floor.SetActive(false);
            if (room.activeSelf == false && inTrigger)
                room.SetActive(true);
            if (inTrigger)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    StartCoroutine("Fade");
                    PlayerRigidbody.velocity = new Vector2(0,0);
                    player.transform.position = new Vector3(Mathf.RoundToInt(player.transform.position.x), Mathf.RoundToInt(player.transform.position.y), frontZIndex);
                    room.SetActive(false);
                    _frontColliders.SetActive(true);
                    _floor.SetActive(true);
                }
            }
        }
        else if (player != null && player.transform.position.z == frontZIndex)
        {
            _frontColliders.SetActive(true);
            _floor.SetActive(true);
            if (room.activeSelf == true)
                room.SetActive(false);
            if (inTrigger)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    PlayerRigidbody.velocity = new Vector2(0, 0);
                    StartCoroutine("Fade");
                    player.transform.position = new Vector3(Mathf.RoundToInt(player.transform.position.x), Mathf.RoundToInt(player.transform.position.y), backZIndex);
                    room.SetActive(true);
                    _frontColliders.SetActive(false);
                    _floor.SetActive(false);
                }
            }
        }
    }
}
