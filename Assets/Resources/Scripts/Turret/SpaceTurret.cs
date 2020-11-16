using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceTurret : MonoBehaviour
{
    GameObject Player;

    public bool StartActive = false;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("PlayerShip");
    }

    // Update is called once per frame
    void Update()
    {
        if (StartActive)
        {
            FactToPlayer();
        }
    }

    private void FactToPlayer()
    {
        Vector3 PlayerPosition = Player.transform.position;
        Vector3 newUp = Vector2.LerpUnclamped(transform.up, PlayerPosition - gameObject.transform.position, 80f * Time.smoothDeltaTime);
        newUp.z = transform.up.z;
        transform.up = newUp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //For body collider
    }
}
