using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;    
    }

    // Update is called once per frame
    void Update()
    {
        checkHealth();           
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
    private void checkHealth()
    {
        if(health < 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
