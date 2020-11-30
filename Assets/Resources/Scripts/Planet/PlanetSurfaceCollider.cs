using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSurfaceCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerShip")
        {
            GameObject Player;
            Player = GameObject.Find("PlayerShip");
            Player.transform.position = this.transform.position + new Vector3(7f, 7f, 0f);
        }
    }
}
