using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    private Camera mCamera;
    private Bounds currentWorldBounds; 
    private float smallestSize;

    // Start is called before the first frame update
    void Awake()
    {
        mCamera = gameObject.GetComponent<Camera>();
        smallestSize = mCamera.orthographicSize;
        UpdateCameraBounds();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCameraBounds();
    }

    private void UpdateCameraBounds(){
        float vert = smallestSize*2f;
        float hori = vert * mCamera.aspect;

        Vector3 c = mCamera.transform.position;
        c.z = 0;
        currentWorldBounds.center = c;
        currentWorldBounds.size = new Vector3(hori*2,vert*2,1f);
    }

    public Bounds getCameraBounds(){
        return currentWorldBounds;
    }
}
