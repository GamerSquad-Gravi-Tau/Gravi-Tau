using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossLongShoot : MonoBehaviour
{
    GameObject Player;

    public bool StartAttack = false;
    public bool Dead = false;
    public bool Right;

    private float ShootTimeStamp;
    private float ShootShortInterval = 0.2f;
    private float ShootLongInterval = 10f;
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
                this.GetComponentInParent<FinallBossBehavior>().RightLongShootTurretAlive = false;
            }
            else
            {
                this.GetComponentInParent<FinallBossBehavior>().LeftLongShootTurretAlive = false;
            }

            Destroy(this.gameObject);
        }

        if (StartAttack)
        {
            FactToPlayer();

            if (AttackShortCoolDown() && LongShootParameter != 13)
            {
                Attack();
                LongShootParameter++;
            }

            if (AttackLongCoolDown() && LongShootParameter == 13)
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
        ShootLaser.transform.up = this.transform.up;
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
