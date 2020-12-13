using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossSpiral : MonoBehaviour
{
    GameObject Player;

    public bool StartAttack = false;
    public bool Dead = false;
    public bool Right;
    private float Angle = 0f;
    private int ModeNum = 0;

    private float ShootTimeStamp;
    private float ShootShortInterval = 0.005f;
    private float ShootLongInterval = 2f;
    private int LongShootParameter = 0;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("PlayerShip");
    }

    // Update is called once per frame
    void Update()
    {
        if (Dead)
        {
            if (Right)
            {
                this.GetComponentInParent<FinallBossBehavior>().RightSpiralShooterAlive = false;
            }
            else
            {
                this.GetComponentInParent<FinallBossBehavior>().LeftSpiralShooterAlive = false;
            }

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
                    AttackThree();
                }
                else if (ModeNum == 3)
                {
                    Attack();
                }
                else if (ModeNum == 4)
                {
                    AttackTwo();
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

    private void AttackThree()
    {
        float bulletDirectionX = transform.position.x + Mathf.Sin((Angle * Mathf.PI) / 180f);
        float buuletDirectionY = transform.position.y + Mathf.Cos((Angle * Mathf.PI) / 180f);

        Vector3 bulletMoveVector = new Vector3(bulletDirectionX, buuletDirectionY, 0f);
        Vector2 bulletUp = (bulletMoveVector - transform.position).normalized;

        GameObject ShootBullet;
        ShootBullet = Instantiate(Resources.Load("Prefabs/EnemyLaserGreen") as GameObject);
        ShootBullet.transform.position = this.transform.position;
        ShootBullet.transform.up = bulletUp;

        Angle += 25f;

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
}
