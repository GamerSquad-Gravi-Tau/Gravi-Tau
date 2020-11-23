using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    private float min = 2f;
    private float max = 7.5f;
    private float sensativity = 3f;
    private Transform player;

    void Start(){
        player = GameObject.Find("PlayerShip").transform;
    }

    // Update is called once per frame
    void Update(){
        float nextSize = Camera.main.orthographicSize;
        
        
        nextSize-=Input.GetAxis("Mouse ScrollWheel") * sensativity;
        

        if(nextSize>max){
            nextSize=max;
        }else if(nextSize<min){
            nextSize=min;
        }

        Camera.main.orthographicSize=nextSize;

        Vector3 nextPos = player.position;
        nextPos.z=gameObject.transform.position.z;
        gameObject.transform.position=nextPos;

        
    }
}
