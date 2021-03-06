﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBossTurretHealth : MonoBehaviour
{
    public int MyHealth = 200;
    public float healthbarDisplacement = 0.3f;
    private Transform healthBar;
    private Transform healthBarBacking;
    private float maxHealthBar;
    private int maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        MyHealth = 200;
        maxHealth = MyHealth;
        healthBar = transform.GetChild(0).GetComponent<Transform>();
        healthBarBacking = transform.GetChild(1).GetComponent<Transform>();
        maxHealthBar = healthBar.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        updateHealthBar();
    }

    private void updateHealthBar(){
        healthBar.localScale = new Vector3(((float)MyHealth/(float)maxHealth)*maxHealthBar,healthBar.localScale.y,1);
        healthBar.position = transform.position +  transform.localScale.y * new Vector3(0f,healthbarDisplacement,0f);
        healthBar.rotation = Quaternion.Euler(0f,0f,0f);
        healthBarBacking.position = transform.position +  transform.localScale.y * new Vector3(0f,healthbarDisplacement,0f);
        healthBarBacking.rotation = Quaternion.Euler(0f,0f,0f);
    }

    public void TakeDamage(int damage)
    {
        MyHealth -= (damage);
    }
}
