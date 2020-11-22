using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityIndicator : MonoBehaviour
{
    
    List<Transform> gravityObjects = new List<Transform>(); 
    List<GameObject> indicators = new List<GameObject>();
    
    // Update is called once per frame
    void Update()
    {
        foreach(Transform t in gravityObjects){
            updateGravityIndicator(t);
        }
    }

    private void updateGravityIndicator(Transform t){
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="GravityCollider"){
            gravityObjects.Add(other.gameObject.transform);

            GameObject arrow = Instantiate(Resources.Load("Prefabs/GravityPointer") as GameObject);
            indicators.Add(arrow);
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag=="GravityCollider"){
            int toRemove = gravityObjects.IndexOf(other.gameObject.transform);
            gravityObjects.RemoveAt(toRemove);
            indicators.RemoveAt(toRemove);
        }
    }
}
