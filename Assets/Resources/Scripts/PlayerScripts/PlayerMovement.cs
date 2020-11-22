using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Vector2 currentVelocity = new Vector2(0f,0f);
    private static Vector2 currVel;
    private float acceleration = 7f;
    private float maxSpeed = 3f;

    public float tempShipSpeed = 0.0f;

    private float boostSpeed = 6f;
    private float boostDelay = 1f;
    private float boostStart = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currVel = currentVelocity;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,0f));
        mousePos.z=gameObject.transform.position.z;
        Vector3 faceVector = mousePos-gameObject.transform.position;
        gameObject.transform.up=faceVector.normalized;  

        //Calculate Velocity change
        if(Input.GetKey(KeyCode.W))
            currentVelocity.y+=acceleration*Time.smoothDeltaTime;
        if(Input.GetKey(KeyCode.A))
            currentVelocity.x-=acceleration*Time.smoothDeltaTime;
        if(Input.GetKey(KeyCode.S))
            currentVelocity.y-=acceleration*Time.smoothDeltaTime;
        if(Input.GetKey(KeyCode.D))
            currentVelocity.x+=acceleration*Time.smoothDeltaTime;
        
        //Normalize if above maxSpeed
        if(currentVelocity.magnitude>maxSpeed){
            currentVelocity = currentVelocity.normalized * maxSpeed;
        }

        //Boost mode
        if(Input.GetKey(KeyCode.LeftShift)){
            boostStart+=Time.smoothDeltaTime;
        }else{
            boostStart=0f;
        }

        Vector2 boostVel;
        if(boostStart>=boostDelay){
            boostVel=faceVector.normalized*boostSpeed;
        }else{
            boostVel=Vector2.zero;
        }

        if(boostVel.magnitude>0){
            currentVelocity=boostVel.normalized*maxSpeed;
        }

        //transform!
        Vector3 deltaPos = (currentVelocity+boostVel)*Time.smoothDeltaTime;
        gameObject.transform.position += deltaPos;

    }
    
    public static Vector2 getVelocity(){
        return currentVelocity;
    }

    public static Vector2 retVel()
    {
        return currVel;
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
        AsteriodMovement asteriod = other.GetComponent<AsteriodMovement>();
        if (asteriod != null)
        {
            tempShipSpeed = acceleration;
            acceleration = -acceleration / 5f;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.name=="WorldBound"){
            Debug.Log("Left play area");
        }    
    }
}
