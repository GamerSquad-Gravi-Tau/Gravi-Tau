using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DectectPlayerRifleTurret : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerShip")
        {
            this.GetComponentInParent<SpaceRifleTurret>().StartAttack = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerShip")
        {
            this.GetComponentInParent<SpaceRifleTurret>().StartAttack = false;
        }
    }
}
