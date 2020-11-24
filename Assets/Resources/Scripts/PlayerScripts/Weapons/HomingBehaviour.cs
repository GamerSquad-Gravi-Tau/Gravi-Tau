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
        speed += Vector2.Dot(PlayerMovement.retVel(),(Vector2)transform.up);
    }

    void FixedUpdate()
    {
        if (hasTarget)
        {
            if(target == null){
                hasTarget=false;
                transform.GetChild(0).GetComponent<HomingFindTarget>().foundTarget = false;
            }else{
                Vector2 dir = (Vector2)target.position - rb.position;
                dir.Normalize();

                float rotate = Vector3.Cross(dir, transform.up).z;

                rb.angularVelocity = -rotate * rSpeed;

                rb.velocity = transform.up * speed;
            }
        }
        else
        {
            rb.velocity = transform.up * speed;
            rb.angularVelocity = 0f;
        }
    }



    private void OnBecameInvisible()
    {
        enabled = false;
        Destroy(gameObject);
    }


    public void foundTarget(Transform t){
        hasTarget=true;
        target = t;
    }

    public void collideTarget(Collider2D collision){
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
