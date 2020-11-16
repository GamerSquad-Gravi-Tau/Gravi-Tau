using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DectectPlayerSpaceStationTurret : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerShip")
        {
            this.GetComponentInParent<SpaceStationTurret>().StartActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerShip")
        {
            this.GetComponentInParent<SpaceStationTurret>().StartActive = false;
        }
    }
}
