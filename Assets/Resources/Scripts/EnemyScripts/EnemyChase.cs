using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public enum ChaseEnemyState{
        stationary=0,
        travel=1,
        aggro=2,
        patrol=3
    };

    private ChaseEnemyState current_state;
    private CameraBounds boundObject;

    private Vector2 currentVelocity;

    private Transform playerTransform;
    private PlayerMovement playerMove;

    private Vector2 spawnPos;

    public float maxChaseDistance = 5f;
    public float hoverdistance = .5f;
    public float shotTimer = 0.75f;

    private float lastShot = 0f;
    public float predictionTime = .05f;
    private float maxAccel = 10f;
    private float maxSpeed = 3f;

    private float stateTime = 0f;
    private float stationaryTimer = 2f;
    
    private float attackAngle;

    public bool despawn = true;
    // Start is called before the first frame update
    void Start()
    {
        boundObject = Camera.main.GetComponent<CameraBounds>();
        spawnPos = gameObject.transform.localPosition;
        current_state = ChaseEnemyState.travel;
        attackAngle = Random.value*2f*Mathf.PI;
    }

    // Update is called once per frame
    void Update()
    {
        switch(current_state){
            case ChaseEnemyState.stationary:
                stationaryUpdate();
                break;
            case ChaseEnemyState.travel:
                travelUpdate();
                break;
            case ChaseEnemyState.aggro:
                aggroUpdate();
                break;
            case ChaseEnemyState.patrol:
                patrolUpdate();
                break;    
        }
        if (despawn)
        {
            CheckDespawn();
        }
        Vector3 nextVel = currentVelocity;
        gameObject.transform.position+=nextVel*Time.smoothDeltaTime;
    }


    private void stationaryUpdate(){
        if(stateTime>stationaryTimer){
            current_state=ChaseEnemyState.travel;
        }
        stateTime += Time.smoothDeltaTime;
        currentVelocity=Vector2.Lerp(currentVelocity,Vector2.zero,.01f);
    }

    private void travelUpdate(){
        //Go back to spawn position
        Vector2 curPos = gameObject.transform.localPosition;
        Vector2 dif = curPos-spawnPos;
        
        gameObject.transform.up = Vector3.Lerp(gameObject.transform.up,-1*dif.normalized,0.1f);

        //Kinematics
        Vector2 calcAccel = (2/(predictionTime*predictionTime))*(spawnPos-curPos-currentVelocity*predictionTime);   
        
        if(calcAccel.magnitude>maxAccel){
            calcAccel=calcAccel.normalized*maxAccel*10;
        }

        currentVelocity+=calcAccel*Time.smoothDeltaTime;
        if(currentVelocity.magnitude>maxSpeed*0.75f){
            currentVelocity=currentVelocity.normalized*maxSpeed;
        }


    }

    private void aggroUpdate(){
        //Aim at player's future position
        Vector2 playerVelocity = playerMove.getVelocity();
        Vector2 difference = playerTransform.position - gameObject.transform.position;
        difference+=(playerVelocity*predictionTime*1);
        gameObject.transform.up = Vector3.Lerp(gameObject.transform.up,difference.normalized,0.1f);

        //Shoot if available
        if(Time.time-lastShot > shotTimer){
            shootLaser();
        }

        if(difference.magnitude>maxChaseDistance){
            //player left chase distance. Return to another state
            stateTime=0f;
            current_state=ChaseEnemyState.stationary;

        }else{
            //Hover around hoverdistance
            Vector2 curPos = gameObject.transform.position;
            Vector2 targetPos = playerTransform.position;
            targetPos+=playerVelocity*predictionTime*2; //Predicted location

            targetPos.x += hoverdistance*Mathf.Cos(attackAngle); //Target position is on a circle around the player
            targetPos.y += hoverdistance*Mathf.Sin(attackAngle); 

            Vector2 calcAccel;
            if(difference.magnitude>hoverdistance){
                //Kinematics
                calcAccel = (2/(predictionTime*predictionTime))*(targetPos-curPos-currentVelocity*predictionTime);
            }else{
                calcAccel = currentVelocity-playerVelocity;
                calcAccel /= Time.smoothDeltaTime;
            }
            
            if(calcAccel.magnitude>maxAccel){
                calcAccel=calcAccel.normalized*maxAccel;
            }

            currentVelocity+=calcAccel*Time.smoothDeltaTime;
            if(currentVelocity.magnitude>maxSpeed){
                currentVelocity=currentVelocity.normalized*maxSpeed;
            }

        }

    }

    private void patrolUpdate(){

    }



    public void EnterAggroState(GameObject player){
        playerTransform=player.transform;
        playerMove = player.GetComponent<PlayerMovement>();

        current_state=ChaseEnemyState.aggro;
    }


    private void shootLaser(){
        GameObject laser = Instantiate(Resources.Load("Prefabs/EnemyLaserGreen") as GameObject);
        //laser.transform.parent = gameObject.transform;
        laser.transform.rotation = gameObject.transform.rotation;
        laser.transform.position = gameObject.transform.position;
        laser.transform.GetComponent<LaserScript>().laserSpeed+=currentVelocity.magnitude;
        lastShot=Time.time;
    }

    private void CheckDespawn(){
        if(boundObject!=null){
            Bounds currentBound = boundObject.getCameraBounds();
            Vector2 curRelativePosition = gameObject.transform.position - currentBound.center;
            float maxX = currentBound.extents.x*1.5f;
            float maxY = currentBound.extents.y*1.5f;
            
            if (Mathf.Abs(curRelativePosition.x)>maxX || Mathf.Abs(curRelativePosition.y)>maxY){
                Destroy(gameObject);
            }
        }
    }

}
