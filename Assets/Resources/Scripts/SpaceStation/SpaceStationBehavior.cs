using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceStationBehavior : MonoBehaviour
{
    public bool StartAttack = false;

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

    GameObject TurretRight;
    GameObject TurretLeft;

    // Start is called before the first frame update
    void Start()
    {
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

        TurretRight = Instantiate(Resources.Load("Prefabs/SpaceStationTurretRight") as GameObject);
        TurretRight.transform.parent = this.gameObject.transform;
        TurretRight.transform.position = this.transform.position + new Vector3(1f, 0f, 0f);

        TurretLeft = Instantiate(Resources.Load("Prefabs/SpaceStationTurretLeft") as GameObject);
        TurretLeft.transform.parent = this.gameObject.transform;
        TurretLeft.transform.position = this.transform.position + new Vector3(-1f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        ChechHealth();
        if (StartAttack)
        {
            SpwanFourEnemyPerTenSeconds();
        }

        SetTurretPosition();
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
        TurretRight.GetComponentInChildren<SpaceStationTurret>().MyStationPosition = this.transform.position;
        TurretLeft.GetComponentInChildren<SpaceStationTurret>().MyStationPosition = this.transform.position;
    }
}
