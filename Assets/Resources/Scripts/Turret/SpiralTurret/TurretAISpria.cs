using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAISpria : MonoBehaviour
{
    GameObject Player;

    public bool StartAttack = false;
    private float Angle = 0f;
    private int ModeNum = 0;
    public int MyHealth = 50;

    private float ShootTimeStamp;
    private float ShootShortInterval = 0.005f;
    private float ShootLongInterval = 1.5f;
    private int LongShootParameter = 0;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("PlayerShip");
    }

    // Update is called once per frame
    void Update()
    {
        if (MyHealth <= 0)
        {
            FivePercentDropBoost();
            TenPercentDropCoin();
            DropHealth();

            Destroy(this.gameObject);
        }

        if (StartAttack)
        {
            if (AttackShortCoolDown() && LongShootParameter != 50)
            {
                if (ModeNum == 0)
                {
                    Attack();
                }
                else if (ModeNum == 1)
                {
                    AttackTwo();
                }
                else if (ModeNum == 2)
                {
                    Attack();
                    Attack();
                    AttackTwo();
                    AttackTwo();
                }
                else if (ModeNum == 3)
                {
                    AttackTwo();
                    AttackTwo();
                }
                else if (ModeNum == 4)
                {
                    AttackTwo();
                    Attack();
                }
                LongShootParameter++;
            }

            if (AttackLongCoolDown() && LongShootParameter == 50)
            {
                ModeNum++;
                if (ModeNum == 5)
                {
                    ModeNum = 0;
                }
                LongShootParameter = 0;
            }
        }
    }


    private void Attack()
    {
        float bulletDirectionX = transform.position.x + Mathf.Sin((Angle * Mathf.PI) / 180f);
        float buuletDirectionY = transform.position.y + Mathf.Cos((Angle * Mathf.PI) / 180f);

        Vector3 bulletMoveVector = new Vector3(bulletDirectionX, buuletDirectionY, 0f);
        Vector2 bulletUp = (bulletMoveVector - transform.position).normalized;

        GameObject ShootBullet;
        ShootBullet = Instantiate(Resources.Load("Prefabs/EnemyLaserGreen") as GameObject);
        ShootBullet.transform.position = this.transform.position;
        ShootBullet.transform.up = bulletUp;

        Angle += 10f;

        ShootTimeStamp = Time.realtimeSinceStartup;
    }

    private void AttackTwo()
    {
        float bulletDirectionX = transform.position.x + Mathf.Sin((Angle * Mathf.PI) / 180f);
        float buuletDirectionY = transform.position.y + Mathf.Cos((Angle * Mathf.PI) / 180f);

        Vector3 bulletMoveVector = new Vector3(bulletDirectionX, buuletDirectionY, 0f);
        Vector2 bulletUp = (bulletMoveVector - transform.position).normalized;

        GameObject ShootBullet;
        ShootBullet = Instantiate(Resources.Load("Prefabs/EnemyLaserGreen") as GameObject);
        ShootBullet.transform.position = this.transform.position;
        ShootBullet.transform.up = bulletUp;

        Angle += 20f;

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
        if (collision.gameObject.name == "shot" || collision.gameObject.name == "shot(Clone)")
        {
            if (StartAttack)
            {
                MyHealth -= 2;
            }
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
