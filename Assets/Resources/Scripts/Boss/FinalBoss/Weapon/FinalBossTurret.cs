using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossTurret : MonoBehaviour
{
    GameObject Player;

    public bool StartAttack = false;
    public bool Dead = false;
    public bool Right;

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
        if (Dead)
        {
            if (Right)
            {
                this.GetComponentInParent<FinallBossBehavior>().RightTurretAlive = false;
            }
            else
            {
                this.GetComponentInParent<FinallBossBehavior>().LeftTurretAlive = false;
            }

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
}
