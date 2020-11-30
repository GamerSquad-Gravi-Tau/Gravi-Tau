using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDamage : MonoBehaviour
{
    int damage = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth p = collision.GetComponent<PlayerHealth>();
        if(p != null)
        {
            p.TakeDamage(damage);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "SurfaceCollider")
        {
            Destroy(this.gameObject);
        }
    }
}
