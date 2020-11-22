using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceRifleTurret : MonoBehaviour
{
    GameObject Player;

    public bool StartAttack = false;

    private float ShootTimeStamp;
    private float ShootShortInterval = 0.1f;
    private float ShootLongInterval = 3f;
    private int LongShootParameter = 0;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("PlayerShip");
    }

    // Update is called once per frame
    void Update()
    {
        if (StartAttack)
        {
            FactToPlayer();

            if (AttackShortCoolDown() && LongShootParameter != 7)
            {
                Attack();
                LongShootParameter++;
            }

            if (AttackLongCoolDown() && LongShootParameter == 7)
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
}
