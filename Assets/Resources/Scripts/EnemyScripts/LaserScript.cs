using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    private CameraBounds boundObject;
    public float laserSpeed = 3f;

    void Start(){
        boundObject = Camera.main.GetComponent<CameraBounds>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(boundObject!=null){
            Bounds currentBound = boundObject.getCameraBounds();
            Vector2 curRelativePosition = gameObject.transform.position - currentBound.center;
            float maxX = currentBound.extents.x;
            float maxY = currentBound.extents.y;
            
            if (Mathf.Abs(curRelativePosition.x)>maxX || Mathf.Abs(curRelativePosition.y)>maxY){
                Destroy(gameObject);
            }
        }

        gameObject.transform.position+=gameObject.transform.up*laserSpeed*Time.smoothDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "SurfaceCollider")
        {
            Destroy(gameObject);
        }
    }
}
