using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossWeaponForStageTwo : MonoBehaviour
{
    GameObject Player;

    private float ShootTimeStamp;
    private float ShootShortInterval = 0.2f;
    private float ShootLongInterval = 10f;
    private int LongShootParameter = 0;

    private GameObject MyCamera;

    Vector2 Zero = new Vector2();
    Vector2 One = new Vector2();
    Vector2 Two = new Vector2();
    Vector2 Three = new Vector2();
    Vector2 Four = new Vector2();
    Vector2 Five = new Vector2();
    private float LastTimeStamp;
    private float TParam;
    private Vector2 SpaceStationPosition;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("PlayerShip");
        MyCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        FactToPlayer();

        if (AttackShortCoolDown() && LongShootParameter != 15)
        {
            Attack();
            LongShootParameter++;
        }

        if (AttackLongCoolDown() && LongShootParameter == 15)
        {
            LongShootParameter = 0;
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

    private IEnumerator GoByTheRoute()
    {
        TParam += Time.smoothDeltaTime * 0.0005f;
        SpaceStationPosition = Mathf.Pow(1 - TParam, 5) * Zero +
            5 * Mathf.Pow(1 - TParam, 4) * TParam * One +
            10 * Mathf.Pow(TParam, 2) * Mathf.Pow(1 - TParam, 3) * Two +
            10 * Mathf.Pow(TParam, 3) * Mathf.Pow(1 - TParam, 2) * Three +
            5 * Mathf.Pow(TParam, 4) * (1 - TParam) * Four +
            Mathf.Pow(TParam, 5) * Five;

        this.transform.position = SpaceStationPosition;

        LastTimeStamp = Time.realtimeSinceStartup;
        yield return new WaitForEndOfFrame();
    }
}

