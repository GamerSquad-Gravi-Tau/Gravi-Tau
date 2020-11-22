using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DectectPlayerShootGunTurret : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerShip")
        {
            this.GetComponentInParent<SpaceShootGunTurret>().StartAttack = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerShip")
        {
            this.GetComponentInParent<SpaceShootGunTurret>().StartAttack = false;
        }
    }
}
