using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBossBody : MonoBehaviour
{
    public int SmallBossHealth = 25;

    public float healthbarDisplacement = 0.3f;
    private Transform healthBar;
    private Transform healthBarBacking;
    private float maxHealthBar; 
    private int maxHealth;


    // Start is called before the first frame update
    void Start()
    {
        maxHealth = SmallBossHealth;
        healthBar = transform.GetChild(0).GetComponent<Transform>();
        healthBarBacking = transform.GetChild(1).GetComponent<Transform>();
        maxHealthBar = healthBar.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        updateHealthBar();
    }

    private void updateHealthBar(){
        healthBar.localScale = new Vector3(((float)SmallBossHealth/(float)maxHealth)*maxHealthBar,healthBar.localScale.y,1);
        healthBar.position = transform.position +  transform.localScale.y * new Vector3(0f,healthbarDisplacement,0f);
        healthBar.rotation = Quaternion.Euler(0f,0f,0f);
        healthBarBacking.position = transform.position +  transform.localScale.y * new Vector3(0f,healthbarDisplacement,0f);
        healthBarBacking.rotation = Quaternion.Euler(0f,0f,0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "shot" || collision.gameObject.name == "shot(Clone)")
        {
            if (this.GetComponentInParent<SmallBossBehavoir>().transform.childCount <= 2)
            {
                SmallBossHealth--;
            }
        }
    }
}
