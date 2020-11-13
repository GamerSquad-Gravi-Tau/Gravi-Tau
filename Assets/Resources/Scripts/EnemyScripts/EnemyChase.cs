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
    private Transform playerTransform;
    private CameraBounds boundObject;

    private Vector2 currentVelocity;

    public float maxChaseDistance = 3f;
    public float hoverdistance = 1.2f;
    public float shotTimer = 0.75f;

    private float lastShot = 0f;
    private float predictionTime = .1f;
    private float maxAccel = .01f;
    private float maxSpeed = 1.5f;
    

    // Start is called before the first frame update
    void Start()
    {
        boundObject = Camera.main.GetComponent<CameraBounds>();
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
        CheckDespawn();
        Vector3 nextVel = currentVelocity;
        gameObject.transform.position+=nextVel*Time.smoothDeltaTime;
    }


    private void stationaryUpdate(){
        
        currentVelocity=Vector2.Lerp(currentVelocity,Vector2.zero,.01f);
    }

    private void travelUpdate(){

    }

    private void aggroUpdate(){
        Vector2 difference = playerTransform.position - gameObject.transform.position;
        gameObject.transform.up = Vector3.Lerp(gameObject.transform.up,difference.normalized,0.1f);

        if(Time.time-lastShot > shotTimer){
            shootLaser();
        }

        if(difference.magnitude>maxChaseDistance){
            //player left chase distance. Return to another state
            current_state=ChaseEnemyState.stationary;

        }else{
            //Hover around hoverdistance
            Vector2 curPos = gameObject.transform.position;
            Vector2 targetPos = curPos + difference.normalized*hoverdistance;
            
            //Kinematics
            Vector2 calcAccel = (2/(predictionTime*predictionTime))*(targetPos-curPos-currentVelocity*predictionTime);
            
            if(calcAccel.magnitude>maxAccel){
                calcAccel=calcAccel.normalized*maxAccel;
            }

            currentVelocity+=calcAccel;
            if(currentVelocity.magnitude>maxSpeed){
                currentVelocity=currentVelocity.normalized*maxSpeed;
            }

        }

    }

    private void patrolUpdate(){

    }



    public void EnterAggroState(Transform player){
        playerTransform=player;
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
