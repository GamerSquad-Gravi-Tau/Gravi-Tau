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

    public float boostSpeed = 6f;
    public float boostDelay = 1f;
    public float boostStart = 0f;
    public bool changeBoost = false;
    public float boostChangeTimeStamp = 0f;
    public float boostChangeInterval = 5f;

    private float recoilTime = 0f;
    private float totalRecoil = 0.75f;
    private bool recoiled = false;

    public bool allowBoost = true;

    private PlayerWeaponsController shotControl;

    // Start is called before the first frame update
    void Start()
    {
        shotControl = gameObject.GetComponent<PlayerWeaponsController>();
    }

    // Update is called once per frame
    void Update()
    {
        currVel = currentVelocity;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,0f));
        mousePos.z=gameObject.transform.position.z;
        Vector3 faceVector = mousePos-gameObject.transform.position;
        gameObject.transform.up=faceVector.normalized;  

        if(recoilTime>totalRecoil && recoiled){
            allowBoost = true;
            recoiled = false;
        }

        if(!recoiled){
            accelerate();
        }else{
            recoilTime+=Time.smoothDeltaTime;
        }

        
        Vector2 boostVel = Vector2.zero;
        if (allowBoost){
            boostVel = boostUpdate(faceVector);
        }
        
        //transform!
        Vector3 deltaPos = (currentVelocity+boostVel)*Time.smoothDeltaTime;
        gameObject.transform.position += deltaPos;

    }

    private void accelerate(){
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

    }

    private Vector2 boostUpdate(Vector2 faceVector){
        //Boost mode
        if(Input.GetKey(KeyCode.LeftShift)){
            boostStart+=Time.smoothDeltaTime;
        }else{
            boostStart=0f;
        }

        Vector2 boostVel;
        if(boostStart>=boostDelay){
            shotControl.enableFire = false;
            boostVel=faceVector.normalized*boostSpeed;
        }else{
            shotControl.enableFire = true;
            boostVel=Vector2.zero;
        }

        if(boostVel.magnitude>0){
            currentVelocity=boostVel.normalized*maxSpeed;
        }

        return boostVel;
    }


    public void recoilStart(){
        recoiled = true;
        allowBoost = false;
        recoilTime = 0f;

    }
    
    public Vector2 getVelocity(){
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
            Vector3 planetPos = other.gameObject.transform.position;
            Vector3 planetRad = other.ClosestPoint(gameObject.transform.position); 
            Vector3 difPos = planetRad - planetPos;
            difPos *= 1.15f;
            difPos+=planetPos;
            difPos.z=gameObject.transform.position.z;

            if(currentVelocity.magnitude>0.5f*maxSpeed){
                currentVelocity = -0.8f*currentVelocity;
                gameObject.transform.position = difPos;
                recoilStart();

            }else{
                Vector2 planetVel = other.gameObject.transform.parent.GetComponent<OrbitMechanic>().getPlanetVelocity();

                currentVelocity = planetVel;
                gameObject.transform.position = difPos;
            }
        }

        if(other.gameObject.tag == "Asteriod 2.0(Clone)"){
            Vector3 planetPos = other.gameObject.transform.position;
            Vector3 planetRad = other.ClosestPoint(gameObject.transform.position); 
            Vector3 difPos = planetRad - planetPos;
            difPos *= 1.10f;
            difPos+=planetPos;
            difPos.z=gameObject.transform.position.z;

            if(currentVelocity.magnitude>0.5f*maxSpeed){
                currentVelocity = -0.8f*currentVelocity;
                gameObject.transform.position = difPos;
                recoilStart();

            }else{
                Vector2 planetVel = other.gameObject.transform.parent.GetComponent<OrbitMechanic>().getPlanetVelocity();

                currentVelocity = planetVel;
                gameObject.transform.position = difPos;
            }
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

    private void BackToNormalBoost()
    {
        boostSpeed = 6f;
        boostDelay = 1f;
        changeBoost = false;
    }

    private bool CanBackToNormalBoost()
    {
        float num = Time.realtimeSinceStartup - boostChangeTimeStamp;
        return num >= boostChangeInterval;
    }
}
