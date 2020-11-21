using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceStationBehavior : MonoBehaviour
{
    public bool StartAttack = false;
    public bool StopSpawnEnemy = false;

    private int Health = 1000;
    private int EnemyReserve = 100;
    private int Satellit = 10;

    private float RestoreStationInterval = 60f;
    private float ChangeModeInterval = 5f;

    private Transform playerTransform;

    private float SpwanEnemyTimeStamp = 0f;
    private float SpwanEnemyInterval = 10f;

    GameObject SatellitOne;
    GameObject SatellitTwo;
    GameObject SatellitThree;
    GameObject SatellitFour;
    public bool DestoryAllSatellites = false;

    GameObject TurretRight;
    GameObject TurretLeft;
    public bool RightTurretDead;
    public bool LeftTurretDead;

    // Start is called before the first frame update
    void Start()
    {
        StartAttack = false;
        StopSpawnEnemy = false;
        Health = 1000;
        EnemyReserve = 100;
        Satellit = 10;
        RestoreStationInterval = 60f;
        ChangeModeInterval = 5f;
        SpwanEnemyTimeStamp = 0f;
        SpwanEnemyInterval = 10f;

        SatellitOne = Instantiate(Resources.Load("Prefabs/SpaceStationSatellit") as GameObject);
        SatellitTwo = Instantiate(Resources.Load("Prefabs/SpaceStationSatellit") as GameObject);
        SatellitThree = Instantiate(Resources.Load("Prefabs/SpaceStationSatellit") as GameObject);
        SatellitFour = Instantiate(Resources.Load("Prefabs/SpaceStationSatellit") as GameObject);

        SatellitOne.transform.parent = this.gameObject.transform;
        SatellitTwo.transform.parent = this.gameObject.transform;
        SatellitThree.transform.parent = this.gameObject.transform;
        SatellitFour.transform.parent = this.gameObject.transform;

        SatellitOne.transform.position = this.transform.position + new Vector3(1f, 1f, 0f);
        SatellitTwo.transform.position = this.transform.position + new Vector3(-1f, 1f, 0f);
        SatellitThree.transform.position = this.transform.position + new Vector3(-1f, -1f, 0f);
        SatellitFour.transform.position = this.transform.position + new Vector3(1f, -1f, 0f);

        TurretRight = Instantiate(Resources.Load("Prefabs/SpaceStationTurret") as GameObject);
        TurretRight.transform.parent = this.gameObject.transform;
        TurretRight.transform.position = this.transform.position + new Vector3(1f, 0f, 0f);
        TurretRight.GetComponent<SpaceStationTurret>().MyStationPosition = this.transform.position;
        TurretRight.GetComponent<SpaceStationTurret>().RightSide = true;
        TurretRight.GetComponent<TurretHealth>().RightHealth = true;

        TurretLeft = Instantiate(Resources.Load("Prefabs/SpaceStationTurret") as GameObject);
        TurretLeft.transform.parent = this.gameObject.transform;
        TurretLeft.transform.position = this.transform.position + new Vector3(-1f, 0f, 0f);
        TurretLeft.GetComponent<SpaceStationTurret>().MyStationPosition = this.transform.position;
        TurretLeft.GetComponent<SpaceStationTurret>().RightSide = false;
        TurretLeft.GetComponent<TurretHealth>().LeftHealth = true;
    }

    // Update is called once per frame
    void Update()
    {
        ChechHealth();
        if (StartAttack && !StopSpawnEnemy)
        {
            SpwanFourEnemyPerTenSeconds();
        }

        if (DestoryAllSatellites)
        {
            Destroy(SatellitOne);
            Destroy(SatellitTwo);
            Destroy(SatellitThree);
            Destroy(SatellitFour);
            DestoryAllSatellites = false;
        }

        SetTurretPosition();

        if (this.transform.childCount <= 1)
        {
            Destroy(this.gameObject);
        }
    }

    private void SpwanFourEnemyPerTenSeconds()
    {
        if (CanSpwanEnemy())
        {
            GameObject NewEnemyOne = Instantiate(Resources.Load("Prefabs/ChaseEnemy") as GameObject);
            NewEnemyOne.transform.parent = gameObject.transform;
            NewEnemyOne.transform.position = this.transform.position + new Vector3(1f, 1f, 0f);

            GameObject NewEnemyTwo = Instantiate(Resources.Load("Prefabs/ChaseEnemy") as GameObject);
            NewEnemyTwo.transform.parent = gameObject.transform;
            NewEnemyTwo.transform.position = this.transform.position + new Vector3(-1f, 1f, 0f);

            GameObject NewEnemyThree = Instantiate(Resources.Load("Prefabs/ChaseEnemy") as GameObject);
            NewEnemyThree.transform.parent = gameObject.transform;
            NewEnemyThree.transform.position = this.transform.position + new Vector3(-1f, -1f, 0f);

            GameObject NewEnemyFour = Instantiate(Resources.Load("Prefabs/ChaseEnemy") as GameObject);
            NewEnemyFour.transform.parent = gameObject.transform;
            NewEnemyFour.transform.position = this.transform.position + new Vector3(1f, -1f, 0f);

            EnemyReserve -= 4;
            SpwanEnemyTimeStamp = Time.realtimeSinceStartup;
        }
    }

    private bool CanSpwanEnemy()
    {
        float num = Time.realtimeSinceStartup - SpwanEnemyTimeStamp;
        return num >= SpwanEnemyInterval;
    }

    private void ChechHealth()
    {
        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void SetTurretPosition()
    {
        if (!RightTurretDead)
        {
            TurretRight.GetComponentInChildren<SpaceStationTurret>().MyStationPosition = this.transform.position;
        }
        if (!LeftTurretDead)
        {
            TurretLeft.GetComponentInChildren<SpaceStationTurret>().MyStationPosition = this.transform.position;
        }
        //TurretRight.GetComponentInChildren<SpaceStationTurret>().MyStationPosition = this.transform.position;
        //TurretLeft.GetComponentInChildren<SpaceStationTurret>().MyStationPosition = this.transform.position;
    }
}
