using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public Rigidbody2D rb;
    public int speed;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        damage = 20;
        /*Vector3 tempVel = transform.up * speed;
        if (PlayerMovement.getVelocity().x >= 0 &&
            PlayerMovement.getVelocity().y >= 0)
        {
            tempVel += (Vector3)PlayerMovement.getVelocity();
        }
        rb.velocity = tempVel; */
        rb.velocity = transform.up * speed + (Vector3)PlayerMovement.getVelocity();
    }

    private void OnBecameInvisible()
    {
        enabled = false;
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth e = collision.GetComponent<EnemyHealth>();
        BossHealth s = collision.GetComponent<BossHealth>();
        if (e != null)
        {
            e.TakeDamage(damage);
            Destroy(gameObject);
        }
        if (s != null)
        {
            s.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}