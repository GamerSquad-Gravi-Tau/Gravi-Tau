using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroCollider : MonoBehaviour
{
    //Nothing in here except calling 
    private void OnTriggerEnter2D(Collider2D other) {
        gameObject.transform.parent.GetComponent<EnemyChase>().EnterAggroState(other.gameObject.transform);
    }
}
