using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManger : MonoBehaviour
{
    private int OneBoss = 0;
    private int CheatMode = 0;
    public int DestoriedEnemyNumber;
    private int One = 1;

    public bool destroyedBoss = false;
    public Text destroyedText;

    // Start is called before the first frame update
    void Start()
    {
        SpawnSingleEnemy();
        SpawnFourEnemyWithTurret();
        SpawnSpaceTurret();
        SpawnSpaceFleet();
        SpawnEnemyDrop();
    }

    // Update is called once per frame
    void Update()
    {
        if (DestoriedEnemyNumber == 5 && One == 1)
        {
           GameObject Player = GameObject.Find("PlayerShip");
           GameObject UpdateWeapon = Instantiate(Resources.Load("Prefabs/Weapon_Drop") as GameObject);
           UpdateWeapon.transform.position = Player.transform.position + new Vector3(5f, 0f, 0f);
           One++;
        }

        if (DestoriedEnemyNumber == 20 && One == 2)
        {
           GameObject Player = GameObject.Find("PlayerShip");
           GameObject UpdateWeapon = Instantiate(Resources.Load("Prefabs/Weapon_Drop") as GameObject);
           UpdateWeapon.transform.position = Player.transform.position + new Vector3(5f, 0f, 0f);
           One++;
        }

        if (DestoriedEnemyNumber == 50 && One == 3)
        {
           GameObject Player = GameObject.Find("PlayerShip");
           GameObject UpdateWeapon = Instantiate(Resources.Load("Prefabs/Weapon_Drop") as GameObject);
           UpdateWeapon.transform.position = Player.transform.position + new Vector3(0f, 3f, 0f);
           One++;
        }

        if (DestoriedEnemyNumber == 100 && One == 4)
        {
           GameObject Player = GameObject.Find("PlayerShip");
           GameObject UpdateWeapon = Instantiate(Resources.Load("Prefabs/Weapon_Drop") as GameObject);
           UpdateWeapon.transform.position = Player.transform.position + new Vector3(0f, 3f, 0f);
           One++;
        }

        if (DestoriedEnemyNumber >= 30 && OneBoss == 0)
        {
            GameObject NewBoss = Instantiate(Resources.Load("Prefabs/SmallBoss/SmallBoss") as GameObject);
            NewBoss.transform.position = new Vector3(40, 0, 0);
            OneBoss++;
        }


        if (DestoriedEnemyNumber >= 50 && OneBoss == 1)
        {
            GameObject NewBoss = Instantiate(Resources.Load("Prefabs/FinalBoss/FinalBoss") as GameObject);
            NewBoss.transform.position = new Vector3(40, 0, 0);
            OneBoss++;
        }
        updateKillCount();
    }

    private void updateKillCount(){
        if (DestoriedEnemyNumber< 30){
            destroyedText.text = "Destroyed Enemies: "+ DestoriedEnemyNumber +"/30";
        }
        else if(!destroyedBoss){
            destroyedText.text = "Destroyed Enemies: "+ DestoriedEnemyNumber+"\nBoss has spawned!";
        }else{
            destroyedText.text = "Destroyed Enemies: "+ DestoriedEnemyNumber+"\nBoss was defeated!";
        }
        
    }

    private void SpawnSingleEnemy()
    {
        for (int i = 0; i < 60; i++)//20 enemyies
        {
            GameObject NewEnemyOne = Instantiate(Resources.Load("Prefabs/ChaseEnemy") as GameObject);
            NewEnemyOne.GetComponent<EnemyChase>().despawn = false;
            NewEnemyOne.transform.parent = this.gameObject.transform;
            NewEnemyOne.transform.position = GetRandomPosition();
        }
    }

    private void SpawnSpaceTurret()
    {
        for (int i = 0; i < 15; i++)//15 enemies
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

            GameObject NewSpiralTurret = Instantiate(Resources.Load("Prefabs/SpiralBulletAIShooter") as GameObject);
            NewSpiralTurret.transform.parent = this.gameObject.transform;
            NewSpiralTurret.transform.position = GetRandomPosition();
        }
    }

    private void SpawnFourEnemyWithTurret()
    {
        for (int i = 0; i < 10; i++)//25 enemies
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
        for (int i = 0; i < 10; i++)//5 space station
        {
            Vector3 R = GetRandomPosition();

            GameObject NewEnemyTurret = Instantiate(Resources.Load("Prefabs/SpaceStationOriginal") as GameObject);
            NewEnemyTurret.transform.parent = this.gameObject.transform;
            NewEnemyTurret.transform.position = R;
        }
    }

    private void SpawnEnemyDrop()
    {
        for (int i = 0; i < 20; i++)
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
        //X: 35 to 45
        //Y: 4 to -4
        Vector3 V = Random.insideUnitCircle * 280;
        V.z = 0;
        while ((V.x <= 45 && V.x >= 35) && (V.y <= 4 && V.y >= -4))
        {
            V = Random.insideUnitCircle * 280;
            Debug.Log("New Random Vector3 In EnemyManger GetRandomPosition()");
        }
        return V;
    }
}
