using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform target;
    public float speed;
    private bool hasTarget;
    public int damage;
    public float rSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        damage = 10;
        hasTarget = false;
        if(GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
        {
            target = GameObject.FindGameObjectsWithTag("Enemy")[0].transform;
            hasTarget = true;
        }
    }

    void FixedUpdate()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
        {
            target = GameObject.FindGameObjectsWithTag("Enemy")[0].transform;
            hasTarget = true;
        }
        else
        {
            hasTarget = false;
        }
        if (hasTarget)
        {
            Vector2 dir = (Vector2)target.position - rb.position;
            dir.Normalize();

            float rotate = Vector3.Cross(dir, transform.up).z;

            rb.angularVelocity = -rotate * rSpeed;

            rb.velocity = transform.up * speed;
        }
        else
        {
            rb.velocity = transform.up * speed;
        }
    }

    private void OnBecameInvisible()
    {
        enabled = false;
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth e = collision.GetComponent<EnemyHealth>();
        SpaceStationHealth s = collision.GetComponent<SpaceStationHealth>();
        if (e != null)
        {
            e.TakeDamage(damage);
            Destroy(gameObject);
        }
        if(s != null)
        {
            s.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
