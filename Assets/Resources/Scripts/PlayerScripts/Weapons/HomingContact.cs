using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingContact : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        transform.parent.GetComponent<HomingBehaviour>().collideTarget(other);
    }
}
