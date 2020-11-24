using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingContact : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="Enemy"){
            transform.parent.GetComponent<HomingBehaviour>().collideTarget(other);
        }

    }
}
