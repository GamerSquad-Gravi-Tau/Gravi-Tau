using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCoinDrop : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerShip")
        {
            DropMessage.setMessage("Looted The Pirates!", Color.yellow);
            CoinScript.addCoins(10);
            Destroy(this.gameObject);
        }
    }
}
