using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCoinDrop : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerShip")
        {
            CoinScript.addCoins(10);
            Destroy(this.gameObject);
        }
    }
}
