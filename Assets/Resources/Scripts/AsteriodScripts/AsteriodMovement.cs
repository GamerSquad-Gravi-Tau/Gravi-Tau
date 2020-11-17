using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteriodMovement : MonoBehaviour
{

    public float asteriodSpeed = 0.3F;
    public ParticleSystem explode;
    public float shakeSpeed = 1.0f;
    public float shakeAmount = 1.0f;
    private ShakePosition AsteriodShake = new ShakePosition(10f, 1f);
    private Transform parentTransform;
    private bool destroyed = false;
    private int currentFrames = 0;
    private int totalFrames = 60 * 10;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(0.2f, 0.2f, 1f);
        //parentTransform = this.transform.parent;
        //transform.localPosition = parentTransform.transform.localPosition;
        //parentTransform = gameObject.transform.parent.gameObject.transform;
        explode.transform.localPosition = this.transform.localPosition;
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

        if (destroyed && currentFrames < totalFrames)
        {
            changeColor();
            currentFrames++;
        }
        if (currentFrames >= totalFrames)
        {
            GameObject asteriod = Instantiate(Resources.Load("Prefabs/Asteriod") as GameObject);
            asteriod.transform.parent = parentTransform;
            asteriod.transform.localScale = new Vector3(1f, 1f, 1f);
            explode.transform.localScale = new Vector3(1f, 1f, 1f);
            Destroy(gameObject);
        }
        explode.transform.localPosition = transform.localPosition;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth player = collision.GetComponent<PlayerHealth>();
        if (player != null)
        {
            //float shipSpeed = collision.GetComponent<PlayerMovement>().tempShipSpeed;
            if (!destroyed)
            {
                //this.GetComponent<Collider2D>().enabled = false;
                Vector3 OriginalPosition = this.transform.localPosition;
                Vector2 ShakeMagnitude = new Vector2((collision.GetComponent<PlayerMovement>().tempShipSpeed) / 50,
                                                    (collision.GetComponent<PlayerMovement>().tempShipSpeed) / 50);
                AsteriodShake.SetShakeParameters(10f, 1);
                AsteriodShake.SetShakeMagnitude(ShakeMagnitude, OriginalPosition);

                explode.Play();
                destroyed = true;
                asteriodSpeed = 0;
            }
        }

        PlayerHealth p = collision.GetComponent<PlayerHealth>();
        if (p != null)
        {
            p.TakeDamage(50);
            Destroy(gameObject);
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

    /* private void OnBecameInvisible()
    {
        Destroy(gameObject);
        GameObject asteriod = Instantiate(Resources.Load("Prefabs/Asteriod") as GameObject);
        asteriod.transform.parent = parentTransform;
    } */

}
