﻿using System.Collections;
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
        //damage = 10;
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
        AsteriodMovement a = collision.GetComponent<AsteriodMovement>();
        TurretHealth t = collision.GetComponent<TurretHealth>();
        SpaceStationHealth sth = collision.GetComponent<SpaceStationHealth>();
        SmallBossTurretHealth st = collision.GetComponent<SmallBossTurretHealth>();
        SmallBossBody sbb = collision.GetComponent<SmallBossBody>();
        FinalBossObjectHealthBar FB = collision.GetComponent<FinalBossObjectHealthBar>();
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
        if (t != null)
        {
            t.TakeDamage(damage);
            Destroy(this.gameObject);
        }
        if (sth != null)
        {
            sth.TakeDamage(damage);
            Destroy(this.gameObject);
        }
        if (st != null)
        {
            st.TakeDamage(damage);
            Destroy(this.gameObject);
        }
        if (sbb != null){
            sbb.TakeDamage(damage);
            Destroy(this.gameObject);
        }
        if (FB != null)
        {
            FB.TakeDamage(damage);
            Destroy(this.gameObject);
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
        if (collision.gameObject.tag == "FinalBoss")
        {
            Destroy(this.gameObject);
        }
    }
}
