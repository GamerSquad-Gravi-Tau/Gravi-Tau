﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBossTurret : MonoBehaviour
{
    GameObject Player;

    public bool StartAttack = false;
    public int TurretNum;

    private float ShootTimeStamp;
    private float ShootShortInterval = 0.4f;
    private float ShootLongInterval = 4f;
    private int LongShootParameter = 0;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("PlayerShip");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<SmallBossTurretHealth>().MyHealth <= 0)
        {
            if (TurretNum == 1)
            {
                this.GetComponentInParent<SmallBossBehavoir>().RightTurretOneAlive = false;
            }
            else if (TurretNum == 2)
            {
                this.GetComponentInParent<SmallBossBehavoir>().RightTurretTwoAlive = false;
            }
            else if (TurretNum == -1)
            {
                this.GetComponentInParent<SmallBossBehavoir>().LeftTurretOneAlive = false;
            }
            else if (TurretNum == -2)
            {
                this.GetComponentInParent<SmallBossBehavoir>().LeftTurretTwoAlive = false;
            }

            FivePercentDropBoost();
            TenPercentDropCoin();
            DropHealth();

            Destroy(this.gameObject);
        }

        if (StartAttack)
        {
            FactToPlayer();

            if (AttackShortCoolDown() && LongShootParameter != 4)
            {
                Attack();
                LongShootParameter++;
            }

            if (AttackLongCoolDown() && LongShootParameter == 4)
            {
                LongShootParameter = 0;
            }

            FactToPlayer();
        }
    }

    private void FactToPlayer()
    {
        Vector3 PlayerPosition = Player.transform.position;
        Vector3 newUp = Vector2.LerpUnclamped(transform.up, PlayerPosition - gameObject.transform.position, 80f * Time.smoothDeltaTime);
        newUp.z = transform.up.z;
        transform.up = newUp;
    }

    private void Attack()
    {
        GameObject ShootLaser;
        ShootLaser = Instantiate(Resources.Load("Prefabs/EnemyTurretLaser") as GameObject);
        ShootLaser.transform.position = this.transform.position;

        Vector3 PlayerPosition = Player.transform.position;
        Vector3 PlayerVelocity = Player.GetComponent<PlayerMovement>().getVelocity();
        PlayerPosition += PlayerVelocity * UnityEngine.Random.Range(0.5f, 2f);
        Vector3 newUp = PlayerPosition - this.transform.position;
        //Vector3 newUp = Vector2.LerpUnclamped(transform.up, PlayerPosition - gameObject.transform.position, 80f * Time.smoothDeltaTime);

        ShootLaser.transform.up = newUp;

        ShootTimeStamp = Time.realtimeSinceStartup;
    }

    private bool AttackShortCoolDown()
    {
        float num = Time.realtimeSinceStartup - ShootTimeStamp;
        return num >= ShootShortInterval;
    }

    private bool AttackLongCoolDown()
    {
        float num = Time.realtimeSinceStartup - ShootTimeStamp;
        return num >= ShootLongInterval;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.name == "shot" || collision.gameObject.name == "shot(Clone)")
        //{
        //    if (StartAttack)
        //    {
        //        MyHealth -= 2;
        //    }
        //}
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

        if (R == 1 || R == 2 || R == 3 || R == 4 || R == 5 || R == 6 || R == 7 || R == 8)
        {
            GameObject DropBoost = Instantiate(Resources.Load("Prefabs/EnemyCoinDrop") as GameObject);
            DropBoost.transform.position = this.transform.position + new Vector3(-0.5f, 0f, 0f);
        }
    }

    private void DropHealth()
    {
        int R = GetRandomNumberForDrop();
        if (Player.GetComponent<PlayerHealth>().health > 150)
        {
            if (R == 1)
            {
                GameObject DropBoost = Instantiate(Resources.Load("Prefabs/EnemyHealthBagDrop") as GameObject);
                DropBoost.transform.position = this.transform.position + new Vector3(-0.5f, 0f, 0f);
            }
        }

        if (Player.GetComponent<PlayerHealth>().health <= 150 && Player.GetComponent<PlayerHealth>().health >= 50)
        {
            if (R == 1 || R == 2)
            {
                GameObject DropBoost = Instantiate(Resources.Load("Prefabs/EnemyHealthBagDrop") as GameObject);
                DropBoost.transform.position = this.transform.position + new Vector3(-0.5f, 0f, 0f);
            }
        }

        if (Player.GetComponent<PlayerHealth>().health <= 50)
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
