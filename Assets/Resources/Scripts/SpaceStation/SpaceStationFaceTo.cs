using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceStationFaceTo : MonoBehaviour
{
    private Vector3 PrePosition;
    // Start is called before the first frame update
    void Start()
    {
        PrePosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //if (this.gameObject.name != "SpaceStationOriginal(Clone)")
        //{
        //    FactToNextPosition();
        //}
        FactToNextPosition();
        PrePosition = this.transform.position;
    }

    private void FactToNextPosition()
    {
        //Vector3 newUp = Vector2.LerpUnclamped(transform.up, -1 * (PrePosition - gameObject.transform.position), 80f * Time.smoothDeltaTime);
        Vector3 newUp = (this.transform.position - PrePosition);
        newUp.z = transform.up.z;
        transform.up = newUp;
    }
}
