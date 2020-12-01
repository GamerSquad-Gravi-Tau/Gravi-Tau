using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleDamagePlayer : MonoBehaviour
{
    GameObject Player;

    private float TimeStamp;
    private float OneSecondInterval = 1f;
    private int fourseconddisableboost = 0;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("PlayerShip");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerShip")
        {
            Player.GetComponent<PlayerHealth>().health -= 10;
            TimeStamp = Time.realtimeSinceStartup;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            //collision.gameObject.GetComponent<EnemyInBlackHole>().DestroyThisGameObject = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerShip")
        {
            if (OneSecond())
            {
                Player.GetComponent<PlayerHealth>().health -= 10;
                TimeStamp = Time.realtimeSinceStartup;
                fourseconddisableboost++;
                if (fourseconddisableboost == 2)
                {
                    Player.GetComponent<PlayerMovement>().allowBoost = false;
                }
            }
        }


        if (collision.gameObject.tag == "Enemy")
        {
            //collision.gameObject.GetComponent<EnemyInBlackHole>().DestroyThisGameObject = true;
        }
    }

    private bool OneSecond()
    {
        float num = Time.realtimeSinceStartup - TimeStamp;
        return num >= OneSecondInterval;
    }
}
