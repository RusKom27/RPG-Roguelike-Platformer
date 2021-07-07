using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth, 
                 resist,
                 health;
    private GameObject _enemyBar;

    public void Awake()
    {
        _enemyBar = GameObject.Find("Canvas/HUD/EnemyBar");
    }
    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage / resist;
    }
    public void Death()
    {
        Destroy(gameObject);
        _enemyBar.SetActive(false);
    }
    void Update()
    {
        if (health <= 0)
        {
            gameObject.GetComponent<Animator>().Play("Death");
        }
    }
}
