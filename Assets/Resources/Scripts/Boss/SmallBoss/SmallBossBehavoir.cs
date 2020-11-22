using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBossBehavoir : MonoBehaviour
{
    public bool DectectPlayer;

    private GameObject RightTurretOne;
    public bool RightTurretOneAlive = true;

    private GameObject RightTurretTwo;
    public bool RightTurretTwoAlive = true;

    private GameObject RightSpiralShooter;
    public bool RightSpiralShooterAlive = true;

    private GameObject RightShootGun;
    public bool RightShootGunAlive = true;

    private GameObject LeftTurretOne;
    public bool LeftTurretOneAlive = true;

    private GameObject LeftTurretTwo;
    public bool LeftTurretTwoAlive = true;

    private GameObject LeftSpiralShooter;
    public bool LeftSpiralShooterAlive = true;

    private GameObject LeftShootGun;
    public bool LeftShootGunAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        RightTurretOne = Instantiate(Resources.Load("Prefabs/SmallBoss/SmallBossTurret") as GameObject);
        RightTurretOne.transform.parent = this.gameObject.transform;
        RightTurretOne.transform.position = this.transform.position + new Vector3(0.5f, 2f, 0f);
        RightTurretOne.GetComponent<SmallBossTurret>().TurretNum = 1;

        RightTurretTwo = Instantiate(Resources.Load("Prefabs/SmallBoss/SmallBossTurret") as GameObject);
        RightTurretTwo.transform.parent = this.gameObject.transform;
        RightTurretTwo.transform.position = this.transform.position + new Vector3(1.3f, 0.5f, 0f);
        RightTurretTwo.GetComponent<SmallBossTurret>().TurretNum = 2;

        LeftTurretOne = Instantiate(Resources.Load("Prefabs/SmallBoss/SmallBossTurret") as GameObject);
        LeftTurretOne.transform.parent = this.gameObject.transform;
        LeftTurretOne.transform.position = this.transform.position + new Vector3(-0.5f, 2f, 0f);
        LeftTurretOne.GetComponent<SmallBossTurret>().TurretNum = -1;

        LeftTurretTwo = Instantiate(Resources.Load("Prefabs/SmallBoss/SmallBossTurret") as GameObject);
        LeftTurretTwo.transform.parent = this.gameObject.transform;
        LeftTurretTwo.transform.position = this.transform.position + new Vector3(-1.3f, 0.5f, 0f);
        LeftTurretTwo.GetComponent<SmallBossTurret>().TurretNum = -2;

        RightSpiralShooter = Instantiate(Resources.Load("Prefabs/SmallBoss/SpiralBulletShooter") as GameObject);
        RightSpiralShooter.transform.parent = this.gameObject.transform;
        RightSpiralShooter.transform.position = this.transform.position + new Vector3(2f, -1f, 0f);
        RightSpiralShooter.GetComponent<SmallBossSpiralShooter>().Right = true;

        LeftSpiralShooter = Instantiate(Resources.Load("Prefabs/SmallBoss/SpiralBulletShooter") as GameObject);
        LeftSpiralShooter.transform.parent = this.gameObject.transform;
        LeftSpiralShooter.transform.position = this.transform.position + new Vector3(-2f, -1f, 0f);
        LeftSpiralShooter.GetComponent<SmallBossSpiralShooter>().Right = false;

        RightShootGun = Instantiate(Resources.Load("Prefabs/SmallBoss/SmallBossShotGunShooter") as GameObject);
        RightShootGun.transform.parent = this.gameObject.transform;
        RightShootGun.transform.position = this.transform.position + new Vector3(1.5f, -2f, 0f);
        RightShootGun.GetComponent<SmallBossShotGunShooter>().Right = true;

        LeftShootGun = Instantiate(Resources.Load("Prefabs/SmallBoss/SmallBossShotGunShooter") as GameObject);
        LeftShootGun.transform.parent = this.gameObject.transform;
        LeftShootGun.transform.position = this.transform.position + new Vector3(-1.5f, -2f, 0f);
        LeftShootGun.GetComponent<SmallBossShotGunShooter>().Right = false;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateChildPosition();

        if (this.transform.childCount <= 1 && this.GetComponentInChildren<SmallBossBody>().SmallBossHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void UpdateChildPosition()
    {
        if (RightTurretOneAlive)
        {
            RightTurretOne.transform.position = this.transform.position + new Vector3(0.5f, 2f, 0f);
        }
        if (RightTurretTwoAlive)
        {
            RightTurretTwo.transform.position = this.transform.position + new Vector3(1.3f, 0.5f, 0f);
        }
        if (RightSpiralShooterAlive)
        {
            RightSpiralShooter.transform.position = this.transform.position + new Vector3(2f, -1f, 0f);
        }
        if (RightShootGunAlive)
        {
            RightShootGun.transform.position = this.transform.position + new Vector3(1.5f, -2f, 0f);
        }
        if (LeftTurretOneAlive)
        {
            LeftTurretOne.transform.position = this.transform.position + new Vector3(-0.5f, 2f, 0f);
        }
        if (LeftTurretTwoAlive)
        {
            LeftTurretTwo.transform.position = this.transform.position + new Vector3(-1.3f, 0.5f, 0f);
        }
        if (LeftSpiralShooterAlive)
        {
            LeftSpiralShooter.transform.position = this.transform.position + new Vector3(-2f, -1f, 0f);
        }
        if (LeftShootGunAlive)
        {
            LeftShootGun.transform.position = this.transform.position + new Vector3(-1.5f, -2f, 0f);
        }
    }

    private void WeakChildUp()
    {
        if (RightTurretOneAlive)
        {
            RightTurretOne.GetComponent<SmallBossTurret>().StartAttack = true;
        }
        if (RightTurretTwoAlive)
        {
            RightTurretTwo.GetComponent<SmallBossTurret>().StartAttack = true;
        }
        if (RightSpiralShooterAlive)
        {
            RightSpiralShooter.GetComponent<SmallBossSpiralShooter>().StartAttack = true;
        }
        if (RightShootGunAlive)
        {
            RightShootGun.GetComponent<SmallBossShotGunShooter>().StartAttack = true;
        }
        if (LeftTurretOneAlive)
        {
            LeftTurretOne.GetComponent<SmallBossTurret>().StartAttack = true;
        }
        if (LeftTurretTwoAlive)
        {
            LeftTurretTwo.GetComponent<SmallBossTurret>().StartAttack = true;
        }
        if (LeftSpiralShooterAlive)
        {
            LeftSpiralShooter.GetComponent<SmallBossSpiralShooter>().StartAttack = true;
        }
        if (LeftShootGunAlive)
        {
            LeftShootGun.GetComponent<SmallBossShotGunShooter>().StartAttack = true;
        }
    }

    private void Sleep()
    {
        if (RightTurretOneAlive)
        {
            RightTurretOne.GetComponent<SmallBossTurret>().StartAttack = false;
        }
        if (RightTurretTwoAlive)
        {
            RightTurretTwo.GetComponent<SmallBossTurret>().StartAttack = false;
        }
        if (RightSpiralShooterAlive)
        {
            RightSpiralShooter.GetComponent<SmallBossSpiralShooter>().StartAttack = false;
        }
        if (RightShootGunAlive)
        {
            RightShootGun.GetComponent<SmallBossShotGunShooter>().StartAttack = false;
        }
        if (LeftTurretOneAlive)
        {
            LeftTurretOne.GetComponent<SmallBossTurret>().StartAttack = false;
        }
        if (LeftTurretTwoAlive)
        {
            LeftTurretTwo.GetComponent<SmallBossTurret>().StartAttack = false;
        }
        if (LeftSpiralShooterAlive)
        {
            LeftSpiralShooter.GetComponent<SmallBossSpiralShooter>().StartAttack = false;
        }
        if (LeftShootGunAlive)
        {
            LeftShootGun.GetComponent<SmallBossShotGunShooter>().StartAttack = false;
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
