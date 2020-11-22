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
        damage = 30;
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
        if (collision.gameObject.name == "SpaceAITurret" || collision.gameObject.name == "SpaceAITurret(Clone)")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.name == "SpaceStationTurret" || collision.gameObject.name == "SpaceStationTurret(Clone)")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.name == "SpaceStation" || collision.gameObject.name == "SpaceStation(Clone)")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.name == "SmallBossTurret" || collision.gameObject.name == "SmallBossTurret(Clone)")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.name == "SpiralBulletShooter" || collision.gameObject.name == "SpiralBulletShooter(Clone)")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.name == "SmallBossShotGunShooter" || collision.gameObject.name == "SmallBossShotGunShooter(Clone)")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.name == "SmallBossBody" || collision.gameObject.name == "SmallBossBody(Clone)")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.name == "SpaceShootGunTurret" || collision.gameObject.name == "SpaceShootGunTurret(Clone)")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.name == "SpaceRifleTurret" || collision.gameObject.name == "SpaceRifleTurret(Clone)")
        {
            Destroy(this.gameObject);
        }
    }
}