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
    private float currentTime = 0f;
    private float totalTime = 10f;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(0.2f, 0.2f, 1f);
        //parentTransform = this.transform.parent;
        //transform.localPosition = parentTransform.transform.localPosition;
        //parentTransform = gameObject.transform.parent.gameObject.transform;
        explode.transform.position = Vector3.zero;
        parentTransform = gameObject.transform.parent;
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
        if (collision.gameObject.name == "PlayerShip")
        {
            PlayerHealth player = collision.GetComponent<PlayerHealth>();
            //float shipSpeed = collision.GetComponent<PlayerMovement>().tempShipSpeed;
            if (!destroyed)
            {
                player.TakeDamage(50);
                Destroy(gameObject);
                /*

                //this.GetComponent<Collider2D>().enabled = false;
                Vector3 OriginalPosition = this.transform.localPosition;
                Vector2 ShakeMagnitude = new Vector2((collision.GetComponent<PlayerMovement>().tempShipSpeed) / 50,
                                                    (collision.GetComponent<PlayerMovement>().tempShipSpeed) / 50);
                AsteriodShake.SetShakeParameters(10f, 1);
                AsteriodShake.SetShakeMagnitude(ShakeMagnitude, OriginalPosition);

                explode.Play();
                destroyed = true;
                asteriodSpeed = 0;
                */
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

    /* private void OnBecameInvisible()
    {
        Destroy(gameObject);
        GameObject asteriod = Instantiate(Resources.Load("Prefabs/Asteriod") as GameObject);
        asteriod.transform.parent = parentTransform;
    } */

}
