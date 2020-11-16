using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceStationTurret : MonoBehaviour
{
    GameObject Player;

    public bool StartActive = false;

    public Vector3 MyStationPosition;
    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.name == "SpaceStationTurretRight")
        {
            this.transform.position = MyStationPosition + new Vector3(1f, 0f, 0f);
        }

        if (this.gameObject.name == "SpaceStationTurretLeft")
        {
            this.transform.position = MyStationPosition + new Vector3(-1f, 0f, 0f);
        }

        Player = GameObject.Find("PlayerShip");
    }

    // Update is called once per frame
    void Update()
    {
        if (StartActive)
        {
            FactToPlayer();
        }

        UpdateMyPosition();
    }

    private void FactToPlayer()
    {
        Vector3 PlayerPosition = Player.transform.position;
        Vector3 newUp = Vector2.LerpUnclamped(transform.up, PlayerPosition - gameObject.transform.position, 80f * Time.smoothDeltaTime);
        newUp.z = transform.up.z;
        transform.up = newUp;
    }

    private void UpdateMyPosition()
    {
        if (this.gameObject.name == "SpaceStationTurretRight")
        {
            this.transform.position = MyStationPosition + new Vector3(1f, 0f, 0f);
        }

        if (this.gameObject.name == "SpaceStationTurretLeft")
        {
            this.transform.position = MyStationPosition + new Vector3(-1f, 0f, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //For body collider
    }
}
