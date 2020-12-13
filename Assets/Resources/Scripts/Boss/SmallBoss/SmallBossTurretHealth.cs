using System.Collections;
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
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        MyHealth -= (damage - 10);
    }
}
