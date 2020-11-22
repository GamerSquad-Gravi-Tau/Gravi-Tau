using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceStationFaceToBezierCurve : MonoBehaviour
{
    public Vector3 NextPosition;
    // Start is called before the first frame update
    void Start()
    {
        NextPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        FactToNextPosition();
    }

    private void FactToNextPosition()
    {
        Vector3 newUp = Vector2.LerpUnclamped(transform.up, -1 * (NextPosition - gameObject.transform.position), 80f * Time.smoothDeltaTime);
        newUp.z = transform.up.z;
        transform.up = newUp;
    }
}
