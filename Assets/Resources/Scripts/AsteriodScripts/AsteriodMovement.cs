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

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(0.2f, 0.2f, 1f);
        explode.transform.localScale = new Vector3(0.05f, 0.05f, 1f);
        float orbitSpeed = Random.Range(2.5f, 7.0f);
        gameObject.GetComponent<OrbitMechanic>().ORBIT_CONST = orbitSpeed;
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
                player.TakeDamage(10);
                this.GetComponent<Collider2D>().enabled = false;
                Vector3 OriginalPosition = this.transform.localPosition;
                Vector2 ShakeMagnitude = new Vector2((collision.GetComponent<PlayerMovement>().tempShipSpeed) / 50,
                                                    (collision.GetComponent<PlayerMovement>().tempShipSpeed) / 50);
                AsteriodShake.SetShakeParameters(10f, 1);
                AsteriodShake.SetShakeMagnitude(ShakeMagnitude, OriginalPosition);

                explode.Play();
                destroyed = true;
                asteriodSpeed = 0;
                
            }
        } /*else
        {
            Destroy(gameObject);
        } */


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

}
