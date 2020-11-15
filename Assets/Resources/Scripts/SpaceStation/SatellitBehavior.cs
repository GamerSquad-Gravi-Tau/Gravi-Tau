using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatellitBehavior : MonoBehaviour
{
    private bool ChasePlayer = false;

    private float ChaseSpeed = 5f;

    GameObject Player;
    GameObject PlayerMissile;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("PlayerShip");
    }

    // Update is called once per frame
    void Update()
    {
        if (ChasePlayer)
        {
            StartChasePlayer();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerShip")
        {
            ChasePlayer = true;
            DisableOrbit();
        }
    }

    private void StartChasePlayer()
    {
        Vector3 PlayerPosition = Player.transform.position;
        //Vector3 PlayerPosition = Player.GetComponent<PlayerMovement>().transform.position;
        Vector3 newUp = Vector2.LerpUnclamped(transform.up, PlayerPosition - gameObject.transform.position, 80f * Time.smoothDeltaTime);
        newUp.z = transform.up.z;
        transform.up = newUp;

        this.transform.position += this.transform.up * (ChaseSpeed * Time.smoothDeltaTime);
    }

    private void DisableOrbit()
    {
        this.GetComponent<OrbitMechanic>().enabled = false;
    }

    private void StartChaseMissile()
    {

    }
}
