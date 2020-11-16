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
            OneTime++;
        }
    }

    private void SpawnSingleEnemy()
    {
        for (int i = 0; i < 50; i++)
        {
            GameObject NewEnemyOne = Instantiate(Resources.Load("Prefabs/ChaseEnemy") as GameObject);
            NewEnemyOne.GetComponent<EnemyChase>().despawn = false;
            NewEnemyOne.transform.parent = this.gameObject.transform;
            NewEnemyOne.transform.position = GetRandomPosition();
        }
    }

    private void SpawnSpaceTurret()
    {
        for (int i = 0; i < 20; i++)
        {
            GameObject NewEnemyTurret = Instantiate(Resources.Load("Prefabs/SpaceAITurret") as GameObject);
            NewEnemyTurret.transform.parent = this.gameObject.transform;
            NewEnemyTurret.transform.position = GetRandomPosition();
        }
    }

    private void SpawnFourEnemyWithTurret()
    {
        for (int i = 0; i < 20; i++)
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
        for (int i = 0; i < 5; i++)
        {
            Vector3 R = GetRandomPosition();

            GameObject NewEnemyTurret = Instantiate(Resources.Load("Prefabs/SpaceStationOriginal") as GameObject);
            NewEnemyTurret.transform.parent = this.gameObject.transform;
            NewEnemyTurret.transform.position = R;
        }
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 V = Random.insideUnitCircle * 280;
        V.z = 0;
        return V;
    }
}
