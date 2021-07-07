using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplosionDamage : MonoBehaviour
{
    public int damage;

    private GameObject _enemyBar, _enemyHealthBar, _enemyName;

    private void Awake()
    {
        _enemyBar = GameObject.Find("Canvas/HUD/EnemyBar");
        _enemyHealthBar = GameObject.Find("Canvas/HUD/EnemyBar/EnemyHealthBar");
        _enemyName = GameObject.Find("Canvas/HUD/EnemyBar/EnemyName");
    }
    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        GetComponent<Collider2D>().enabled = false;
        if (col.CompareTag("Enemy"))
        {
            col.GetComponent<Enemy>().TakeDamage(damage);
            if (!_enemyBar.activeSelf)
                _enemyBar.SetActive(true);
            _enemyHealthBar.GetComponent<Slider>().maxValue = col.GetComponent<Enemy>().maxHealth;
            _enemyHealthBar.GetComponent<Slider>().value = col.GetComponent<Enemy>().health;
            _enemyName.GetComponent<Text>().text = col.name;
            _enemyBar.GetComponentInParent<HUDScript>().PanelCloseTime = 10;
        }
        if (col.CompareTag("Player"))
            col.GetComponent<Player>().TakeDamage(damage);
    }
}
