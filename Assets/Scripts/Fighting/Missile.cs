using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speedMissile = 40f,
                 lifeTime = 2f;
    public GameObject Explosion;

    private Transform _player;
    private Rigidbody2D _rigidbody2D;
    private Vector2 shotAxis;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Instantiate(Explosion, transform.position, Quaternion.Euler(0f, 0f, 0f));
        Destroy(gameObject);
    }
    IEnumerator Timer()
    {
        for (float ft = lifeTime; ft >= 0; ft -= 0.1f)
        {
            yield return new WaitForSeconds(0.1f);
        }
        Instantiate(Explosion, transform.position, Quaternion.Euler(0f, 0f, 0));
        Destroy(gameObject);
    }
    private void Start()
    {
        if (Screen.width / 2 <= Input.mousePosition.x)
            shotAxis = transform.right * speedMissile;
        else if (Screen.width / 2 >= Input.mousePosition.x)
            shotAxis = -transform.right * speedMissile;
    }
    void Update()
    {
        _rigidbody2D.velocity = shotAxis;
        StartCoroutine("Timer");
    }
}
