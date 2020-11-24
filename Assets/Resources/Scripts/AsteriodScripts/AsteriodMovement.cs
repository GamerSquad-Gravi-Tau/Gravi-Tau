using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteriodMovement : MonoBehaviour
{

    public float asteriodSpeed = 10F;
    public ParticleSystem explode;
    public float shakeSpeed = 1.0f;
    public float shakeAmount = 1.0f;
    private ShakePosition AsteriodShake = new ShakePosition(10f, 1f);
    private Transform parentTransform;
    private bool destroyed = false;
    private float currentTime = 0f;
    private float totalTime = 10f;
    private int health;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        transform.localScale = new Vector3(0.4f, 0.4f, 1f);
        explode.transform.localScale = new Vector3(0.1f, 0.1f, 1f);
        float orbitSpeed = Random.Range(5f, 15f);
        gameObject.GetComponent<OrbitMechanic>().ORBIT_CONST = orbitSpeed;
        asteriodSpeed = orbitSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += ((-asteriodSpeed * Time.smoothDeltaTime) * transform.right);
        if (!AsteriodShake.ShakeDone())
        {
            this.transform.localPosition = AsteriodShake.UpdateShake();
            transform.localPosition += ((-asteriodSpeed * Time.smoothDeltaTime) * transform.right);
        }

        if(destroyed && currentTime==0f){
            explode.transform.position = gameObject.transform.position;
        }

        if (destroyed && currentTime < totalTime)
        {
            changeColor();
            currentTime+=Time.smoothDeltaTime;
        }
        if (currentTime >= totalTime)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerShip")
        {
            PlayerHealth player = collision.GetComponent<PlayerHealth>();
            float shipSpeed = collision.GetComponent<PlayerMovement>().tempShipSpeed;
            if (!destroyed)
            {
                player.TakeDamage(20);
                this.GetComponent<Collider2D>().enabled = false;
                Vector3 OriginalPosition = this.transform.localPosition;
                Vector2 ShakeMagnitude = new Vector2(0.1f, 0.1f);
                AsteriodShake.SetShakeParameters(4f, 1f);
                AsteriodShake.SetShakeMagnitude(ShakeMagnitude, OriginalPosition);
                DisableOrbit();
                explode.Play();
                destroyed = true;
                asteriodSpeed = 0;
                
            }
        } /*else
        {
            Destroy(gameObject);
        } */


        if (collision.gameObject.name == "shot(Clone)")
        {
            if (!destroyed && health <= 0)
            {
                this.GetComponent<Collider2D>().enabled = false;
                Vector3 OriginalPosition = this.transform.localPosition;
                Vector2 ShakeMagnitude = new Vector2(0.1f, 0.1f);
                AsteriodShake.SetShakeParameters(4f, 1f);
                AsteriodShake.SetShakeMagnitude(ShakeMagnitude, OriginalPosition);
                DisableOrbit();
                explode.Play();
                destroyed = true;
                asteriodSpeed = 0;
            }
        }


        AsteriodMovement otherAsteriod = collision.GetComponent<AsteriodMovement>();
        if (otherAsteriod != null)
        {
            // make asteriods push off one another using each velocity vector
        }
    }

    private void changeColor()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        Color curColor = renderer.color;
        curColor.a *= 0.95f;
        renderer.color = curColor;
    }

    private void DisableOrbit()
    {
        this.GetComponent<OrbitMechanic>().enabled = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}

