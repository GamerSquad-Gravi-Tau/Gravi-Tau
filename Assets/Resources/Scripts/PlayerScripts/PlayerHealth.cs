﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
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

    private void checkHealth()
    {
        if (health < 1)
        {
            //change scene to death
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}