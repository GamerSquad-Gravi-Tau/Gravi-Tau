using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoostDrop : MonoBehaviour
{
    GameObject FindPlayer;
    // Start is called before the first frame update
    void Start()
    {
        FindPlayer = GameObject.Find("PlayerShip");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerShip")
        {
            FindPlayer.GetComponent<PlayerMovement>().boostDelay = 0.3f;
            FindPlayer.GetComponent<PlayerMovement>().boostSpeed = 9f;
            FindPlayer.GetComponent<PlayerMovement>().boostChangeTimeStamp = Time.realtimeSinceStartup;
            FindPlayer.GetComponent<PlayerMovement>().changeBoost = true;
            Destroy(this.gameObject);
        }
    }
}
