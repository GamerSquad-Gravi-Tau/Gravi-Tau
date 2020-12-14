using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlliesSpaceStation : MonoBehaviour
{
    GameObject Player;

    private int HealthBag = 50;
    private float TimeStamp;
    private float OneSecondInterval = 1f;
    private float SixtyInterval = 60f;

    public AudioClip HealSoundEffect;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("PlayerShip");
    }

    // Update is called once per frame
    void Update()
    {
        if (SixtySecond())
        {
            HealthBag = 50;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerShip")
        {
            DropMessage.setMessage("Replenishing Health!", Color.green);
            if (OneSecond() && HealthBag > 0)
            {
                AudioSource.PlayClipAtPoint(HealSoundEffect, transform.position, 2f);

                Player.GetComponent<PlayerHealth>().health += 10;
                HealthBag -= 10;
                TimeStamp = Time.realtimeSinceStartup;
            }
        }
    }

    private bool OneSecond()
    {
        float num = Time.realtimeSinceStartup - TimeStamp;
        return num >= OneSecondInterval;
    }

    private bool SixtySecond()
    {
        float num = Time.realtimeSinceStartup - TimeStamp;
        return num >= SixtyInterval;
    }
}
