using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 currentVelocity = new Vector2(0f,0f);
    private float acceleration = 0.01f;
    private float maxSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,0f));
        mousePos.z=gameObject.transform.position.z;
        Vector3 faceVector = mousePos-gameObject.transform.position;
        gameObject.transform.up=faceVector.normalized;  

        //Calculate Velocity change
        if(Input.GetKey(KeyCode.W))
            currentVelocity.y+=acceleration;
        if(Input.GetKey(KeyCode.A))
            currentVelocity.x-=acceleration;
        if(Input.GetKey(KeyCode.S))
            currentVelocity.y-=acceleration;
        if(Input.GetKey(KeyCode.D))
            currentVelocity.x+=acceleration;
        
        //Normalize if above maxSpeed
        if(currentVelocity.magnitude>maxSpeed){
            currentVelocity = currentVelocity.normalized * maxSpeed;
        }


        //transform!
        Vector3 deltaPos = currentVelocity * Time.smoothDeltaTime;
        gameObject.transform.position += deltaPos;

    }
    

    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.tag == "GravityCollider"){
            float grav = other.gameObject.transform.parent.GetComponent<GravitationalForce>().gravity;
 
            Vector2 rDif = other.gameObject.transform.position - gameObject.transform.position;
            Vector2 rHat = rDif.normalized;

            //Change velocity according to the gravity
            Vector2 acceleration = (grav/(rDif.magnitude*rDif.magnitude))*rHat;
            currentVelocity+=acceleration*Time.smoothDeltaTime;

        }
        if(other.gameObject.tag == "SurfaceCollider"){
            float grav = other.gameObject.transform.parent.GetComponent<GravitationalForce>().gravity;
 
            Vector2 rDif = other.gameObject.transform.position - gameObject.transform.position;
            Vector2 rHat = rDif.normalized;

            //Change velocity according to the gravity
            Vector2 acceleration = -1*(grav/(rDif.magnitude*rDif.magnitude))*rHat;
            currentVelocity+=acceleration*Time.smoothDeltaTime;
        }
        if(other.gameObject.tag == "LandingPad"){
            if(currentVelocity.magnitude>0.2f){
                currentVelocity=currentVelocity.normalized *0.2f;
            }
        }
    }
}
