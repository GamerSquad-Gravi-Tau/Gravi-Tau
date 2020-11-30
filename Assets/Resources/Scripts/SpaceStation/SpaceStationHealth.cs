using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceStationHealth : MonoBehaviour
{
    public int health;

    public float healthbarDisplacement = 0.3f;
    private Transform healthBar;
    private Transform healthBarBacking;
    private float maxHealthBar; 
    private int maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        health = 400;
        maxHealth = health;
        healthBar = transform.parent.GetChild(3).GetComponent<Transform>();
        healthBarBacking = transform.parent.GetChild(4).GetComponent<Transform>();
        maxHealthBar = healthBar.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        checkHealth();
        updateHealthBar();
    }

    private void updateHealthBar(){
        if (health<=0 && healthBar!=null){
            Destroy(healthBar.gameObject);
            Destroy(healthBarBacking.gameObject);
        }

        healthBar.localScale = new Vector3(((float)health/(float)maxHealth)*maxHealthBar,healthBar.localScale.y,1);
        healthBar.rotation = Quaternion.Euler(0f,0f,0f);
        healthBar.position = transform.position + new Vector3(0f,healthbarDisplacement,0f);
        healthBarBacking.rotation = Quaternion.Euler(0f,0f,0f);
        healthBarBacking.position = transform.position + new Vector3(0f,healthbarDisplacement,0f);
    }

    private void checkHealth()
    {
        if(health <= 0)
        {
            this.GetComponentInParent<SpaceStationBehavior>().StopSpawnEnemy = true;
            this.GetComponentInParent<SpaceStationBehavior>().DestoryAllSatellites = true;
            FivePercentDropBoost();
            TenPercentDropCoin();
            DropHealth();

            GameObject FindManger;
            FindManger = GameObject.Find("EnemyManger");
            FindManger.GetComponent<EnemyManger>().DestoriedEnemyNumber += 1;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "shot" || collision.gameObject.name == "shot(Clone)")
        {
            health -= 10;
        }
    }

    private void FivePercentDropBoost()
    {
        int R = GetRandomNumberForDrop();

        if (R == 1)
        {
            GameObject DropBoost = Instantiate(Resources.Load("Prefabs/EnemyBoostDrop") as GameObject);
            DropBoost.transform.position = this.transform.position + new Vector3(0.5f, 0f, 0f);
        }
    }

    private void TenPercentDropCoin()
    {
        int R = GetRandomNumberForDrop();

        if (R == 1 || R == 2 || R == 3 || R == 4)
        {
            GameObject DropBoost = Instantiate(Resources.Load("Prefabs/EnemyCoinDrop") as GameObject);
            DropBoost.transform.position = this.transform.position + new Vector3(-0.5f, 0f, 0f);
        }
    }

    private void DropHealth()
    {
        int R = GetRandomNumberForDrop();

        GameObject FindPlayer;
        FindPlayer = GameObject.Find("PlayerShip");

        if (FindPlayer.GetComponent<PlayerHealth>().health > 150)
        {
            if (R == 1)
            {
                GameObject DropBoost = Instantiate(Resources.Load("Prefabs/EnemyHealthBagDrop") as GameObject);
                DropBoost.transform.position = this.transform.position + new Vector3(-0.5f, 0f, 0f);
            }
        }

        if (FindPlayer.GetComponent<PlayerHealth>().health <= 150 && FindPlayer.GetComponent<PlayerHealth>().health >= 50)
        {
            if (R == 1 || R == 2)
            {
                GameObject DropBoost = Instantiate(Resources.Load("Prefabs/EnemyHealthBagDrop") as GameObject);
                DropBoost.transform.position = this.transform.position + new Vector3(-0.5f, 0f, 0f);
            }
        }

        if (FindPlayer.GetComponent<PlayerHealth>().health <= 50)
        {
            if (R == 1 || R == 2 || R == 3 || R == 4 || R == 5 || R == 6)
            {
                GameObject DropBoost = Instantiate(Resources.Load("Prefabs/EnemyHealthBagDrop") as GameObject);
                DropBoost.transform.position = this.transform.position + new Vector3(-0.5f, 0f, 0f);
            }
        }
    }

    private int GetRandomNumberForDrop()
    {
        int R;
        R = UnityEngine.Random.Range(0, 20);
        return R;
    }
}
