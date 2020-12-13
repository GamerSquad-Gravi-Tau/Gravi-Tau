using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinallBossBehavior : MonoBehaviour
{
    private GameObject RightTurret;
    public bool RightTurretAlive = true;

    private GameObject RightLongShootTurret;
    public bool RightLongShootTurretAlive = true;

    private GameObject RightSpiralShooter;
    public bool RightSpiralShooterAlive = true;

    private GameObject RightShootGun;
    public bool RightShootGunAlive = true;

    private GameObject LeftTurret;
    public bool LeftTurretAlive = true;

    private GameObject LeftLongShootTurret;
    public bool LeftLongShootTurretAlive = true;

    private GameObject LeftSpiralShooter;
    public bool LeftSpiralShooterAlive = true;

    private GameObject LeftShootGun;
    public bool LeftShootGunAlive = true;

    private int A = 0;
    private int B = 0;
    // Start is called before the first frame update
    void Start()
    {
        RightTurret = Instantiate(Resources.Load("Prefabs/FinalBoss/FinalBossTurret") as GameObject);
        RightTurret.transform.parent = this.gameObject.transform;
        RightTurret.transform.position = this.transform.position + new Vector3(1f, 2f, 0f);
        RightTurret.GetComponent<FinalBossTurret>().Right = true;

        RightLongShootTurret = Instantiate(Resources.Load("Prefabs/FinalBoss/FinalBossLongShoot") as GameObject);
        RightLongShootTurret.transform.parent = this.gameObject.transform;
        RightLongShootTurret.transform.position = this.transform.position + new Vector3(1.3f, 0.5f, 0f);
        RightLongShootTurret.GetComponent<FinalBossLongShoot>().Right = true;

        RightSpiralShooter = Instantiate(Resources.Load("Prefabs/FinalBoss/FinalBossSpiralShoot") as GameObject);
        RightSpiralShooter.transform.parent = this.gameObject.transform;
        RightSpiralShooter.transform.position = this.transform.position + new Vector3(2f, -1f, 0f);
        RightSpiralShooter.GetComponent<FinalBossSpiral>().Right = true;

        RightShootGun = Instantiate(Resources.Load("Prefabs/FinalBoss/FinalBossShootGun") as GameObject);
        RightShootGun.transform.parent = this.gameObject.transform;
        RightShootGun.transform.position = this.transform.position + new Vector3(1.5f, -2f, 0f);
        RightShootGun.GetComponent<FinalBossShootGun>().Right = true;

        LeftTurret = Instantiate(Resources.Load("Prefabs/FinalBoss/FinalBossTurret") as GameObject);
        LeftTurret.transform.parent = this.gameObject.transform;
        LeftTurret.transform.position = this.transform.position + new Vector3(-1f, 2f, 0f);
        LeftTurret.GetComponent<FinalBossTurret>().Right = false;

        LeftLongShootTurret = Instantiate(Resources.Load("Prefabs/FinalBoss/FinalBossLongShoot") as GameObject);
        LeftLongShootTurret.transform.parent = this.gameObject.transform;
        LeftLongShootTurret.transform.position = this.transform.position + new Vector3(-1.3f, 0.5f, 0f);
        LeftLongShootTurret.GetComponent<FinalBossLongShoot>().Right = false;

        LeftSpiralShooter = Instantiate(Resources.Load("Prefabs/FinalBoss/FinalBossSpiralShoot") as GameObject);
        LeftSpiralShooter.transform.parent = this.gameObject.transform;
        LeftSpiralShooter.transform.position = this.transform.position + new Vector3(-2f, -1f, 0f);
        LeftSpiralShooter.GetComponent<FinalBossSpiral>().Right = false;

        LeftShootGun = Instantiate(Resources.Load("Prefabs/FinalBoss/FinalBossShootGun") as GameObject);
        LeftShootGun.transform.parent = this.gameObject.transform;
        LeftShootGun.transform.position = this.transform.position + new Vector3(-1.5f, -2f, 0f);
        LeftShootGun.GetComponent<FinalBossShootGun>().Right = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.childCount <= 2 && A == 0)
        {
            this.gameObject.GetComponentInChildren<FinalBossBody>().CanBeDamaged = true;
            A++;
        }

        if (this.transform.childCount <= 1 && B == 0)
        {
            this.gameObject.GetComponent<FinalBossStageTwo>().StartStageTwo = true;
            B++;
        }
    }

    private void WeakChildUp()
    {
        if (RightTurretAlive == true)
        {
            RightTurret.GetComponent<FinalBossTurret>().StartAttack = true;
        }
        if (RightLongShootTurretAlive == true)
        {
            RightLongShootTurret.GetComponent<FinalBossLongShoot>().StartAttack = true;
        }
        if (RightSpiralShooterAlive == true)
        {
            RightSpiralShooter.GetComponent<FinalBossSpiral>().StartAttack = true;
        }
        if (RightShootGunAlive == true)
        {
            RightShootGun.GetComponent<FinalBossShootGun>().StartAttack = true;
        }
        if (LeftTurretAlive == true)
        {
            LeftTurret.GetComponent<FinalBossTurret>().StartAttack = true;
        }
        if (LeftLongShootTurretAlive == true)
        {
            LeftLongShootTurret.GetComponent<FinalBossLongShoot>().StartAttack = true;
        }
        if (LeftSpiralShooterAlive == true)
        {
            LeftSpiralShooter.GetComponent<FinalBossSpiral>().StartAttack = true;
        }
        if (LeftShootGunAlive == true)
        {
            LeftShootGun.GetComponent<FinalBossShootGun>().StartAttack = true;
        }
    }

    private void Sleep()
    {
        if (RightTurretAlive == true)
        {
            RightTurret.GetComponent<FinalBossTurret>().StartAttack = false;
        }
        if (RightLongShootTurretAlive == true)
        {
            RightLongShootTurret.GetComponent<FinalBossLongShoot>().StartAttack = false;
        }
        if (RightSpiralShooterAlive == true)
        {
            RightSpiralShooter.GetComponent<FinalBossSpiral>().StartAttack = false;
        }
        if (RightShootGunAlive == true)
        {
            RightShootGun.GetComponent<FinalBossShootGun>().StartAttack = false;
        }
        if (LeftTurretAlive == true)
        {
            LeftTurret.GetComponent<FinalBossTurret>().StartAttack = false;
        }
        if (LeftLongShootTurretAlive == true)
        {
            LeftLongShootTurret.GetComponent<FinalBossLongShoot>().StartAttack = false;
        }
        if (LeftSpiralShooterAlive == true)
        {
            LeftSpiralShooter.GetComponent<FinalBossSpiral>().StartAttack = false;
        }
        if (LeftShootGunAlive == true)
        {
            LeftShootGun.GetComponent<FinalBossShootGun>().StartAttack = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerShip")
        {
            WeakChildUp();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerShip")
        {
            Sleep();
        }
    }

}
