using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public bool inBlackHole=false;

    private Vector2 currentVelocity = new Vector2(0f,0f);
    private static Vector2 currVel;
    private float acceleration = 7f;
    private float maxSpeed = 3f;

    public float tempShipSpeed = 0.0f;
    public Text boundsWarning;

    public bool outOfBounds = false;
    public bool blinkDown = true;
    public float timeOutOfBounds = 0f;
    public float blinkTime = 0f;
    public PlayerHealth player;
    public GameObject pointer;
    private Vector3 Center;
    private float pointerRotation = 300f;

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
        boundsWarning.text = "Out of Bounds!";
        boundsWarning.enabled = false;
        Center = new Vector3(0, 0, 0);
        player = gameObject.GetComponent<PlayerHealth>();
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

        Vector2 boostVel = Vector2.zero;
        if(!inBlackHole){
            if(!recoiled){
                accelerate();
            }else{
                recoilTime+=Time.smoothDeltaTime;
            }

    
            if (allowBoost){
                boostVel = boostUpdate(faceVector);
            }
        }
        
        //transform!
        Vector3 deltaPos = (currentVelocity+boostVel)*Time.smoothDeltaTime;
        gameObject.transform.position += deltaPos;

        if (outOfBounds)
        {

            timeOutOfBounds += Time.smoothDeltaTime;
            blinkTime += Time.smoothDeltaTime;
            Vector3 centerDirection = new Vector3(pointer.transform.up.x * 0.5f,
                                                  pointer.transform.up.y * 0.5f, 0);
            PointAtCenter(Center, pointerRotation * Time.smoothDeltaTime);
            pointer.transform.position = gameObject.transform.position + centerDirection;
            if (blinkDown)
            {
                colorDown();
            } else
            {
                colorUp();
            }
        }
        if (timeOutOfBounds > 0.5f)
        {
            player.TakeDamage(2);
            timeOutOfBounds = 0f;
        }
        if (blinkTime > 2f)
        {
            blinkDown = !blinkDown;
            blinkTime = 0f;
        }

    }

    private void colorDown()
    {
        SpriteRenderer renderer = pointer.GetComponent<SpriteRenderer>();
        Color curColor = renderer.color;
        curColor.a *= 0.985f;
        renderer.color = curColor;
    }

    private void colorUp()
    {
        SpriteRenderer renderer = pointer.GetComponent<SpriteRenderer>();
        Color curColor = renderer.color;
        curColor.a *= 1.02f;
        renderer.color = curColor;
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


    public void recoilStart(float speed){
        recoiled = true;
        allowBoost = false;
        recoilTime = 0f;
        totalRecoil = speed*0.75f;
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
            difPos+=difPos.normalized*5f;
            difPos+=planetPos;
            difPos.z=gameObject.transform.position.z;
            currentVelocity = -0.8f*currentVelocity;
            recoilStart(currentVelocity.magnitude/maxSpeed);
            gameObject.transform.position = difPos;
        }

        if(other.gameObject.tag == "Asteriod 2.0(Clone)"){
            Vector3 planetPos = other.gameObject.transform.position;
            Vector3 planetRad = other.ClosestPoint(gameObject.transform.position); 
            Vector3 difPos = planetRad - planetPos;
            difPos *= 1.10f;
            difPos+=planetPos;
            difPos.z=gameObject.transform.position.z;

            currentVelocity = -0.8f*currentVelocity;    
            recoilStart(currentVelocity.magnitude/maxSpeed);
            gameObject.transform.position = difPos;
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
            outOfBounds = true;
            boundsWarning.enabled = true;
            pointer = Instantiate(Resources.Load("Prefabs/OutOfBounds") as GameObject);
        }    
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "WorldBound")
        {
            outOfBounds = false;
            boundsWarning.enabled = false;
            timeOutOfBounds = 0f;
            Destroy(pointer);
        }
    }

    private void PointAtCenter(Vector3 p, float r)
    {
        Vector3 v = p - pointer.transform.localPosition;
        pointer.transform.up = Vector3.LerpUnclamped(pointer.transform.up, v, r);
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
