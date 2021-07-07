using UnityEngine;

public class Attack : MonoBehaviour
{
    public bool isAttack;
    public GameObject _checkGround;

    private Animator _animator;
    private Vector3 mousePosition;
    private GameObject _hand, player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _animator = player.GetComponent<Animator>();
        _hand = GameObject.Find("Girl/Shoulder/Hand");
    }

    private void Update()
    {
        if (_checkGround.GetComponent<CheckGround>().isGrounded && Input.GetMouseButton(1) && Mathf.Abs(player.GetComponent<Rigidbody2D>().velocity.x) <= 2 && Mathf.Abs(player.GetComponent<Rigidbody2D>().velocity.y) <= 2  && Time.timeScale == 1 && Input.GetAxis("Horizontal") == 0)
        {
            isAttack = true;
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            _animator.SetBool("Attack", isAttack);
            _hand.gameObject.SetActive(isAttack);
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 difference = mousePosition - transform.position;
            difference.Normalize();
            float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            if (Screen.width / 2 <= Input.mousePosition.x)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, -0.2f);
            }
               
            else if (Screen.width / 2 >= Input.mousePosition.x)
            {
                transform.rotation = Quaternion.Euler(180f, 0f, -rotation_z);
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0.2f);
            }
        }
        else
        {
            isAttack = false;
            _animator.SetBool("Attack", isAttack);
            _hand.gameObject.SetActive(isAttack);
        }
    }
}
