using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCoinDrop : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerShip")
        {
            GameObject FindPlayer;
            FindPlayer = GameObject.Find("PlayerShip");
            FindPlayer.GetComponent<PlayerCoin>().PlayerWallet += 10;
            Destroy(this.gameObject);
        }
    }
}
