using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityIndicator : MonoBehaviour
{
    
    List<Transform> gravityObjects = new List<Transform>(); 
    List<GameObject> indicators = new List<GameObject>();

    private float distance = .5f;
    
    // Update is called once per frame
    void Update()
    {
        for(int i=0;i<gravityObjects.Count;i++){
            updateGravityIndicator(i);
        }
    }

    private void updateGravityIndicator(int index){
        Vector2 planetPos = gravityObjects[index].position;
        Vector2 playerPos = gameObject.transform.position;
        Vector3 arrowPos = planetPos - playerPos;
        arrowPos = arrowPos.normalized*distance;
        indicators[index].transform.position=gameObject.transform.position+ arrowPos;
        indicators[index].transform.up=arrowPos;
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
            Destroy(indicators[toRemove]);
            indicators.RemoveAt(toRemove);
        }
    }
}
