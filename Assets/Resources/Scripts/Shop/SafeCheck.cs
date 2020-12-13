using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeCheck : MonoBehaviour
{
    private int numEnemies = 0;
    private List<Transform> enemies = new List<Transform>();

    void LateUpdate(){
        checkForNull();
        numEnemies = enemies.Count;
        gameObject.transform.parent.GetComponent<ShopBehavior>().enemiesInRange = numEnemies;
    }

    private void checkForNull(){
        enemies.RemoveAll(item => item == null);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="Enemy"){
            enemies.Add(other.gameObject.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag=="Enemy"){
            enemies.Remove(other.gameObject.transform);
        }
    }
}
