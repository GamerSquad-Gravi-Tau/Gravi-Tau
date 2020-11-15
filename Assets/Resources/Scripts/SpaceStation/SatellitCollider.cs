using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatellitCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerShip")
        {
            Debug.Log("Destory");
            Destroy(this.transform.parent.gameObject);
        }
    }
}
