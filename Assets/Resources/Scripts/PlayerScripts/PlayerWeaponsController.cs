using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponsController : MonoBehaviour
{
    public Transform firePoint;

    public Transform firePointDoubleLeft;
    public Transform firePointDoubleRight;
    public Transform firePointTribleMiddle;

    public GameObject homing;
    public GameObject bullet;

    public float timeBetweenBullet = 0.1f;
    private float bulletCooldown = 0.1f;

    public float timeBetweenHoming = 1f;
    private float homingCooldown = 1f;

    public bool enableFire=true;

    public AudioClip ShotSoundEffect;
    public AudioClip MissileSoundEffect;

    public int WeaponMode = 0;

    // Update is called once per frame
    void Update()
    {
        if(enableFire){
            if(bulletCooldown>timeBetweenBullet)
            {
                if (Input.GetMouseButton(0))
                {
                    if (WeaponMode == 0)
                    {
                        AudioSource.PlayClipAtPoint(ShotSoundEffect, transform.position, 0.5f);
                        shootBullet();
                        bulletCooldown = 0f;
                    }

                    if (WeaponMode == 1)
                    {
                        AudioSource.PlayClipAtPoint(ShotSoundEffect, transform.position, 0.5f);
                        shootDoubleBullet();
                        bulletCooldown = 0f;
                    }

                    if (WeaponMode == 2)
                    {
                        AudioSource.PlayClipAtPoint(ShotSoundEffect, transform.position, 0.5f);
                        shootTribleBullet();
                        bulletCooldown = 0f;
                    }


                    if (WeaponMode == 3)
                    {
                        AudioSource.PlayClipAtPoint(ShotSoundEffect, transform.position, 0.5f);
                        shootShootGunBullet();
                        bulletCooldown = 0f;
                    }

                    if (WeaponMode >= 4)
                    {
                        AudioSource.PlayClipAtPoint(ShotSoundEffect, transform.position, 0.5f);
                        shootShootSprialBullet();
                        bulletCooldown = 0f;
                    }
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

    void shootDoubleBullet()
    {
        Instantiate(bullet, firePointDoubleLeft.position, firePointDoubleLeft.rotation);
        Instantiate(bullet, firePointDoubleRight.position, firePointDoubleRight.rotation);
    }

    void shootTribleBullet()
    {
        Instantiate(bullet, firePointTribleMiddle.position, firePointTribleMiddle.rotation);
        Instantiate(bullet, firePointDoubleLeft.position, firePointDoubleLeft.rotation * Quaternion.Euler(0f, 0f, 4f));
        Instantiate(bullet, firePointDoubleRight.position, firePointDoubleRight.rotation * Quaternion.Euler(0f, 0f, -4f));
    }

    void shootShootGunBullet()
    {
        Instantiate(bullet, firePointTribleMiddle.position, firePointTribleMiddle.rotation);
        Instantiate(bullet, firePointDoubleLeft.position, firePointDoubleLeft.rotation * Quaternion.Euler(0f, 0f, 8f));
        Instantiate(bullet, firePointDoubleRight.position, firePointDoubleRight.rotation * Quaternion.Euler(0f, 0f, -8f));
        
        Instantiate(bullet, firePointDoubleLeft.position, firePointDoubleLeft.rotation * Quaternion.Euler(0f, 0f, 15f));
        Instantiate(bullet, firePointDoubleRight.position, firePointDoubleRight.rotation * Quaternion.Euler(0f, 0f, -15f));
    }

    void shootShootSprialBullet()
    {
        Instantiate(bullet, firePointTribleMiddle.position, firePointTribleMiddle.rotation);
        Instantiate(bullet, firePointDoubleLeft.position, firePointDoubleLeft.rotation * Quaternion.Euler(0f, 0f, 4f));
        Instantiate(bullet, firePointDoubleRight.position, firePointDoubleRight.rotation * Quaternion.Euler(0f, 0f, -4f));

        Instantiate(bullet, firePointDoubleLeft.position, firePointDoubleLeft.rotation * Quaternion.Euler(0f, 0f, 90f));
        Instantiate(bullet, firePointDoubleRight.position, firePointDoubleRight.rotation * Quaternion.Euler(0f, 0f, -90f));

        Instantiate(bullet, firePointDoubleLeft.position, firePointDoubleLeft.rotation * Quaternion.Euler(0f, 0f, 180f));
        Instantiate(bullet, firePointDoubleRight.position, firePointDoubleRight.rotation * Quaternion.Euler(0f, 0f, -180f));

    }

    void shootHoming()
    {
        Instantiate(homing, firePoint.position, firePoint.rotation);
    }
}
