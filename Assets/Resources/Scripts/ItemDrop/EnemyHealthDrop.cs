using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthDrop : MonoBehaviour
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
            FindPlayer.GetComponent<PlayerHealth>().health += 20;
            Destroy(this.gameObject);
        }
    }
}
