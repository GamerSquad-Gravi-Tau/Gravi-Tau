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
        rb.velocity = (Vector3)PlayerMovement.retVel() + transform.up * speed;
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
        AsteriodMovement a = collision.GetComponent<AsteriodMovement>();
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
        if (a != null)
        {
            a.TakeDamage(damage);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "SurfaceCollider")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "BlackHoleSurfaceCollider")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "SurfaceCollider")
        {
            Destroy(this.gameObject);
        }
    }
}