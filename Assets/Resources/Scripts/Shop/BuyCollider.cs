using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name=="PlayerShip"){
            gameObject.transform.parent.GetComponent<ShopBehavior>().playerInBound = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.name=="PlayerShip"){
            gameObject.transform.parent.GetComponent<ShopBehavior>().playerInBound = false;
        }
    }
}
