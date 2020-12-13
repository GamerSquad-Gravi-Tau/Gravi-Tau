using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossObjectHealthBar : MonoBehaviour
{
    public int MyHealth = 200;

    public float healthbarDisplacement = 0.3f;
    private Transform healthBar;
    private Transform healthBarBacking;
    private float maxHealthBar;
    private int maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        MyHealth = 400;
        //maxHealth = MyHealth;
        //healthBar = transform.GetChild(2).GetComponent<Transform>();
        //healthBarBacking = transform.GetChild(3).GetComponent<Transform>();
        //maxHealthBar = healthBar.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (MyHealth <= 0)
        {
            ScoreScript.IncScore(150);

            FivePercentDropBoost();
            TenPercentDropCoin();
            DropHealth();

            GameObject FindManger;
            FindManger = GameObject.Find("EnemyManger");
            FindManger.GetComponent<EnemyManger>().DestoriedEnemyNumber += 1;

            if (this.gameObject.name == "FinalBossLongShoot" || this.gameObject.name == "FinalBossLongShoot(Clone)")
            {
                this.gameObject.GetComponent<FinalBossLongShoot>().Dead = true;
            }
            if (this.gameObject.name == "FinalBossShootGun" || this.gameObject.name == "FinalBossShootGun(Clone)")
            {
                this.gameObject.GetComponent<FinalBossShootGun>().Dead = true;
            }
            if (this.gameObject.name == "FinalBossSpiralShoot" || this.gameObject.name == "FinalBossSpiralShoot(Clone)")
            {
                this.gameObject.GetComponent<FinalBossSpiral>().Dead = true;
            }
            if (this.gameObject.name == "FinalBossTurret" || this.gameObject.name == "FinalBossTurret(Clone)")
            {
                this.gameObject.GetComponent<FinalBossTurret>().Dead = true;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        MyHealth -= (damage - 10);
    }

    private void FivePercentDropBoost()
    {
        int R = GetRandomNumberForDrop();

        if (R == 1)
        {
            GameObject DropBoost = Instantiate(Resources.Load("Prefabs/EnemyBoostDrop") as GameObject);
            DropBoost.transform.position = this.transform.position + new Vector3(0.5f, 0f, 0f);
        }
    }

    private void TenPercentDropCoin()
    {
        int R = GetRandomNumberForDrop();

        if (R == 1 || R == 2 || R == 3 || R == 4 || R == 5 || R == 6 || R == 7 || R == 8)
        {
            GameObject DropBoost = Instantiate(Resources.Load("Prefabs/EnemyCoinDrop") as GameObject);
            DropBoost.transform.position = this.transform.position + new Vector3(-0.5f, 0f, 0f);
        }
    }

    private void DropHealth()
    {
        int R = GetRandomNumberForDrop();

        GameObject FindPlayer;
        FindPlayer = GameObject.Find("PlayerShip");

        if (FindPlayer.GetComponent<PlayerHealth>().health > 150)
        {
            if (R == 1)
            {
                GameObject DropBoost = Instantiate(Resources.Load("Prefabs/EnemyHealthBagDrop") as GameObject);
                DropBoost.transform.position = this.transform.position + new Vector3(-0.5f, 0f, 0f);
            }
        }

        if (FindPlayer.GetComponent<PlayerHealth>().health <= 150 && FindPlayer.GetComponent<PlayerHealth>().health >= 50)
        {
            if (R == 1 || R == 2)
            {
                GameObject DropBoost = Instantiate(Resources.Load("Prefabs/EnemyHealthBagDrop") as GameObject);
                DropBoost.transform.position = this.transform.position + new Vector3(-0.5f, 0f, 0f);
            }
        }

        if (FindPlayer.GetComponent<PlayerHealth>().health <= 50)
        {
            if (R == 1 || R == 2 || R == 3 || R == 4 || R == 5 || R == 6)
            {
                GameObject DropBoost = Instantiate(Resources.Load("Prefabs/EnemyHealthBagDrop") as GameObject);
                DropBoost.transform.position = this.transform.position + new Vector3(-0.5f, 0f, 0f);
            }
        }
    }

    private int GetRandomNumberForDrop()
    {
        int R;
        R = UnityEngine.Random.Range(0, 20);
        return R;
    }
}
