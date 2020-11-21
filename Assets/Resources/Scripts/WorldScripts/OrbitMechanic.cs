using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitMechanic : MonoBehaviour
{
    private float orbitDistance;
    private float dTheta;
    private Transform parentTransform;
    private float angle;

    public float ORBIT_CONST=0.1f;
    public bool randomStart=true;
    
    
    // Start is called before the first frame update
    void Start()
    {
        parentTransform = gameObject.transform.parent.gameObject.transform;

        orbitDistance = Vector2.Distance(gameObject.transform.position,parentTransform.position);
        dTheta = ORBIT_CONST/(Mathf.Sqrt(Mathf.Pow(orbitDistance,3)));

        if(randomStart){
            randomStartLocation();
        }

        angle = calcCurrentAngle();
    }

    // Update is called once per frame
    void Update()
    {
        angle += (Time.smoothDeltaTime * dTheta)%(2*Mathf.PI);
        Vector3 nextPos = new Vector3(orbitDistance*Mathf.Cos(angle),orbitDistance*Mathf.Sin(angle),0);
        gameObject.transform.position = parentTransform.position + nextPos;
    }

    private void randomStartLocation(){
        float randomAngle = Random.value*2f*Mathf.PI;
        Vector3 nextPos = new Vector3(orbitDistance*Mathf.Cos(randomAngle),orbitDistance*Mathf.Sin(randomAngle),0);
        gameObject.transform.position = nextPos;
    }

    private float calcCurrentAngle(){
        Vector3 pos = gameObject.transform.position-parentTransform.position;
        float angle = Mathf.Atan(pos.y/pos.x);
        if(pos.x==0){
            if(pos.y>0){
                return Mathf.PI/4;
            }else{
                return 3*Mathf.PI/4;
            }
        }
        if(pos.x<0){
            return angle+Mathf.PI;
        }else{
            return angle;
        }
    }

    public Vector2 getPlanetVelocity(){
        Vector2 ret = new Vector2(Mathf.Cos(angle),Mathf.Sin(angle));
        ret*=orbitDistance*dTheta;
        return ret;
    }
}
