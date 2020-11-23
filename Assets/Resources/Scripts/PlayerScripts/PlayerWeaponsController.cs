using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponsController : MonoBehaviour
{
    public Transform firePoint;
    public GameObject homing;
    public GameObject bullet;

    public float timeBetweenBullet = 0.1f;
    private float bulletCooldown = 0.1f;

    public float timeBetweenHoming = 1f;
    private float homingCooldown = 1f;

    public bool enableFire=true;

    public AudioClip ShotSoundEffect;
    public AudioClip MissileSoundEffect;

    // Update is called once per frame
    void Update()
    {
        if(enableFire){
            if(bulletCooldown>timeBetweenBullet)
            {
                if (Input.GetMouseButton(0))
                {
                    AudioSource.PlayClipAtPoint(ShotSoundEffect, transform.position, 0.5f);
                    shootBullet();
                    bulletCooldown=0f;
                }
            }else{
				bulletCooldown+=Time.smoothDeltaTime;
			}

            if(homingCooldown>timeBetweenHoming)
            {
                if (Input.GetMouseButton(1))
                {
                    AudioSource.PlayClipAtPoint(MissileSoundEffect, transform.position, 0.5f);
                    shootHoming();
                    homingCooldown=0f;
                }
            }else{
				homingCooldown+=Time.smoothDeltaTime;
			}
        }
        
    }

    void shootBullet()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }

    void shootHoming()
    {
        Instantiate(homing, firePoint.position, firePoint.rotation);
    }

    private void playShotSoundEffect()
    {
    }
}
