using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroColliderForSpaceStation : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerShip")
        {
            //gameObject.transform.parent.GetComponent<SpaceStationBehavior>().EnterAggroStateSpaceStation(other.gameObject.transform);
            //Debug.Log("Set attack true");
            gameObject.transform.parent.GetComponent<SpaceStationBehavior>().StartAttack = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.name);
       
        if (collision.gameObject.name == "PlayerShip")
        {
            gameObject.transform.parent.GetComponent<SpaceStationBehavior>().StartAttack = false;
        }
    }
}
