using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShootGunTurret : MonoBehaviour
{
    GameObject Player;

    public bool StartAttack = false;

    private float ShootTimeStamp;
    private float ShootInterval = 1.5f;

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
            if (AttackCoolDown())
            {
                ShootGunAttack();
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

    private void ShootGunAttack()
    {
        for (int i = 0; i < 9; i++)
        {
            GameObject ShootLaser;
            //ShootLaser = Instantiate(Resources.Load("Prefabs/EnemyLaserGreen") as GameObject);
            ShootLaser = Instantiate(Resources.Load("Prefabs/EnemyTurretLaser") as GameObject);
            ShootLaser.transform.position = this.transform.position;

            if (i == 0)
            {
                float XDirection = Player.transform.position.x + Mathf.Sin((20f * Mathf.PI) / 180f);
                float YDirection = Player.transform.position.y + Mathf.Cos((20f * Mathf.PI) / 180f);
                Vector3 bulletMoveVector = new Vector3(XDirection, YDirection, 0f);
                Vector2 newUp = (bulletMoveVector - this.transform.position).normalized;
                ShootLaser.transform.up = newUp;
                ShootTimeStamp = Time.realtimeSinceStartup;
            }
            else if (i == 1)
            {
                float XDirection = Player.transform.position.x + Mathf.Sin((40f * Mathf.PI) / 180f);
                float YDirection = Player.transform.position.y + Mathf.Cos((40f * Mathf.PI) / 180f);
                Vector3 bulletMoveVector = new Vector3(XDirection, YDirection, 0f);
                Vector2 newUp = (bulletMoveVector - this.transform.position).normalized;
                ShootLaser.transform.up = newUp;
                //ShootLaser.transform.up = this.transform.up + new Vector3(0f, 15f, 0f);
                ShootTimeStamp = Time.realtimeSinceStartup;
            }
            else if (i == 2)
            {
                float XDirection = Player.transform.position.x + Mathf.Sin((60f * Mathf.PI) / 180f);
                float YDirection = Player.transform.position.y + Mathf.Cos((60f * Mathf.PI) / 180f);
                Vector3 bulletMoveVector = new Vector3(XDirection, YDirection, 0f);
                Vector2 newUp = (bulletMoveVector - this.transform.position).normalized;
                ShootLaser.transform.up = newUp;
                //ShootLaser.transform.up = this.transform.up + new Vector3(0f, 15f, 0f);
                ShootTimeStamp = Time.realtimeSinceStartup;
            }
            else if (i == 3)
            {
                float XDirection = Player.transform.position.x + Mathf.Sin((80f * Mathf.PI) / 180f);
                float YDirection = Player.transform.position.y + Mathf.Cos((80f * Mathf.PI) / 180f);
                Vector3 bulletMoveVector = new Vector3(XDirection, YDirection, 0f);
                Vector2 newUp = (bulletMoveVector - this.transform.position).normalized;
                ShootLaser.transform.up = newUp;
                //ShootLaser.transform.up = this.transform.up + new Vector3(0f, 15f, 0f);
                ShootTimeStamp = Time.realtimeSinceStartup;
            }
            else if (i == 4)
            {
                float XDirection = Player.transform.position.x + Mathf.Sin((-20f * Mathf.PI) / 180f);
                float YDirection = Player.transform.position.y + Mathf.Cos((-20f * Mathf.PI) / 180f);
                Vector3 bulletMoveVector = new Vector3(XDirection, YDirection, 0f);
                Vector2 newUp = (bulletMoveVector - this.transform.position).normalized;
                ShootLaser.transform.up = newUp;
                //ShootLaser.transform.up = this.transform.up + new Vector3(0f, 15f, 0f);
                ShootTimeStamp = Time.realtimeSinceStartup;
            }
            else if (i == 5)
            {
                float XDirection = Player.transform.position.x + Mathf.Sin((-40f * Mathf.PI) / 180f);
                float YDirection = Player.transform.position.y + Mathf.Cos((-40f * Mathf.PI) / 180f);
                Vector3 bulletMoveVector = new Vector3(XDirection, YDirection, 0f);
                Vector2 newUp = (bulletMoveVector - this.transform.position).normalized;
                ShootLaser.transform.up = newUp;
                //ShootLaser.transform.up = this.transform.up + new Vector3(0f, 15f, 0f);
                ShootTimeStamp = Time.realtimeSinceStartup;
            }
            else if (i == 6)
            {
                float XDirection = Player.transform.position.x + Mathf.Sin((-60f * Mathf.PI) / 180f);
                float YDirection = Player.transform.position.y + Mathf.Cos((-60f * Mathf.PI) / 180f);
                Vector3 bulletMoveVector = new Vector3(XDirection, YDirection, 0f);
                Vector2 newUp = (bulletMoveVector - this.transform.position).normalized;
                ShootLaser.transform.up = newUp;
                //ShootLaser.transform.up = this.transform.up + new Vector3(0f, 15f, 0f);
                ShootTimeStamp = Time.realtimeSinceStartup;
            }
            else if (i == 7)
            {
                float XDirection = Player.transform.position.x + Mathf.Sin((-80f * Mathf.PI) / 180f);
                float YDirection = Player.transform.position.y + Mathf.Cos((-80f * Mathf.PI) / 180f);
                Vector3 bulletMoveVector = new Vector3(XDirection, YDirection, 0f);
                Vector2 newUp = (bulletMoveVector - this.transform.position).normalized;
                ShootLaser.transform.up = newUp;
                //ShootLaser.transform.up = this.transform.up + new Vector3(0f, 15f, 0f);
                ShootTimeStamp = Time.realtimeSinceStartup;
            }
            else if (i == 8)
            {
                ShootLaser.transform.up = this.transform.up;
                ShootTimeStamp = Time.realtimeSinceStartup;
            }
        }
    }

    private bool AttackCoolDown()
    {
        float num = Time.realtimeSinceStartup - ShootTimeStamp;
        return num >= ShootInterval;
    }
}
