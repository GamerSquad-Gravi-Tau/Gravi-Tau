using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManger : MonoBehaviour
{
    Vector3 BlackHoleOne = new Vector3(0, 0, 0);
    private int BlackHoleSizeOne = 20;

    Vector3 BlackHoleTwo = new Vector3(100, 0, 0);
    private int SafeSizeOne = 10;
    int OneTime = 0;
    int OneBoss = 0;

    public int DestoriedEnemyNumber;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(OneTime == 0)
        {
            SpawnSingleEnemy();
            SpawnFourEnemyWithTurret();
            SpawnSpaceTurret();
            SpawnSpaceFleet();
            SpawnEnemyDrop();
            OneTime++;
        }

        //if ((this.transform.childCount - 10) <= 10 && OneBoss == 0)
        //{
        //    GameObject NewBoss = Instantiate(Resources.Load("Prefabs/Boss") as GameObject);
        //    NewBoss.transform.position = GetRandomPosition();
        //    OneBoss++;
        //}
        if (DestoriedEnemyNumber >= 35 && OneBoss == 0)
        {
            //GameObject NewBoss = Instantiate(Resources.Load("Prefabs/SmallBoss") as GameObject);
            //NewBoss.transform.position = GetRandomPosition();
            OneBoss++;
        }
    }

    private void SpawnSingleEnemy()
    {
        for (int i = 0; i < 20; i++)//20 enemyies
        {
            GameObject NewEnemyOne = Instantiate(Resources.Load("Prefabs/ChaseEnemy") as GameObject);
            NewEnemyOne.GetComponent<EnemyChase>().despawn = false;
            NewEnemyOne.transform.parent = this.gameObject.transform;
            NewEnemyOne.transform.position = GetRandomPosition();
        }
    }

    private void SpawnSpaceTurret()
    {
        for (int i = 0; i < 5; i++)//15 enemies
        {
            GameObject NewEnemyTurret = Instantiate(Resources.Load("Prefabs/SpaceAITurret") as GameObject);
            NewEnemyTurret.transform.parent = this.gameObject.transform;
            NewEnemyTurret.transform.position = GetRandomPosition();

            GameObject NewShootGunTurret = Instantiate(Resources.Load("Prefabs/SpaceShootGunTurret") as GameObject);
            NewShootGunTurret.transform.parent = this.gameObject.transform;
            NewShootGunTurret.transform.position = GetRandomPosition();

            GameObject NewRifleTurret = Instantiate(Resources.Load("Prefabs/SpaceRifleTurret") as GameObject);
            NewRifleTurret.transform.parent = this.gameObject.transform;
            NewRifleTurret.transform.position = GetRandomPosition();
        }
    }

    private void SpawnFourEnemyWithTurret()
    {
        for (int i = 0; i < 5; i++)//25 enemies
        {
            Vector3 R = GetRandomPosition();

            GameObject NewEnemyTurret = Instantiate(Resources.Load("Prefabs/SpaceAITurret") as GameObject);
            NewEnemyTurret.transform.parent = this.gameObject.transform;
            NewEnemyTurret.transform.position = R;

            GameObject NewEnemyOne = Instantiate(Resources.Load("Prefabs/ChaseEnemy") as GameObject);
            NewEnemyOne.GetComponent<EnemyChase>().despawn = false;
            NewEnemyOne.transform.parent = this.gameObject.transform;
            NewEnemyOne.transform.position = R + new Vector3(-0.5f, 0.5f, 0);

            GameObject NewEnemyTwo = Instantiate(Resources.Load("Prefabs/ChaseEnemy") as GameObject);
            NewEnemyTwo.GetComponent<EnemyChase>().despawn = false;
            NewEnemyTwo.transform.parent = this.gameObject.transform;
            NewEnemyTwo.transform.position = R + new Vector3(0.5f, 0.5f, 0);

            GameObject NewEnemyThree = Instantiate(Resources.Load("Prefabs/ChaseEnemy") as GameObject);
            NewEnemyThree.GetComponent<EnemyChase>().despawn = false;
            NewEnemyThree.transform.parent = this.gameObject.transform;
            NewEnemyThree.transform.position = R + new Vector3(-0.5f, -0.5f, 0);

            GameObject NewEnemyFour = Instantiate(Resources.Load("Prefabs/ChaseEnemy") as GameObject);
            NewEnemyFour.GetComponent<EnemyChase>().despawn = false;
            NewEnemyFour.transform.parent = this.gameObject.transform;
            NewEnemyFour.transform.position = R + new Vector3(0.5f, -0.5f, 0);
        }
    }

    private void SpawnSpaceFleet()
    {
        for (int i = 0; i < 5; i++)//5 space station
        {
            Vector3 R = GetRandomPosition();

            GameObject NewEnemyTurret = Instantiate(Resources.Load("Prefabs/SpaceStationOriginal") as GameObject);
            NewEnemyTurret.transform.parent = this.gameObject.transform;
            NewEnemyTurret.transform.position = R;
        }
    }

    private void SpawnEnemyDrop()
    {
        for (int i = 0; i < 5; i++)
        {
            Vector3 R = GetRandomPosition();

            GameObject HealthDrop = Instantiate(Resources.Load("Prefabs/EnemyHealthBagDrop") as GameObject);
            HealthDrop.transform.parent = this.gameObject.transform;
            HealthDrop.transform.position = R;
        }

        for (int i = 0; i < 5; i++)
        {
            Vector3 R = GetRandomPosition();

            GameObject BoostDrop = Instantiate(Resources.Load("Prefabs/EnemyBoostDrop") as GameObject);
            BoostDrop.transform.parent = this.gameObject.transform;
            BoostDrop.transform.position = R;
        }
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 V = Random.insideUnitCircle * 280;
        V.z = 0;
        return V;
    }
}
