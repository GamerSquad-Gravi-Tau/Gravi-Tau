﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //public Text healthText;
    public int health;
    public Slider s;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        s.value = health;
        checkHealth();
    }

    private void checkHealth()
    {
        if (health < 1)
        {
            SceneManager.LoadScene(2);
        }

        if (health > 100)
        {
            health = 100;
        }

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "SpaceStationSatellit" || collision.gameObject.name == "SpaceStationSatellit(Clone)")
        {
            health -= 10;
        }
    }
}
