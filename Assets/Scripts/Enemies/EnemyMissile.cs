using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissile : MonoBehaviour
{
    public float speedMissile = 40f,
                 lifeTime = 2f;
    public GameObject Explosion;

    private Rigidbody2D _rigidbody2D;
    private Transform _player;
    private Vector3 target, startPosition;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        target = new Vector3(_player.position.x, _player.position.y + Random.Range(-4,+6), _player.position.z);
        startPosition = transform.position;
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
    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, target, speedMissile * Time.deltaTime);
        _rigidbody2D.velocity = target - startPosition;
        StartCoroutine("Timer");
    }

}
