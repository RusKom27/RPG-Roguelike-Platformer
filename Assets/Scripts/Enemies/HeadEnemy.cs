using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadEnemy : MonoBehaviour
{
    public float stopDistance,
                 enemySpeed,
                 attackDistance, 
                 cooldown = 1;
    public GameObject missile, _checkGround;
    public bool attack;

    private GameObject enemyBody,
                       _player;
    private Rigidbody2D bodyRigidbody;
    private bool faceRight;
    

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        enemyBody = GetComponent<Transform>().parent.gameObject;
        bodyRigidbody = enemyBody.GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if (!attack)
            cooldown -= Time.deltaTime;
        if(_checkGround.GetComponent<CheckGround>().isGrounded)
            bodyRigidbody.velocity = new Vector2(transform.right.x * enemySpeed, bodyRigidbody.velocity.y);

        CastRay(transform.position, new Vector3(transform.right.x, -3.2f, 0), 13.3f, "Ground");
        CastRay(transform.position, transform.right, stopDistance, "Forvard");
        //CastRay(new Vector3(transform.position.x,transform.position.y - 6, transform.position.z), transform.right, 5f, "UpJumpCheck");
        if (_player != null)
        {
            for (int i = 0; i < 12; i++)
            {
                CastRay(transform.position, new Vector2(_player.transform.position.x - transform.position.x, _player.transform.position.y - 5 + i - transform.position.y), attackDistance, "FindPlayer");
            }
        }
    }

    public void CastRay(Vector3 startPoint, Vector3 direction, float distance, string type)
    {
        Ray2D ray = new Ray2D(startPoint, direction);
        RaycastHit2D[] hit = Physics2D.RaycastAll(ray.origin, ray.direction, distance);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        for (int i = 0; i < hit.Length; i++)
        {
            if (type == "Ground" && !hit[i].collider.isTrigger && (!hit[i].collider.CompareTag("Ground") || !hit[i].collider.CompareTag("Enemy")))
            {
                //if ((Vector3.Distance(transform.position, hit[i].point) > 13 && hit[i].collider.CompareTag("Ground")) || !hit[i].collider.CompareTag("Ground"))
                //{
                    Flip();
                //}
                /*if (Vector3.Distance(transform.position, hit[i].point) > 12 && hit[i].collider.CompareTag("Ground"))
                {
                    if (_checkGround.GetComponent<CheckGround>().isGrounded)
                        bodyRigidbody.velocity = new Vector2(bodyRigidbody.velocity.x * 5, (bodyRigidbody.velocity.y + 1) * 15);
                }*/
            }

            if (type == "Forvard" && !hit[i].collider.isTrigger && !hit[i].collider.CompareTag("Enemy"))
            {
                if (Vector3.Distance(transform.position, hit[i].point) < distance)
                    Flip();

            }

            if (type == "FindPlayer")
            {
                if (hit[i].collider && !hit[i].collider.isTrigger && !hit[i].collider.CompareTag("Player") && !hit[i].collider.CompareTag("Enemy"))
                {
                    attack = false;
                    break;
                }
                if (hit[i].collider.CompareTag("Player"))
                {
                    if (!attack)
                        StartAttack();
                }
            }

            //if (type == "UpJumpCheck" && hit[i].collider && !hit[i].collider.isTrigger && !hit[i].collider.CompareTag("Enemy"))
            //{
            //    if (_checkGround.GetComponent<CheckGround>().isGrounded)
            //        bodyRigidbody.velocity = new Vector2(bodyRigidbody.velocity.x * 5, (bodyRigidbody.velocity.y + 1) * 75);
            //}
        }
    }

    public void StartAttack()
    {
        if (cooldown < 0 && !attack)
        {
            attack = true;
            cooldown = 2;
        }
        if (attack)
        {
            bodyRigidbody.velocity = new Vector2(0, 0);
            Instantiate(missile, new Vector3(transform.position.x,transform.position.y + 4, enemyBody.transform.position.z), Quaternion.identity);
        }
        
    }
    private void Flip()
    {
        if (Time.timeScale == 1 && _checkGround.GetComponent<CheckGround>().isGrounded)
        {
            faceRight = !faceRight;
            Quaternion theScale = enemyBody.transform.localRotation;
            if (!faceRight)
                theScale.y = 0;
            else
                theScale.y += 180;
            enemyBody.transform.localRotation = theScale;
        }
    }
}
