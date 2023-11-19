using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private int maxhealth = 100;
    public int currentHealth;
    private GameManager manager;
    private bool isDead = false; //yaþýyor.
    private void Awake()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public HealthBar healthBar;

    private void Start()
    {
        currentHealth = maxhealth;
        healthBar.SetMaxHealth(maxhealth);
        Debug.Log(manager);
    }

    private void Update()
    {
        Debug.Log(maxhealth);
        if (Input.GetKeyUp(KeyCode.Z))
        {
            TakeDamage(20);
        }
        if (maxhealth == 0)
        {
            isDead = true;
        }
        if (isDead)
        {
            manager.isDead = true; //GameManagerda karakteri öldür.
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            TakeDamage(20);
        }

    }
    void TakeDamage(int damage)
    {
        if (maxhealth > 0)
        {
            currentHealth -= damage;
            maxhealth -= damage;
            healthBar.SetHealth(currentHealth);
        }

    }
}
