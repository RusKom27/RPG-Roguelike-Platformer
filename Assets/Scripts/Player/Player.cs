using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 20,
                 jumpSpeed = 2000,
                 health,
                 resist = 1,
                 regeneration;
    public GameObject _checkGround, _attackScript;

    private bool faceRight = true;
    private Animator animator;
    private Rigidbody2D rigidBody;
    private Slider _healthBar;
    private GameObject _deathPanel, _shadow, _shoulder;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        _healthBar = GameObject.Find("Canvas/HUD/HealthBar").GetComponent<Slider>();
        _deathPanel = GameObject.Find("Canvas/DeathPanel");
        _shadow = GameObject.Find("Girl/Shadow");
        _shoulder = GameObject.Find("Girl/Sholder");
    }

    private void Start()
    {
        _healthBar.maxValue = health;
        _deathPanel.SetActive(false);
    }

    private void Update()
    {
        if (!_attackScript.GetComponent<Attack>().isAttack)
        {
            Run();
            Jump();
        }
        animator.SetBool("isGrounded", _checkGround.GetComponent<CheckGround>().isGrounded);
        animator.SetFloat("jumpSpeed", Mathf.Abs(rigidBody.velocity.y));
        if (Screen.width / 2 <= Input.mousePosition.x && !faceRight && Input.GetAxis("Horizontal") != -1 && Input.GetAxis("Horizontal") == 0)
            Flip();
        else if (Screen.width / 2 >= Input.mousePosition.x && faceRight && Input.GetAxis("Horizontal") != 1 && Input.GetAxis("Horizontal") == 0)
            Flip();
        if (health <= 0)
        {
            Death();
            _deathPanel.SetActive(true);
        }

        _healthBar.value = health;
        if(health < 100)
            health += regeneration * Time.deltaTime; 
    }

    public void TakeDamage(int damage)
    {
        health -= damage / resist;
    }

    public void Death()
    {
        //Destroy(gameObject);
    }

    private void Jump()
    {
        if (_checkGround.GetComponent<CheckGround>().isGrounded && Input.GetKeyDown(KeyCode.Space))
            rigidBody.AddForce(new Vector2(0, jumpSpeed));
    }
    private void Run()
    {
        float move = Input.GetAxis("Horizontal");
        if (Mathf.Abs(Input.GetAxis("Horizontal")) >= 0.1)
            GetComponent<CapsuleCollider2D>().size = new Vector2(3f, 4.8f);
        else
            GetComponent<CapsuleCollider2D>().size = new Vector2(1.1f, 4.8f);
        animator.SetFloat("Speed", Mathf.Abs(move));
        rigidBody.velocity = new Vector2(move * speed, rigidBody.velocity.y);
        if (move > 0 && !faceRight && Screen.width / 2 >= Input.mousePosition.x)
            Flip();
        else if (move < 0 && faceRight && Screen.width / 2 <= Input.mousePosition.x)
            Flip();
    }


    public void Flip()
    {
        if (Time.timeScale == 1)
        {
            faceRight = !faceRight;
            Quaternion theScale = transform.localRotation;
            if (faceRight)
            {
                theScale.y = 0;
                _shadow.transform.localPosition = new Vector3(_shadow.transform.localPosition.x, _shadow.transform.localPosition.y, _shadow.transform.localPosition.z * -1);
                if (_shoulder != null)
                    _shoulder.transform.localPosition = new Vector3(_shoulder.transform.localPosition.x, _shoulder.transform.localPosition.y, _shoulder.transform.localPosition.z * -1);
            }
                
            else
            {
                theScale.y += 180;
                _shadow.transform.localPosition = new Vector3(_shadow.transform.localPosition.x, _shadow.transform.localPosition.y, _shadow.transform.localPosition.z * -1);
                if (_shoulder != null)
                    _shoulder.transform.localPosition = new Vector3(_shoulder.transform.localPosition.x, _shoulder.transform.localPosition.y, _shoulder.transform.localPosition.z * -1);
            }
                
            transform.localRotation = theScale;
        }
    }
}

