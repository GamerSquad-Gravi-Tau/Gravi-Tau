using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHealth : MonoBehaviour
{
    public int MyHealth = 200;
    public bool RightHealth;
    public bool LeftHealth;

    public float healthbarDisplacement = 0.3f;
    private Transform healthBar;
    private Transform healthBarBacking;
    private float maxHealthBar; 
    private int maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        MyHealth = 200;
        maxHealth = MyHealth;
        healthBar = transform.GetChild(2).GetComponent<Transform>();
        healthBarBacking = transform.GetChild(3).GetComponent<Transform>();
        maxHealthBar = healthBar.localScale.x; 
    }

    // Update is called once per frame
    void Update()
    {
        updateHealthBar(); 
        if (MyHealth <= 0)
        {
            ScoreScript.IncScore(150);
            if (this.gameObject.name == "SpaceStationTurret" || this.gameObject.name == "SpaceStationTurret(Clone)")
            {
                if (RightHealth)
                {
                    this.gameObject.GetComponentInParent<SpaceStationBehavior>().RightTurretDead = true;
                }
                else
                {
                    this.gameObject.GetComponentInParent<SpaceStationBehavior>().LeftTurretDead = true;
                }
            }

            FivePercentDropBoost();
            TenPercentDropCoin();
            DropHealth();

            GameObject FindManger;
            FindManger = GameObject.Find("EnemyManger");
            FindManger.GetComponent<EnemyManger>().DestoriedEnemyNumber += 1;
            Destroy(this.gameObject);
        }
        //checkMyHealth();
    }
    private void updateHealthBar(){
        healthBar.localScale = new Vector3(((float)MyHealth/(float)maxHealth)*maxHealthBar,healthBar.localScale.y,1);
        healthBar.position = transform.position +  transform.localScale.y * new Vector3(0f,healthbarDisplacement,0f);
        healthBar.rotation = Quaternion.Euler(0f,0f,0f);
        healthBarBacking.position = transform.position +  transform.localScale.y * new Vector3(0f,healthbarDisplacement,0f);
        healthBarBacking.rotation = Quaternion.Euler(0f,0f,0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    }

    public void TakeDamage(int damage)
    {
        MyHealth -= (damage);
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
            if (R == 1 || R == 2 || R == 3 || R == 4 || R == 5 || R ==6)
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
