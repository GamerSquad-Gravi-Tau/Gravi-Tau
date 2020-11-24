using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingFindTarget : MonoBehaviour
{
    public bool foundTarget = false;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="Enemy" && !foundTarget){
            foundTarget = true;
            transform.parent.GetComponent<HomingBehaviour>().foundTarget(other.gameObject.transform);
        }

    }
}
