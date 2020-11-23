﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHealth : MonoBehaviour
{
    public int MyHealth = 150;
    public bool RightHealth;
    public bool LeftHealth;
    // Start is called before the first frame update
    void Start()
    {
        MyHealth = 150;
    }

    // Update is called once per frame
    void Update()
    {
        if (MyHealth <= 0)
        {
            ScoreScript.IncScore(150);
            if (this.gameObject.name == "SpaceStationTurret" || this.gameObject.name == "SpaceStationTurret(Clone)")
            {
                if (RightHealth)
                {
                    this.gameObject.GetComponentInParent<SpaceStationBehavior>().RightTurretDead = true;
                }
                else
                {
                    this.gameObject.GetComponentInParent<SpaceStationBehavior>().LeftTurretDead = true;
                }
            }

            FivePercentDropBoost();
            TenPercentDropCoin();
            DropHealth();

            GameObject FindManger;
            FindManger = GameObject.Find("EnemyManger");
            FindManger.GetComponent<EnemyManger>().DestoriedEnemyNumber += 1;
            Destroy(this.gameObject);
        }
        //checkMyHealth();
    }

    //private void checkMyHealth()
    //{
    //    if (MyHealth <= 0)
    //    {
    //        ScoreScript.IncScore(150);
    //        if (RightHealth)
    //        {
    //            this.gameObject.GetComponentInParent<SpaceStationBehavior>().RightTurretDead = true;
    //        }
    //        else
    //        {
    //            this.gameObject.GetComponentInParent<SpaceStationBehavior>().LeftTurretDead = true;
    //        }

    //        //FivePercentDropBoost();
    //        //TenPercentDropCoin();
    //        //DropHealth();

    //        Destroy(this.gameObject);
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "shot(Clone)" || collision.gameObject.name == "shot")
        {
            MyHealth -= 10;
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
            if (R == 1 || R == 2 || R == 3 || R == 4 || R == 5 || R ==6)
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