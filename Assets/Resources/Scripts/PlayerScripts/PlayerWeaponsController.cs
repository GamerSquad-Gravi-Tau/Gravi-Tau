using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponsController : MonoBehaviour
{
    public Transform firePoint;
    public GameObject homing;
    public GameObject bullet;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shootBullet();
        }
        if (Input.GetMouseButtonDown(1))
        {
            shootHoming();
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

}
