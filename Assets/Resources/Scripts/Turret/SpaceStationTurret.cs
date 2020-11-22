using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceStationTurret : MonoBehaviour
{
    GameObject Player;

    public bool StartActive = false;
    public bool KeepUpdatePosition = true;
    public bool RightSide = true;

    public Vector3 MyStationPosition;

    private float ShootTimeStamp;
    private float ShootInterval = 5f;
    private float LaserSpeed = 50f;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("PlayerShip");
    }

    // Update is called once per frame
    void Update()
    {
        if (StartActive)
        {
            FactToPlayer();
            if (AttackCoolDown())
            {
                Attack();
            }
        }

        if (KeepUpdatePosition)
        {
            UpdateMyPosition();
        }
    }

    private void FactToPlayer()
    {
        Vector3 PlayerPosition = Player.transform.position;
        Vector3 newUp = Vector2.LerpUnclamped(transform.up, PlayerPosition - gameObject.transform.position, 80f * Time.smoothDeltaTime);
        newUp.z = transform.up.z;
        transform.up = newUp;
    }

    private void UpdateMyPosition()
    {
        if (RightSide)
        {
            this.transform.position = MyStationPosition + new Vector3(1f, 0f, 0f);
        }
        else
        {
            this.transform.position = MyStationPosition + new Vector3(-1f, 0f, 0f);
        }
    }

    private void Attack()
    {
        GameObject ShootLaser;
        ShootLaser = Instantiate(Resources.Load("Prefabs/EnemyTurretLaser") as GameObject);
        ShootLaser.transform.position = this.transform.position;
        ShootLaser.transform.up = this.transform.up;
        ShootTimeStamp = Time.realtimeSinceStartup;
    }

    private bool AttackCoolDown()
    {
        float num = Time.realtimeSinceStartup - ShootTimeStamp;
        return num >= ShootInterval;
    }
}
