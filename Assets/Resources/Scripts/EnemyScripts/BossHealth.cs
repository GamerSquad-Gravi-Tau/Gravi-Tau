using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        health = 200;
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
        if (health < 0)
        {
            Die();
        }
    }

    private void Die()
    {
        ScoreScript.IncScore(200);
        Destroy(gameObject);
    }
}
