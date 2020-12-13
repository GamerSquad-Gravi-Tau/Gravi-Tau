using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapController : MonoBehaviour
{
    private Camera mCamera;
    private Camera minimapCam;

    //private RectTransform minimapBack;

    private float aspect;

    public float minimapPercentageY = 0.25f;
    public float offset = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        minimapCam = gameObject.GetComponent<Camera>();
        //minimapBack = transform.GetChild(0).GetComponent<RectTransform>();
        mCamera = Camera.main;
        aspect = mCamera.aspect;
        UpdateMiniMapSize();    
    }

    // Update is called once per frame
    void Update()
    {
        if(mCamera.aspect!=aspect){
            aspect = mCamera.aspect;
            UpdateMiniMapSize();
        }
    }

    private void UpdateMiniMapSize(){
        minimapCam.rect = new Rect(offset,offset,offset+minimapPercentageY*(1/aspect),offset+minimapPercentageY);
        //minimapBack.anchorMax = new Vector2(2*offset+minimapPercentageY*(1/aspect),2*offset+minimapPercentageY);
    }
}
